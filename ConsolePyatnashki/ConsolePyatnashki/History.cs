using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePyatnashki
{
    class History
    {
        List<Turn> hist = new List<Turn>();

        public void AddTurn(int n, Point a, Point b)
        {
            hist.Add(new Turn(n, a, b));
        }

        public void DeleteLast()
        {
            hist.Remove(hist[hist.Count - 1]);
        }

        public List<Turn> GetHist()
        {
            return this.hist;
        }

        public void Clear()
        {
            hist = new List<Turn>();
        }
    }
}
