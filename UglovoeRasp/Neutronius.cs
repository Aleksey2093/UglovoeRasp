using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Угловое_распределение
{

    /// <summary>
    /// структура предзназначенная для удобной работы с координатами нейтрона в пространстве
    /// </summary>
    class Neutron_struct
    {
        public double x;
        public double y;
        public double z;
        public double radius;
    };

    class Neutronius
    {
        public Neutron_struct[] randomInW_R(int n, double dr)
        {
            int rand = DateTime.Now.Year - DateTime.Now.Day - DateTime.Now.Month;
            rand += DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Millisecond;
            rand += (int)Math.Truncate(dr);
            rand = Math.Abs(rand);
            Random random = new Random(rand);
            Neutron_struct[] neutrons = new Neutron_struct[n];
            Parallel.For(0, n, (i, state) =>
            {

                double w_r = random.Next(0, 10);
                w_r = ((3 * Math.Pow(w_r, 2)) / (Math.Pow(dr, 3)))
                    * Math.Exp(-Math.Pow((w_r / dr), 3));
                neutrons[i] = new Neutron_struct();
                neutrons[i].radius = w_r;
            });
            return neutrons;
        }
    }
}
