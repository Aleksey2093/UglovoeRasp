using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Угловое_распределение
{
    public static class GraphShowNowToWindow
    {
        public static int twoDgraph = 0;
    }
    class GraphicsPaint
    {
        public struct cord
        {
            /// <summary>
            /// радиус нейтрона
            /// </summary>
            public float x { get; set; }
            /// <summary>
            /// количество одинаковых по радиусу нейтронов. Может использоваться в качестве процента
            /// </summary>
            public float y { get; set; }
        }

        public bool TwoDGraphPaint(float[] xline, float[] yline, int xmin, int xmax, int xh1, int xh2, int ymin, int ymax, 
            int yh1, int yh2, string name, string title)
        {
            if (GraphShowNowToWindow.twoDgraph > 4)
                return false;
            // Определили формат вывода графика: xwin - вывод на экран
            dislin.metafl("xwin");

            // Инициализировали библиотеку DISLIN
            dislin.disini();

            dislin.titlin(title, 1);
            dislin.titlin(name, 3);

            dislin.graf(xmin, xmax, xh1, xh2, ymin, ymax, yh1, yh2);
            //dislin.graf(0.0f, 360.0f, 0.0f, 90.0f, -2.0f, 2.0f, -1.0f, 0.5f);
            dislin.title();

            //Построим кривую
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
            return true;
        }

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
                    if (Math.Abs(list[j].x - rdouble[i]) < 0.5)
                    {
                        cor = list[j];
                        cor.y = cor.y + 1;
                        list[j] = cor;
                        ifi = false;
                        break;
                        //if (proc100 < cor.y) proc100 = (int)cor.y;
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
            for (int i = 0; i < list.Count; i++)
            {
                float p = list[i].y;
                p = p * 100 / proc100;
                cor = list[i];
                cor.y = p;
                list[i] = cor;
            }
            float[] xline = new float[list.Count];
            float[] yline = new float[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                xline[i] = i + 1;
                yline[i] = list[i].y;
            }
            TwoDGraphPaint(xline, yline, 0, list.Count, 0, (int)(list.Count/3), 0, 30, 0, 10, "w(r)", "l1");
            return true;
        }
    }
}
