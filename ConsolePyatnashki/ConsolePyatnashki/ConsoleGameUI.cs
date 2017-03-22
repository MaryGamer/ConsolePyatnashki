using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePyatnashki
{
    class ConsoleGameUI
    {
        IPlayable gmb;

        public ConsoleGameUI(params int[] val)
        {
            gmb = new Game3(val);
        }

        public void Print()
        {
            Console.WriteLine(string.Format("Ход № {0}", (gmb as Game3).NumTurns()));
            for (int i = 0; i < (gmb as Game3).Length; i++)
            {
                for (int j = 0; j < (gmb as Game3).Length; j++)
                {
                    Console.Write(string.Format("{0}\t", (gmb as Game3)[i, j]));
                }
                Console.WriteLine();
            }
        }

        public void StartGame()
        {
            while (!gmb.IsFinished)
            {
                Console.Write("Какое значение двигаем? ");
                int val = int.Parse(Console.ReadLine());

                try
                {
                    if (val < 0)
                    {
                        (gmb as Game3).Reverse(val * -1);
                    }
                    else
                    {
                        gmb.Shift(val);
                    }
                }
                catch (Exception ex)  // перехватываем возможные ошибки в ходе  игры
                {
                    Console.WriteLine(string.Format("Неправильный ход! {0}", ex.Message));
                }
                this.Print();
            }
            Console.WriteLine("Поздравляем! Игра завершена за {0} ходов!", (gmb as Game3).NumTurns());
        }
    }
}
