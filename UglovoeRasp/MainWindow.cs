using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        List<History> historylist;
        public struct History
        {
            public double R;
            public double density;
            public int grains;
            public Neutron_struct[] neutrons;
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            neu = new Neutron_struct[0];
            historylist = new List<History>();
        }

        private void загрузитьДанныеИзФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Multiselect = false;
                op.Filter = "UGL файлы (*.ugldata)|*.ugldata|Все файлы (*.*)|*.*";
                DialogResult res = op.ShowDialog();
                if (res != System.Windows.Forms.DialogResult.OK)
                    return;
                String path = op.FileName;
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                foreach (XmlNode node in doc.DocumentElement)
                {
                    switch (node.Name)
                    {
                        case "R":
                            textBox1_R.Text = node.InnerText;
                            break;
                        case "Плотность":
                            textBox2_Плотность.Text = node.InnerText;
                            break;
                        case "Число зерен":
                            textBox3_count_зерен.Text = node.InnerText;
                            break;
                    }
                }
            }
            catch (XmlException)
            {
                MessageBox.Show("Указанный файл хранит данные неподходящие для приложения. Выберите правильный файл", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void сохранитьДанныеВФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double rdouble = - 1, density = -1, grains = -1;
            if (prov_R_Density_Grains_Correct_TextBox(ref rdouble, ref density, ref grains))
            {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "UGL файлы (*.ugldata)|*.ugldata|Все файлы (*.*)|*.*";
            s.DefaultExt = ".ugldata";
            if (s.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            String path = s.FileName;
            List<string> lines = new List<string>();
            lines.Add("<Uglovoe>");
            lines.Add("'t<R>"+ rdouble +"</R>");
            lines.Add("'t<Плотность>" + density + "</Плотность>");
            lines.Add("'t<Число зерен>" + grains + "</Числозерен>");
            lines.Add("</Uglovoe>");
            }
            else
            {
                MessageBox.Show("Не нельзя сохранить файл. Неверные исходные данные. Пожалуйста исправьте исходные данные и повторите попытку", "Ошибка сохранения", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
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
                if (double.TryParse(textBox2_Плотность.Text.Replace(".", ","), out density))
                    goto ok;
                else if (double.TryParse(textBox2_Плотность.Text.Replace(",", "."), out density))
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
                if (double.TryParse(textBox3_count_зерен.Text.Replace(".", ","), out grains))
                    goto ok;
                else if (double.TryParse(textBox3_count_зерен.Text.Replace(",", "."), out grains))
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
            Invoke(new MethodInvoker(() =>
                {
                    textBox1_R.SelectAll();
                    textBox1_R.Focus();
                }));
            return false;
        err2:
            Invoke(new MethodInvoker(() =>
            {
                textBox2_Плотность.SelectAll();
                textBox2_Плотность.Focus();
            }));
            return false;
        err3:
            Invoke(new MethodInvoker(() =>
            {
                textBox3_count_зерен.SelectAll();
                textBox3_count_зерен.Focus();
            }));
            return false;
        }

        private void button1startmath_Click(object sender, EventArgs e)
        {
            if (button1startmath.Enabled == false)
                return;
            button1startmath.Enabled = false;
            Thread thread = new Thread(delegate()
                {
                    MathПоИсходнымДанным();
                    Thread.Sleep(500);
                    Invoke(new MethodInvoker(() => { StatusLabel1Выполнение.Text = "Ожидание"; }));
                    Invoke(new MethodInvoker(() => { button1startmath.Enabled = true; }));
                });
            thread.Name = "Math поток";
            thread.Start();
        }

        /// <summary>
        /// Сохраняет результат расчета в файле
        /// </summary>
        /// <param name="R_double">R большое</param>
        /// <param name="density">Плотность</param>
        /// <param name="grains_int">Число зерен</param>
        /// <param name="x">Начало линии Х</param>
        /// <param name="xmax">Конец линии Х</param>
        /// <param name="y">Начало линии У</param>
        /// <param name="ymax">Конец линии У</param>
        /// <param name="z">Начало линии Z</param>
        /// <param name="zmax">Конец линии Z</param>
        /// <param name="neutrons_box">Массив нейтронов</param>
        private void saveToFile(double R_double, double density, int grains_int, double x,
            double xmax, double y, double ymax, double z, double zmax, Neutron_struct[] neutrons_box)
        {
            if (neutrons_box.Length == 0)
                return;
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "UGL файлы (*.uglres)|*.uglres|Все файлы (*.*)|*.*";
            s.DefaultExt = ".uglres";
            if (s.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            String path = s.FileName;
            List<String> lineslist = new List<string>();
            lineslist.Add("<NeutronsMatrix>");
            lineslist.Add("\t<Rbig>" + R_double + "</Rbig>");
            lineslist.Add("\t<Density>" + density + "</Density>");
            lineslist.Add("\t<Grains>" + grains_int + "</Grains>");
            lineslist.Add("\t<BoxXmin>" + x + "</BoxXmin>");
            lineslist.Add("\t<BoxXmax>" + xmax + "</BoxXmax>");
            lineslist.Add("\t<BoxYmin>" + y + "</BoxYmin>");
            lineslist.Add("\t<BoxYmax>" + ymax + "</BoxYmax>");
            lineslist.Add("\t<BoxZmin>" + z + "</BoxZmin>");
            lineslist.Add("\t<BoxZmax>" + zmax + "</BoxZmax>");
            lineslist.Add("\t<Neutronlist>");
            for (int i = 0; i < neutrons_box.Length; i++)
            {
                if (neutrons_box[i].x != -1 || neutrons_box[i].y != -1 || neutrons_box[i].z != -1 || neutrons_box[i].radius != -1)
                {
                    lineslist.Add("\t\t<Neutron>");
                    if (neutrons_box[i].x != -1)
                        lineslist.Add("\t\t\t<KordX>" + neutrons_box[i].x + " </KordX>");
                    if (neutrons_box[i].y != -1)
                        lineslist.Add("\t\t\t<KordY>" + neutrons_box[i].y + " </KordY>");
                    if (neutrons_box[i].z != -1)
                        lineslist.Add("\t\t\t<KordZ>" + neutrons_box[i].z + " </KordZ>");
                    if (neutrons_box[i].radius != -1)
                        lineslist.Add("\t\t\t<Radius>" + neutrons_box[i].radius + " </Radius>");
                    lineslist.Add("\t\t</Neutron>");
                }
            }
            lineslist.Add("\t<Neutronlist>");
            lineslist.Add("</NeutronsMatrix>");
            System.IO.File.WriteAllLines(path, lineslist.ToArray());
        }

        private void MainWindow_SizeChanged(object sender, EventArgs e)
        {
            string n = textBox1_R.Font.Name;
            textBox1_R.Font = new System.Drawing.Font(n, this.Height / 18);
            textBox2_Плотность.Font = new System.Drawing.Font(n, this.Height / 18);
            textBox3_count_зерен.Font = new System.Drawing.Font(n, this.Height / 18);
        }

        private void MathПоИсходнымДанным()
        {
            Neutronius neutron_class = new Neutronius();
            double R_double = -1, density = -1, grains_double = -1;
            if (!prov_R_Density_Grains_Correct_TextBox(ref R_double, ref density, ref grains_double))
            {
                return;
            }
            Invoke(new MethodInvoker(() =>
            {
                StatusLabel1Выполнение.Text = "Выполняется расчет";
                ProgressBar1Расчет.Value = 1;
            }));
            int grains_int = (int)Math.Truncate(grains_double);
            int rand = DateTime.Now.DayOfYear + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond - (int)grains_int;
            rand = Math.Abs(rand);
            Random random = new Random(rand);
        ret: if (!BoxNeutoron.genMaxBoxXYZ(random, grains_int, density))
            {
                BoxNeutoron.editing = true;
                goto ret;
            }
            Neutron_struct[] neutrons_box = neutron_class.randomInW_R(grains_int, R_double);
            Invoke(new MethodInvoker(() =>
            {
                ProgressBar1Расчет.Value = 25;
            }));
            if (checkBox1GraphW.Checked)
            {
                double[] rm = new double[grains_int];
                Parallel.For(0, grains_int, (i, state) =>
                {
                    rm[i] = neutrons_box[i].radius;
                });
                bool ifi = new GraphicsPaint().ShowGraphW(rm, R_double);
            }
            Invoke(new MethodInvoker(() =>
            {
                ProgressBar1Расчет.Value = 50;
            }));
            if (checkBox1Kord.Checked == false &&
                MessageBox.Show("Расчитать координаты нейтронов?", "", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Invoke(new MethodInvoker(() => { checkBox1Kord.Checked = true; }));
            }
            if (checkBox1Kord.Checked)
            {
                Invoke(new MethodInvoker(() =>
                {
                    StatusLabel1Выполнение.Text = "Расчет пространственных координат";
                    ProgressBar1Расчет.Value = 60;
                }));
                bool ifi = neutron_class.randomGenXYZ(neutrons_box, true);
                if (!ifi)
                {
                    MessageBox.Show("Невозможно создать пространство нейтронов для текущих исходных данных. Попробуйте произвести рассчет заново","Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                GraphicsPaint graph = new GraphicsPaint();
                graph.ThreeDGraphPaint(neutrons_box, (int)BoxNeutoron.x, (int)BoxNeutoron.xmax, (int)BoxNeutoron.x,
                    (int)BoxNeutoron.xmax / 4, (int)BoxNeutoron.y, (int)BoxNeutoron.ymax, (int)BoxNeutoron.y,
                    (int)BoxNeutoron.ymax / 4, (int)BoxNeutoron.z, (int)BoxNeutoron.zmax, (int)BoxNeutoron.z,
                    (int)BoxNeutoron.zmax / 4, "", "");
            }

            Invoke(new MethodInvoker(() =>
            {
                neu = neutrons_box;
                ProgressBar1Расчет.Value = 100;
                StatusLabel1Выполнение.Text = "Расчет завершен";
            }));
            if (checkBox1Kord.Checked)
            {
                if (MessageBox.Show("Сохранить результаты расчетов в файле", "Сохранить как",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        saveToFile(R_double, density, grains_int, BoxNeutoron.x, BoxNeutoron.xmax,
                            BoxNeutoron.y, BoxNeutoron.ymax, BoxNeutoron.z, BoxNeutoron.zmax,
                            neutrons_box);
                    }));
                }
            }
            History item = new History();
            item.R = R_double; item.density = density; item.grains = grains_int;
            item.neutrons = neutrons_box;
            historylist.Add(item);
        }
    }
}