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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public double x;
        public double y;
        public double h;
        public double q;

        //расчет кривой
        public List<float> formula1()
        {
            double a = 1 / Math.PI, b = 0;
            List<float> res = new List<float>();

            for (double i = x; i <= y; i += h)
            {
                double yawdouble = a * i * Math.Cos(q) * DtoQ() * l0toq();
                float yawfloat = (float)yawdouble;
                if (yawfloat < 0) yawfloat *= (-1);
                res.Add(yawfloat);
            }
            return res;
        }

        //считается значение l(0)
        public double l0toq()
        {
            double l,w = 0;
            int count = 1;
            for (double i = 0.44; i < 5.0; i += 0.01, count++)
            {
                w+= formula_6(i);
            }
            w = w / count;
            l = 1 / (Math.Pow(q, 2) * Math.Pow(w, 2));
            return l;
        }

        //D(q)
        public double DtoQ()
        {
            double D, Dsr=0;
            double xy = 0;
            for (double i= x;i< y;i+=h)
            {
                xy += i;
            }
            double h1 = h * 0.1;
            for (double i=q-h;i<q+h;i+=h1)
            {
                Dsr += i;
            }
            D = xy * (q + h) / Math.Sqrt(Dsr);
            return D;
        }

        //считается значение w(r)
        public double formula_6(double r)
        {
            double R, w;
            R = 1.42;
            w = (3 * Math.Pow(r,3)) / (Math.Pow(R,3)) * Math.Exp(Math.Pow(-(r / R), 3));
            return w;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void dis(int what)
        {
            List<float> xPoints1 = new List<float>();
            List<float> func11 = formula1();

            float[] xPoints = new float[func11.Count];
            float[] func1 = new float[func11.Count];
            int n = func11.Count; int j = 0;
            for (double i = x; i <= y; i += h, j++)
            {
                xPoints[j] = (float)(i);// * 100 / y);
                func1[j] = (float)(func11[j]);
            } j = 0; float ma = func1.Max();

            for (double i = x; i <= y; i += h, j++)
                func1[j] = func1[j];// * 100 / ma;
            textBox5.Text = x.ToString();
            textBox6.Text = y.ToString();
            textBox7.Text = func1.Min().ToString();
            textBox8.Text = func1.Max().ToString();

            // Определили формат вывода графика: xwin - вывод на экран
            dislin.metafl("xwin");
            dislin.disini();
            dislin.pagera();
            dislin.complx();

            // Инициализировали библиотеку DISLIN
            dislin.disini();

            dislin.titlin("MURN %", 1);
            dislin.titlin("(X1)=RED, (X2)=GREEN, (X3)=BLUE", 3);

            dislin.graf(func1.Min(), func1.Max(), func1.Min(), func1.Max()/3, xPoints.Min(), xPoints.Max(), xPoints.Min(), xPoints.Max()/3);
            dislin.title();
            dislin.grid(1, 1);

            //Построим 2 кривые
            dislin.color("red");
            dislin.curve(func1, xPoints, n);

            x--; h++; y+=10;
            xPoints1 = new List<float>();
            func11 = formula1();
            xPoints = new float[func11.Count];
            func1 = new float[func11.Count];
            n = func11.Count; j = 0;
            for (double i = x; i <= y; i += h, j++)
            {
                xPoints[j] = (float)i;
                func1[j] = (float)(func11[j]);
            }
            j = 0; ma = func1.Max();
            for (double i = x; i <= y; i += h, j++)
                func1[j] = func1[j];// * 100 / ma;

            dislin.color("green");
            dislin.curve(func1, xPoints, n);

            x-=15; h++; y -= 20;
            xPoints1 = new List<float>();
            func11 = formula1();
            xPoints = new float[func11.Count];
            func1 = new float[func11.Count];
            n = func11.Count; j = 0;
            for (double i = x; i <= y; i += h, j++)
            {
                xPoints[j] = (float)i;
                func1[j] = (float)(func11[j]);
            }
            j = 0; ma = func1.Max();
            for (double i = x; i <= y; i += h, j++)
                func1[j] = func1[j];// * 100 / ma;

            dislin.color("blue");
            dislin.curve(func1, xPoints, n);

            dislin.disfin();
        }

        private String colorw(int i)
        {
            string[] s = new string[3] { "red","green","blue" };
            if (i == 1) return s[0];
            if (i == 2) return s[1];
            if (i == 3) return s[2];
            return "-1";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            x = double.Parse(textBox1.Text.Replace('.', ','));
            y = double.Parse(textBox2.Text.Replace('.', ','));
            h = double.Parse(textBox3.Text.Replace('.', ','));
            q = q = double.Parse(textBox4.Text.Replace('.', ','));
            //disin();

            dis(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
