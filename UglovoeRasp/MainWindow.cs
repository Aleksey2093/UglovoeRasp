using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Угловое_распределение
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void загрузитьДанныеИзФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void сохранитьРезультатВФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

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
            Neutron_struct[] neutron_box = neutron_class.randomInW_R(grains_int, R_double);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }
    }
}