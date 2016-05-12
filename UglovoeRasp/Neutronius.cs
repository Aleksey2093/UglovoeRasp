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
    public class Neutron_struct
    {
        public double x = -1;
        public double y = -1;
        public double z = -1;
        public double radius = -1;
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
            set { x1 = value; }
        }
        /// <summary>
        /// Возвращает или задает Ymax конца координат. Доступно для чтения и записи.
        /// </summary>
        static public double ymax
        {
            get { return y1; }
            set { y1 = value; }
        }
        /// <summary>
        /// Возвращает или задает Zmax конца координат. Доступно для чтенения и записи.
        /// </summary>
        static public double zmax
        {
            get { return z1; }
            set { z1 = value; }
        }
    }
    class Neutronius
    {
        private static MainWindow mainwindow;

        public void setParentWindow(MainWindow mw)
        {
            mainwindow = mw;
        }

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
            Neutron_struct[] neutrons = new Neutron_struct[n];
            Random randoms = new Random(rand);
            Parallel.For(0,neutrons.Length,(i,state)=>
            {
                Random random = randoms;
            reti:
            double _r = random.Next(0,(int)dr+1) + Math.Round(random.NextDouble(),6);
                double w_r = ((3 * Math.Pow(_r, 2)) / (Math.Pow(dr, 3)));
                double w_ = Math.Exp(-Math.Pow((_r / dr), 3));
                w_r = w_r * w_;
                w_r *= 10;
                if (w_r < 0.1)
                {
                    if (_r == 0)
                    {
                        int randi = DateTime.Now.Year + DateTime.Now.DayOfYear + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Millisecond + i;
                        randi *= (i+1);
                        random = new Random(randi);
                    }
                    goto reti;
                }
                neutrons[i] = new Neutron_struct();
                neutrons[i].radius = w_r;
            });
            return neutrons;
        }
        /// <summary>
        /// Случайным образом заполняет координаты нейтров и проводит проверку на пересения. Нейтронов с одинаковыми координатыми по умолчанию быть не может.
        /// </summary>
        /// <param name="neutrons">Массив координат нейтронов</param>
        /// <param name="prov">Нужно ли проводить проверку</param>
        /// <returns>Массив нейтронов</returns>
        /// <exception cref="Деление на нуль"></exception>
        public bool randomGenXYZ(Neutron_struct[] neutrons, bool prov)
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
            bool res = true;
            if (prov)
            {
                res = getNeutoronsNotConnect(neutrons);
            }
            return res;
        }

        struct ResSum
        {
            public bool sumconnect;
            public int index;
        }

        private ResSum getsumConnect(int index, Neutron_struct[] neutrons)
        {
            bool sumconnects = false;
            Parallel.For(index, neutrons.Length - 1, (i, statei) =>
            {
                for (int j = i + 1; j < neutrons.Length; j++)
                {
                    double L = Math.Pow((neutrons[j].x - neutrons[i].x), 2)
                        + Math.Pow((neutrons[j].y - neutrons[i].y), 2)
                        + Math.Pow((neutrons[j].z - neutrons[i].z), 2);
                    L = Math.Sqrt(L);
                    if (Math.Abs(L) < neutrons[i].radius + neutrons[j].radius && sumconnects == false)
                    {
                        sumconnects = true;
                        index = i;
                        statei.Break();
                        break;
                    }
                }
            });
            ResSum r = new ResSum();
            r.sumconnect = sumconnects;
            r.index = index;
            return r;
        }

        private bool deleteConnectOtherNeutron(int index, Neutron_struct[] neutrons, bool metod)
        {
            bool ifi = false;
            if (metod)
            {
                Parallel.For(index + 1, neutrons.Length, (j, statej) =>
                {
                    double L = Math.Pow((neutrons[j].x - neutrons[index].x), 2)
                        + Math.Pow((neutrons[j].y - neutrons[index].y), 2)
                        + Math.Pow((neutrons[j].z - neutrons[index].z), 2);
                    L = Math.Sqrt(L);
                    if (L < neutrons[index].radius + neutrons[j].radius)
                    {
                        ifi = true;
                        statej.Break();
                    }
                });
                if (ifi == false)
                {
                    Parallel.For(0, index, (j, statej) =>
                    {
                        double L = Math.Pow((neutrons[j].x - neutrons[index].x), 2)
                            + Math.Pow((neutrons[j].y - neutrons[index].y), 2)
                            + Math.Pow((neutrons[j].z - neutrons[index].z), 2);
                        L = Math.Sqrt(L);
                        if (L < neutrons[index].radius + neutrons[j].radius)
                        {
                            ifi = true;
                            statej.Break();
                        }
                    });
                }
            }
            else
            {
            restart0:
                int kolvo = 0; List<int> idot = new List<int>();
                Parallel.For(index + 1, neutrons.Length, (j, statej) =>
                {
                    double L = Math.Pow((neutrons[j].x - neutrons[index].x), 2)
                        + Math.Pow((neutrons[j].y - neutrons[index].y), 2)
                        + Math.Pow((neutrons[j].z - neutrons[index].z), 2);
                    L = Math.Sqrt(L);
                    if (L < neutrons[index].radius + neutrons[j].radius)
                    {
                        idot.Add(j);
                    }
                });
                Parallel.For(0, index, (j, statej) =>
                {
                    double L = Math.Pow((neutrons[j].x - neutrons[index].x), 2)
                        + Math.Pow((neutrons[j].y - neutrons[index].y), 2)
                        + Math.Pow((neutrons[j].z - neutrons[index].z), 2);
                    L = Math.Sqrt(L);
                    if (L < neutrons[index].radius + neutrons[j].radius)
                    {
                        idot.Add(j);
                    }
                });
                kolvo++;
                if (kolvo > 10000)
                    return false;
                Parallel.ForEach(idot, (i, state) =>
                    {
                        neutrons[i] = getNewValue(neutrons[i]);
                    });
                goto restart0;
            }
            return ifi;
        }

        private bool getNeutoronsNotConnect(Neutron_struct[] neutrons)
        {
            int maxrestartmetod = 0;
            int restartmetod = 0;
            int index = 0;
            start1:
            for (int i = 0; i < neutrons.Length - 1; i++)
            {
                int swap = i;
                Parallel.For(0, neutrons.Length, (j, state) =>
                {
                    if (neutrons[j].radius > neutrons[swap].radius)
                    {
                        swap = j;
                    }
                });
                Neutron_struct sw = neutrons[i];
                neutrons[i] = neutrons[swap];
                neutrons[swap] = sw;
            }
        start0:
            restartmetod++;
            DateTime chetchik = DateTime.Now;
            ResSum sum = getsumConnect(index, neutrons);
            bool sumconnects = sum.sumconnect;
            index = sum.index;
            Console.WriteLine("Подсчет суммы занял - " + (DateTime.Now - chetchik).ToString());
            chetchik = DateTime.Now;
            mainwindow.newValueProgresBar();
                if (sumconnects == false)
                {
                    if (index != 0)
                    {
                        index = 0;
                        goto start0;
                    }
                    return true;
                }
                if (restartmetod > Properties.Settings.Default.restarnfor)
                {
                    maxrestartmetod++;
                    restartmetod = 0;
                    new System.Threading.Thread(delegate() { MessageBox.Show("Проход разбиения по просранству №" + maxrestartmetod + "(maxrestartmetod).", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); }).Start();
                    Random rand = new Random(DateTime.Today.Millisecond*DateTime.Today.Minute);

                    if (deleteConnectOtherNeutron(index, neutrons, false) == false)
                    {
                        for (int i = 0; i < rand.Next(5, 20); i++)
                        {
                            int c = rand.Next(neutrons.Length);
                            neutrons[c] = getNewValue(neutrons[c]);
                        }
                    }
                    goto start1;
                }
                else if (neutrons.Length >= 10000000)
                    new System.Threading.Thread(delegate() { MessageBox.Show("Проход разбиения по просранству №" + restartmetod + "(restartmetod).", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); }).Start();
            int restartswap = 0;
            ret0:
            bool ifi = deleteConnectOtherNeutron(index,neutrons,true);
            if (ifi)
            {
                restartswap++;
                if (restartswap > Properties.Settings.Default.restarnfor)
                {
                    goto start0;
                }
                neutrons[index] = getNewValue(neutrons[index]);
                goto ret0;
            }
            Console.WriteLine("Проверка пересечений заняла - " + (DateTime.Now - chetchik).ToString());
            goto start0;
        }

        /// <summary>
        /// получить новое значение координат нейтрона. Возвращает нейтрон.
        /// </summary>
        /// <param name="neutron">Нейтрон координаты которого нужно изменить</param>
        /// <returns></returns>
        private Neutron_struct getNewValue(Neutron_struct neutron)
        {
            int rand = DateTime.Now.DayOfYear + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
            rand = Math.Abs(rand + (int)neutron.x + (int)neutron.y + (int)neutron.z + (int)neutron.radius);
            rand = rand * DateTime.Now.Millisecond;
            Random random = new Random(rand);
        ret1:
            neutron.x = random.Next((int)BoxNeutoron.x, (int)BoxNeutoron.xmax);
            neutron.x += random.NextDouble();
            if (!getBoolProvKordNeuBox(neutron.x, neutron.radius, BoxNeutoron.x, BoxNeutoron.xmax))
                goto ret1;
        ret2:
            neutron.y = random.Next((int)BoxNeutoron.y, (int)BoxNeutoron.ymax);
            neutron.y += random.NextDouble();
            if (!getBoolProvKordNeuBox(neutron.y, neutron.radius, BoxNeutoron.y, BoxNeutoron.ymax))
                goto ret2;
        ret3:
            neutron.z = random.Next((int)BoxNeutoron.z, (int)BoxNeutoron.zmax);
            neutron.z += random.NextDouble();
            if (!getBoolProvKordNeuBox(neutron.z, neutron.radius, BoxNeutoron.z, BoxNeutoron.zmax))
                goto ret3;
            return neutron;
        }

        public bool boxMax(Neutron_struct[] neutronsmass, double density)
        {
            double v_shre = 0;
            foreach(var neu in neutronsmass)
            {
                v_shre += 4.0 / 3.0 * Math.PI * Math.Pow(neu.radius, 3);
            }
            double v_shre2 = v_shre / density;
            double rebro = Math.Pow(v_shre2, 1.0 / 3.0);
            Console.WriteLine(v_shre + "  " + v_shre2 + "   " + rebro);

            BoxNeutoron.xmax = rebro;
            BoxNeutoron.ymax = rebro;
            BoxNeutoron.zmax = rebro;

            return true;
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
