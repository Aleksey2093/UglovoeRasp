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
                    if (Math.Abs(list[j].x - rdouble[i]) < 0.1)
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
            Parallel.For(0,list.Count,(i,state)=>
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
            //for (int i = 0; i < list.Count; i++)
            Parallel.For(0,list.Count,(i,state) =>
            {
                xline[i] = i + 1;
                yline[i] = list[i].y;
                if (procmax < yline[i])
                    procmax = yline[i];
            });
            procmax = (float)(procmax * 1.5);
            Thread thread = new Thread(delegate()
            {
            retth:
                bool ifi = TwoDGraphPaint(xline, yline, 0, list.Count, 0, 
                    (int)(list.Count / 3), 0, (int)procmax, 0, 
                    (int)(procmax / 3), "w(r) = ", "");
                if (ifi == false)
                    goto retth;
            });
            thread.Name = "TwoGraph";
            thread.Start();
                return true;
        }
    }
}
