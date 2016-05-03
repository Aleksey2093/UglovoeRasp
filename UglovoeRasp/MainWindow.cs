using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Угловое_распределение
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Neutron_struct[] neu;
        private void MainWindow_Load(object sender, EventArgs e)
        {
            neu = new Neutron_struct[0];
        }

        private void загрузитьДанныеИзФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Multiselect = false;
                op.Filter = "UGL файлы (*.ugl)|*.ugl|Все файлы (*.*)|*.*";
                //Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*
                DialogResult res = op.ShowDialog();
                if (res != System.Windows.Forms.DialogResult.OK)
                    return;
                String path = op.FileName;
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                foreach (XmlNode node in doc.DocumentElement)
                {
                    if (node.Name == "R")
                        textBox1_R.Text = node.InnerText;
                    else if (node.Name == "Плотность")
                        textBox2_Плотность.Text = node.InnerText;
                    else if (node.Name == "Числозерен")
                        textBox3_count_зерен.Text = node.InnerText;
                }
            }
            catch (XmlException)
            {
                MessageBox.Show("Указанный файл хранит данные неподходящие для приложения. Выберите правильный файл", "", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void сохранитьРезультатВФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (neu.Length == 0)
                return;
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "UGL файлы (*.ugl)|*.ugl|Все файлы (*.*)|*.*";
            s.DefaultExt = ".ugl";
            if (s.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            String path = s.FileName;
        }

        /// <summary>
        /// Функция проверки корректности ввода входных параметров
        /// </summary>
        /// <param name="R">R большое</param>
        /// <param name="density">Плотность</param>
        /// <param name="grains">Количество зерен</param>
        /// <returns></returns>
        private bool prov_R_Density_Grains_Correct_TextBox(ref double R, ref double density, ref double grains)
        {
            if (!double.TryParse(textBox1_R.Text, out R))
            {
                if (double.TryParse(textBox1_R.Text.Replace(".", ","), out R))
                    goto ok;
                else if (double.TryParse(textBox1_R.Text.Replace(",", "."), out R))
                    goto ok;
                MessageBox.Show("R - числовое значение, не может быть текстовым", "Неправильный ввод",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                goto err1;
            ok: ;
            }
            if (R < 0)
            {
                MessageBox.Show("R не может быть отрицательным", "Неправильный ввод",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                goto err1;
            }
            if (!double.TryParse(textBox2_Плотность.Text, out density))
            {
                if (double.TryParse(textBox2_Плотность.Text.Replace(".", ","), out R))
                    goto ok;
                else if (double.TryParse(textBox2_Плотность.Text.Replace(",", "."), out R))
                    goto ok;
                MessageBox.Show("Плотность - числовое значение, не может быть текстовым", "Неправильный ввод",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                goto err2;
            ok: ;
            }
            if (density < 0)
            {
                MessageBox.Show("Плостность не может быть меньше нуля", "Неправильный ввод",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                goto err2;
            }
            if (!double.TryParse(textBox3_count_зерен.Text, out grains))
            {
                if (double.TryParse(textBox3_count_зерен.Text.Replace(".", ","), out R))
                    goto ok;
                else if (double.TryParse(textBox3_count_зерен.Text.Replace(",", "."), out R))
                    goto ok;
                MessageBox.Show("Число зерен - числовое значение, не может быть текстовым", "Неправильный ввод",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                goto err3;
            ok: ;
            }
            if (grains < 1)
            {
                MessageBox.Show("Число зерен не может меньше или равно нулю", "Неправильный ввод",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                goto err3;
            }
            if (grains - Math.Truncate(grains) != 0)
            {
                MessageBox.Show("Число зерен не может быть задано дробью", "Неправильный ввод",
     MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                goto err3;
            }
            return true;
        err1:
            textBox1_R.SelectAll();
            textBox1_R.Focus();
            return false;
        err2:

            textBox2_Плотность.SelectAll();
            textBox2_Плотность.Focus();
            return false;
        err3:

            textBox3_count_зерен.SelectAll();
            textBox3_count_зерен.Focus();
            return false;
        }

        private void button1startmath_Click(object sender, EventArgs e)
        {
            Neutronius neutron_class = new Neutronius();
            double R_double = -1, density = -1, grains_double = -1;
            if (!prov_R_Density_Grains_Correct_TextBox(ref R_double, ref density, ref grains_double))
            {
                return;
            }
            int grains_int = (int)Math.Truncate(grains_double);
            int rand = DateTime.Now.DayOfYear + DateTime.Now.Year +DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond - (int)grains_int;
            rand = Math.Abs(rand);
            Random random = new Random(rand);
            ret: if (!BoxNeutoron.genMaxBoxXYZ(random, grains_int, density))
            {
                BoxNeutoron.editing = true;
                goto ret;
            }
            Neutron_struct[] neutrons_box = neutron_class.randomInW_R(grains_int, R_double);
            neutrons_box = neutron_class.randomGenXYZ(neutrons_box,true);
        }
    }
}