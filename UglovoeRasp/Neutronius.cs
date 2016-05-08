using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Угловое_распределение
{

    /// <summary>
    /// класс для удобной работы с координатами нейтрона в пространстве
    /// </summary>
    class Neutron_struct
    {
        public double x;
        public double y;
        public double z;
        public double radius;
    };
    /// <summary>
    /// класс границ пространства внутри которого находятся нейтроны
    /// </summary>
    static class BoxNeutoron
    {
        static double x0 = 0;
        static double y0 = 0;
        static double z0 = 0;

        /// <summary>
        /// Возвращает Х начала координат. Доступно только для чтения.
        /// </summary>
        static public double x
        {
            get { return x0; }
        }
        /// <summary>
        /// Возвращает Y начала координат. Доступно только для чтения.
        /// </summary>
        static public double y
        {
            get { return y0; }
        }
        /// <summary>
        /// Возвращает Z начала координат. Доступно только для чтения.
        /// </summary>
        static public double z
        {
            get { return z0; }
        }

        static double x1 = 0;
        static double y1 = 0;
        static double z1 = 0;

        /// <summary>
        /// Возвращает или задает Xmax конца координат. Доступно для чтения и записи.
        /// </summary>
        static public double xmax
        {
            get { return x1; }
            set { if (edit) x1 = value; }
        }
        /// <summary>
        /// Возвращает или задает Ymax конца координат. Доступно для чтения и записи.
        /// </summary>
        static public double ymax
        {
            get { return y1; }
            set { if (edit) y1 = value; }
        }
        /// <summary>
        /// Возвращает или задает Zmax конца координат. Доступно для чтенения и записи.
        /// </summary>
        static public double zmax
        {
            get { return z1; }
            set { if (edit) z1 = value; }
        }

        static bool edit = true;

        public static bool editing
        {
            get { return edit; }
            set { edit = value; }
        }

        /// <summary>
        /// Случайным образом создает границы для пространства в котором находятся нейтроны
        /// </summary>
        /// <param name="random">Генератор псевдослучайных чисел</param>
        /// <param name="n">Число зерен</param>
        /// <param name="density">Плость зерен</param>
        /// <returns>true - границы заданы, false - границы заданы ранее</returns>
        public static bool genMaxBoxXYZ(Random random, int n, double density)
        {
            int i, j;
            i = j = (int)(n/density);
            xmax = random.Next(i, j);
            ymax = random.Next(i, j);
            zmax = random.Next(i, j);
            editing = false;
            return true;
        }
    }
    class Neutronius
    {
        /// <summary>
        /// Генерирует массив слуайных радиусов
        /// </summary>
        /// <param name="n">Число зерен</param>
        /// <param name="dr">R большое</param>
        /// <returns>Возвращает массив Neutron_struct с заполненным полем 'r'</returns>
        /// <exception cref="Деление на нуль при генерации W(r)">Возможно деление на нуль при генерации очередного значения W(r)</exception>
        public Neutron_struct[] randomInW_R(int n, double dr)
        {
            int rand = DateTime.Now.Year - DateTime.Now.Day - DateTime.Now.Month;
            rand = rand - DateTime.Now.Hour - DateTime.Now.Minute - DateTime.Now.Millisecond;
            rand += (int)Math.Truncate(dr);
            rand = Math.Abs(rand);
            Random random = new Random();
            Neutron_struct[] neutrons = new Neutron_struct[n];
            double r_r = 0;
            for (int i = 0; i < n; i++)
            {
                r_r = r_r + 0.005;
                if (r_r > 5)
                    r_r = 0.1;
            reti:
            double _r = random.Next(0,9) + random.NextDouble(); 
                double w_r = ((3 * Math.Pow(_r, 2)) / (Math.Pow(dr, 3)));
                double w_ = Math.Exp(-Math.Pow((_r / dr), 3));
                w_r = w_r * w_;
                w_r *= 10;
                if (w_r < 0.1)
                    goto reti;
                neutrons[i] = new Neutron_struct();
                neutrons[i].radius = w_r;
            }//);
            return neutrons;
        }
        /// <summary>
        /// Случайным образом заполняет координаты нейтров и проводит проверку на пересения. Нейтронов с одинаковыми координатыми по умолчанию быть не может.
        /// </summary>
        /// <param name="neutrons">Массив координат нейтронов</param>
        /// <param name="prov">Нужно ли проводить проверку</param>
        /// <returns>Массив нейтронов</returns>
        /// <exception cref="Деление на нуль"></exception>
        public Neutron_struct[] randomGenXYZ(Neutron_struct[] neutrons, bool prov)
        {
            int rand = DateTime.Now.Year - DateTime.Now.Day - DateTime.Now.Month;
            rand -= (DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Millisecond);
            rand -= DateTime.Now.DayOfYear;
            rand = Math.Abs(rand);
            Random random = new Random(rand);
            Parallel.For(0, neutrons.Length, (i, statei) =>
            {
                random = new Random(rand + i);
            ret0:
                bool ifi = false;
            ret1:
                double xx = random.Next((int)BoxNeutoron.x, (int)BoxNeutoron.xmax);
                xx += random.NextDouble();
                neutrons[i].x = xx;
                if (!getBoolProvKordNeuBox(neutrons[i].x, neutrons[i].radius, BoxNeutoron.x, BoxNeutoron.xmax))
                    goto ret1;
            ret2:
                neutrons[i].y = random.Next((int)BoxNeutoron.y, (int)BoxNeutoron.ymax);
                neutrons[i].y += random.NextDouble();
                if (!getBoolProvKordNeuBox(neutrons[i].y, neutrons[i].radius, BoxNeutoron.y, BoxNeutoron.ymax))
                    goto ret2;
            ret3:
                neutrons[i].z = random.Next((int)BoxNeutoron.z, (int)BoxNeutoron.zmax);
                neutrons[i].z += random.NextDouble();
                if (!getBoolProvKordNeuBox(neutrons[i].x, neutrons[i].radius, BoxNeutoron.x, BoxNeutoron.xmax))
                    goto ret3;
                if (ifi)
                    goto ret0;
            });
            if (prov)
            {
                neutrons = getNeutoronsNotConnect(neutrons);
            }
            return neutrons;
        }

        private Neutron_struct[] getNeutoronsNotConnect(Neutron_struct[] neutrons)
        {
        start0:
            int sumconnects = 0; DateTime chetchik = DateTime.Now;
            Parallel.For(0, neutrons.Length - 1, (i, statei) =>
            //for (int i = 0; i < neutrons.Length-1;i++ )
            {
                var neutron = neutrons[i];
                Parallel.For(i + 1, neutrons.Length, (j, statej) =>
                //for (int j = i + 1; j < neutrons.Length;j++ )
                {
                    var t2 = neutrons[j];
                    double L = Math.Pow((t2.x - neutron.x), 2)
                        + Math.Pow((t2.y - neutron.y), 2)
                        + Math.Pow((t2.z - neutron.z), 2);
                    L = Math.Sqrt(L);
                    if (Math.Abs(L) < neutron.radius + t2.radius)
                    {
                        sumconnects++;
                        statei.Break();
                    }
                });
            });
            Console.WriteLine("Подсчет суммы " + sumconnects + " занял - " + (DateTime.Now - chetchik).ToString());
            chetchik = DateTime.Now;
            if (sumconnects == 0)
                return neutrons;
            for (int i = 0; i < neutrons.Length; i++)
            {
                var neutron = neutrons[i];
            ret0:
                bool ifi = false;
                Parallel.For(0, neutrons.Length, (j, statej) =>
                    {
                        if (j != i)
                        {
                            var t2 = neutrons[j];
                            double L = Math.Pow((t2.x - neutron.x), 2)
                                + Math.Pow((t2.y - neutron.y), 2)
                                + Math.Pow((t2.z - neutron.z), 2);
                            L = Math.Sqrt(L);
                            if (L < neutron.radius + t2.radius)
                            {
                                ifi = true;
                                statej.Break();
                            }
                        }
                    });
                if (ifi)
                {
                    int rand = DateTime.Now.Year - DateTime.Now.Day - DateTime.Now.Hour - DateTime.Now.Minute - DateTime.Now.Millisecond - DateTime.Now.Second;
                    rand = Math.Abs(rand);
                    Random random = new Random(rand);
                ret1:
                    neutron.x = random.Next((int)BoxNeutoron.x, (int)BoxNeutoron.xmax);
                    neutron.x += random.NextDouble();
                    if (!getBoolProvKordNeuBox(neutrons[i].x, neutron.radius, BoxNeutoron.x, BoxNeutoron.xmax))
                        goto ret1;
                ret2:
                    neutron.y = random.Next((int)BoxNeutoron.y, (int)BoxNeutoron.ymax);
                    neutron.y += random.NextDouble();
                    if (!getBoolProvKordNeuBox(neutrons[i].y, neutron.radius, BoxNeutoron.y, BoxNeutoron.ymax))
                        goto ret2;
                ret3:
                    neutron.z = random.Next((int)BoxNeutoron.z, (int)BoxNeutoron.zmax);
                    neutron.z += random.NextDouble();
                    if (!getBoolProvKordNeuBox(neutron.x, neutron.radius, BoxNeutoron.x, BoxNeutoron.xmax))
                        goto ret3;
                    goto ret0;
                }
            }
            Console.WriteLine("Проверка пересечений заняля - " + (DateTime.Now - chetchik).ToString());
            goto start0;
        }

        /// <summary>
        /// Проверка вхождения координаты в пространство
        /// </summary>
        /// <param name="kord">координата нейтрона</param>
        /// <param name="radius">радиус нейтрона</param>
        /// <param name="min">минимальманое значение пространства по этой координате</param>
        /// <param name="max">максимальное значение пространства по этой координате</param>
        /// <returns>true - все хорошо, false - выходит за границу </returns>
        private bool getBoolProvKordNeuBox(double kord, double radius, double min, double max)
        {
            if (kord >= min && kord <= max)
            {
                if (kord - radius < min)
                    return false;
                if (kord + radius > max)
                    return false;
                return true;
            }
            else
                return false;
        }
    }
}
