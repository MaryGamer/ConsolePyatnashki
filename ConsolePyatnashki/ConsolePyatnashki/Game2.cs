using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePyatnashki
{
    class Game2 : Game, IPlayable
    {
        public bool IsFinished
        {
            get
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if ((field[i, j] != (i * size + j + 1) && (i != size - 1 || j != size - 1)) ||
                            (field[i, j] != 0 && i == size - 1 && j == size - 1)) return false;
                    }
                }
                return true;
            }
        }

        public Game2(params int[] val)
        {
            CheckIt(val);

            #region старый код
            //int size = (int)Math.Sqrt(val.Length);
            //int[,] mas = new int[size, size];

            //for (int i = 0; i < size; i++)
            //{
            //    for (int j = 0; j < size; j++)
            //    {
            //        mas[i, j] = val[i * size + j];
            //    }
            //}

            //List<int> lst = new List<int>();
            //for (int i = 0; i < size; i++)
            //{
            //    for (int j = 0; j < size; j++)
            //    {
            //        lst.Add(mas[i, j]);
            //    }
            //}
            #endregion

            this.Inicialize(val);
            Randomize(10);
        }

        public void Randomize(int iter)
        {
            for (int k = 0; k < iter; k++)
            {
                List<Point> neigbours = new List<Point>();
                Point ZeroPos = new Point(-1, -1);
                Point SwapPoz = new Point(-1, -1);

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (field[i, j] == 0)
                        {
                            ZeroPos = new Point(j, i);
                            if (i - 1 >= 0) neigbours.Add(new Point(j, i - 1));
                            if (i + 1 <= size - 1) neigbours.Add(new Point(j, i + 1));
                            if (j - 1 >= 0) neigbours.Add(new Point(j - 1, i));
                            if (j + 1 <= size - 1) neigbours.Add(new Point(j + 1, i));
                        }
                    }
                }

                if (neigbours.Count > 0)
                {
                    Random rnd = new Random(DateTime.Now.Millisecond);
                    SwapPoz = neigbours[rnd.Next(neigbours.Count - 1)];
                    swap(ref field[ZeroPos.Row, ZeroPos.Column], ref field[SwapPoz.Row, SwapPoz.Column]);
                }
                else
                {
                    throw new ArgumentException("Ошибка в процессе рандомизации поля");
                }
            }
        }
    }
}
