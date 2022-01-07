using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopr.Forms.Pre
{
    public class Plank
    {
        public double L = 0;
        public double A = 0;
        public double E = 0;
        public double Res = 0;

        public double q = 0;

        public static Plank operator +(Plank pl1, Plank pl2)
        {
            if (pl2.L != 0)
            {
                pl1.L = pl2.L;
            }
            if (pl2.A != 0)
            {
                pl1.A = pl2.A;
            }
            if (pl2.E != 0)
            {
                pl1.E = pl2.E;
            }
            if (pl2.Res != 0)
            {
                pl1.Res = pl2.Res;
            }
            if (pl2.q != 0)
            {
                pl1.q = pl2.q;
            }

            return pl1;
        }

        public string serialize() { return L.ToString() + " " + A.ToString() + " " + E.ToString() + " " + Res.ToString() + " " + q.ToString(); }

    }
}
