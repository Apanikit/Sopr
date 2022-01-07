using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopr.Forms.Pre
{
    public class Node
    {
        public double F;
        public bool Support;

        public Node()
        {
            F = 0;
            Support = false;
        }

        public Node(Node original)
        {
            F = original.F;
            Support = original.Support;
        }

        public static Node operator +(Node nod1, Node nod2)
        {
            if(nod2.F != 0) nod1.F = nod2.F;
            if (nod2.Support) nod1.Support = nod2.Support;
            return nod1;
        }

        public string serialize() 
        {
            string sup;

            if (Support) sup = "1";
            else sup = "0";

            return F.ToString() + " " + sup ; 
        }

    }
}
