using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePyatnashki
{
    class Turn
    {
        public int Num;
        public Point A;
        public Point B;

        public Turn(int n, Point a, Point b)
        {
            this.Num = n;
            this.A = a;
            this.B = b;
        }
    }
}
