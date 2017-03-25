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

        public ConsoleGameUI(IPlayable game)
        {
            gmb = game;
            Console.WriteLine(string.Format("Тип игры определен как: {0}", gmb.GetType()));
        }

        public void Print()
        {
            if (gmb is Game3)
            {
                Console.WriteLine(string.Format("Ход № {0}", (gmb as Game3).NumTurns()));
            }
            else
            {
                Console.WriteLine("Следующий ход");
            }
            for (int i = 0; i < (gmb as Game2).Length; i++)
            {
                for (int j = 0; j < (gmb as Game2).Length; j++)
                {
                    Console.Write(string.Format("{0}\t", (gmb as Game2)[i, j]));
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
                        if (gmb is Game3)
                        {
                            Console.WriteLine(string.Format("Откат на {0} ходов назад", val * -1));
                            (gmb as Game3).Reverse(val * -1);
                        }
                        else
                            Console.WriteLine("Неверный ввод! (откат назад для Game2 не поддерживается");
                    }
                    else
                    {
                        gmb.Shift(val);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("Неправильный ход! {0}", ex.Message));
                }
                this.Print();
            }
            if (gmb is Game3)
            {
                Console.WriteLine("Поздравляем! Игра завершена за {0} ходов!", (gmb as Game3).NumTurns());
            }
            else
            {
                Console.WriteLine("Поздравляем! Игра завершена!");
            }
        }
    }
}
