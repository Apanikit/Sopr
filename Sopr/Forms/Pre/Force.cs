using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopr.Forms.Pre
{
    public class Force
    {
        public double L;
        public double F;
        public Force()
        {
            L = 0;
            F = 0;
        }

        public Force(Force original)
        {
            L = original.L;
            F = original.F;
        }
    }

}
