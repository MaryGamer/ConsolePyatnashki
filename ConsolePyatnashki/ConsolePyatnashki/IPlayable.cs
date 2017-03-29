using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePyatnashki
{
    interface IPlayable
    {
        void Randomize(int iter);

        bool IsFinished { get; }

        void Shift(int value);

        int Length { get; }

        int this[int x, int y] { get; }
    }
}
