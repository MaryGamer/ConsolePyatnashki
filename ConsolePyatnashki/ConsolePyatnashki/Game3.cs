using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePyatnashki
{
    class Game3 : Game2, IPlayable
    {
        int num;
        History hst;

        public Game3(params int[] val) : base(val)
        {
            hst = new History();
            num = 0;
        }

        public int NumTurns()
        {
            return num;
        }

        public void Reverse(int back)
        {
            List<Turn> turns = hst.GetHist();
            int cnt = turns.Count;
            for (int i = cnt - 1; i >= cnt - back; i--)
            {
                Point A = turns[i].A;
                Point B = turns[i].B;

                int val = base.field[A.Row, A.Column] > 0 ?
                    base.field[A.Row, A.Column] : base.field[B.Row, B.Column];
                base.Shift(val);
                hst.DeleteLast();
            }
            num = num - back;
        }

        public override void Shift(int value)
        {
            base.Shift(value);
            num++;
            hst.AddTurn(num, base.GetLocation(0), base.GetLocation(value));
        }

    }
}
