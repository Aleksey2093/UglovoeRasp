using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Угловое_распределение
{
    public static class GraphShowNowToWindow
    {
        public static int twoDgraph = 0;
        public static int threeDgraph = 0;
        public static bool openWinTwo = false;
        public static bool openWinTree = false;
    }
    class GraphicsPaint
    {
        public struct cord
        {
            /// <summary>
            /// радиус нейтрона
            /// </summary>
            public float x;
            /// <summary>
            /// количество одинаковых по радиусу нейтронов. Может использоваться в качестве процента
            /// </summary>
            public float y;
        }
        /// <summary>
        /// Вызов окна отображающего 2д график функции
        /// </summary>
        /// <param name="xline">массив Х</param>
        /// <param name="yline">массив У</param>
        /// <param name="xmin">начало координат Х</param>
        /// <param name="xmax">конец коррдинат Х</param>
        /// <param name="xh1">первое отображаемое число деления на линии Х</param>
        /// <param name="xh2">промежутки деления линии Х</param>
        /// <param name="ymin">начало линии У</param>
        /// <param name="ymax">конец линии У</param>
        /// <param name="yh1">первое отображаемое число деления на линии У</param>
        /// <param name="yh2">промежутки деления линии У</param>
        /// <param name="name">названия функции</param>
        /// <param name="title">названия окна</param>
        /// <returns></returns>
        public bool TwoDGraphPaint(float[] xline, float[] yline, float xmin, float xmax, float xh1, float xh2, int ymin, int ymax, 
            int yh1, int yh2, string name, string title)
        {
            while (GraphShowNowToWindow.openWinTree)
            {
                Thread.Sleep(300);
            }
            GraphShowNowToWindow.openWinTwo = true;
            if (GraphShowNowToWindow.twoDgraph > 4)
                return false;
            // Определили формат вывода графика: xwin - вывод на экран
            dislin.delglb();
            dislin.scrmod("revers");
            dislin.metafl("xwin");
            dislin.disini();
            dislin.pagera();
            dislin.complx();
            dislin.axspos(450, 1800);
            dislin.axslen(2200, 1200);
            dislin.titlin(title, 1);
            dislin.titlin(name, 3);
            dislin.name("X-axis", "X");
            dislin.name("Y-axis", "Y");
            dislin.labdig(-1, "X");
            dislin.ticks(10, "Y");
            dislin.ticks(9, "X");
            dislin.graf(xmin, xmax, xh1, xh2, ymin, ymax, yh1, yh2);
            dislin.title();
            switch(GraphShowNowToWindow.twoDgraph)
            {
                case 0:
                    dislin.color("red");
                    break;
                case 1:
                    dislin.color("green");
                    break;
                case 2:
                    dislin.color("blue");
                    break;
                case 3:
                    dislin.color("yellow");
                    break;
                case 4:
                    dislin.color("white");
                    break;
            }
            GraphShowNowToWindow.twoDgraph++;
            dislin.curve(xline, yline, yline.Length);
            dislin.disfin();
            GraphShowNowToWindow.twoDgraph--;
            GraphShowNowToWindow.openWinTwo = false;
            return true;
        }

        public bool ThreeDGraphPaint(Neutron_struct[] neutros, int xmin, int xmax, int xh1, int xh2, int ymin, int ymax,
            int yh1, int yh2, int zmin, int zmax, int zh1, int zh2, string name, string title)
        {
            while (GraphShowNowToWindow.openWinTwo || GraphShowNowToWindow.openWinTree)
            {
                Thread.Sleep(300);
            }
            GraphShowNowToWindow.openWinTree = true;
            int i, iret;
            float[] x = new float[neutros.Length];
            float[] y = new float[neutros.Length];
            float[] z = new float[neutros.Length];
            float[] rad = new float[neutros.Length];

            for (int j = 0; j < neutros.Length;j++ )
            {
                x[j] = (float)neutros[j].x;
                y[j] = (float)neutros[j].y;
                z[j] = (float)neutros[j].z;
                rad[j] = (float)neutros[j].radius;
            }
            dislin.delglb();
            dislin.setpag("da4p");
            dislin.scrmod("revers");
            dislin.metafl("cons");
            dislin.disini();
            dislin.pagera();
            dislin.hwfont();
            dislin.light("on");
            dislin.matop3(0.02f, 0.02f, 0.02f, "specular");

            dislin.clip3d("none");

            dislin.axspos(0, 2500);
            dislin.axslen(2100, 2100);

            dislin.htitle(50);
            dislin.titlin(name, 4);

            dislin.name("X-axis", "x");
            dislin.name("Y-axis", "y");
            dislin.name("Z-axis", "z");

            dislin.labdig(-1, "xyz");
            dislin.labl3d("hori");
            dislin.graf3d(xmin, xmax, xh1, xh2, ymin, ymax, yh1, (float)(yh2), zmin, zmax, zh1, zh2);

            dislin.title();

            dislin.shdmod("smooth", "surface");
            iret = dislin.zbfini();
            dislin.matop3(1.0f, 0.0f, 0.0f, "diffuse");
            for (i = 0; i < neutros.Length; i++)
                dislin.sphe3d(x[i], y[i], z[i], rad[i], 50, 25);
            dislin.matop3(0.0f, 1.0f, 0.0f, "diffuse");
            dislin.zbffin();
            dislin.disfin();
            GraphShowNowToWindow.openWinTree = false;
            return true;
        }

        /// <summary>
        /// подготовливает к рисаниваю график
        /// </summary>
        /// <param name="rdouble">Массив радиусов</param>
        /// <param name="R_double">R большое</param>
        /// <returns>true - если выполнено успешно, false - ошибка при выполнении</returns>
        public bool ShowGraphW(double[] rdouble, double R_double)
        {
            List<cord> list = new List<cord>();
            cord cor = new cord();
            cor.y = 1;
            cor.x = (float)rdouble[0];
            list.Add(cor);
            int proc100 = rdouble.Length;
            for (int i = 1; i < rdouble.Length; i++)
            {
                bool ifi = true;
                for (int j = 0; j < list.Count; j++)
                {
                    if (Math.Abs(list[j].x - rdouble[i]) < 0.9)
                    {
                        cor = list[j];
                        cor.y = cor.y + 1;
                        list[j] = cor;
                        ifi = false;
                        break;
                    }
                }
                if (ifi)
                {
                    cor = new cord();
                    cor.y = 1;
                    cor.x = (float)rdouble[i];
                    list.Add(cor);
                }
            }
            //for (int i = 0; i < list.Count; i++)
            Parallel.For(0, list.Count, (i, state) =>
            {
                float p = list[i].y;
                p = p * 100 / proc100;
                cord cordi = list[i];
                cordi.y = p;
                list[i] = cordi;
            });
            float[] xline = new float[list.Count];
            float[] yline = new float[list.Count];
            float procmax = 0;
            float min = list[0].x, max = list[0].x;
            for (int i = 0; i < list.Count-1;i++ )
            {
                int ifi = -1;
                cord t1 = list[i];
                for (int j=i+1;j<list.Count;j++)
                    {
                        if (t1.x > list[j].x)
                        {
                            t1 = list[j];
                            ifi = j;
                        }
                    }
                if (ifi != -1)
                {
                    cord c = list[i];
                    list[i] = list[ifi];
                    list[ifi] = c;
                }
            }
                Parallel.For(0, list.Count, (i, state) =>
                {
                    if (min > list[i].x)
                        min = list[i].x;
                    if (max < list[i].x)
                        max = list[i].x;
                    xline[i] = list[i].x;
                    yline[i] = list[i].y;
                    if (procmax < yline[i])
                        procmax = yline[i];
                });
            procmax = (float)(procmax * 1.5);
            Thread thread = new Thread(delegate()
            {
            retth:
                bool ifi = TwoDGraphPaint(xline, yline, min, max, min,
                    (float)(max / 10), 0, (int)procmax, 0,
                    (int)(procmax / 10), "w(r) = ", "");
                if (ifi == false)
                    goto retth;
            });
            thread.Name = "TwoGraph";
            thread.Start();
            return true;
        }
    }
}
