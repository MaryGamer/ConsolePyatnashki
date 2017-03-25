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
        History history;

        public Game3(params int[] val) : base(val)
        {
            history = new History();
            num = 0;
        }

        public int NumTurns()
        {
            return num;
        }

        public void Reverse(int back)
        {
            List<Turn> turns = history.GetHist();
            int count = turns.Count;

            if (back > count) throw new Exception
                (string.Format("Нельзя откатиться назад на число ходов более чем {0}", count));

            for (int i = count - 1; i >= count - back; i--)
            {
                Point A = turns[i].A;
                Point B = turns[i].B;

                int val = field[A.Row, A.Column] > 0 ?
                    field[A.Row, A.Column] : field[B.Row, B.Column];

                base.Shift(val);
                history.DeleteLast();
            }
            num = num - back;
        }

        public override void Shift(int value)
        {
            base.Shift(value);
            num++;
            history.AddTurn(num, base.GetLocation(0), base.GetLocation(value));
        }

    }
}
