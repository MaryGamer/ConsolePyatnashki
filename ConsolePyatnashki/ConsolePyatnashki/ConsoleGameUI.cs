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
        }

        public void Print()
        {
            Console.WriteLine("Следующий ход");

            for (int i = 0; i < gmb.Length; i++)
            {
                for (int j = 0; j < gmb.Length; j++)
                {
                    Console.Write(string.Format("{0}\t", gmb[i, j]));
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
                    if (val > 0)
                    {
                        gmb.Shift(val);
                        this.Print();
                    }
                    else
                    {
                        Console.WriteLine("Неверный ввод. Повторите.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("Неправильный ход! {0}", ex.Message));
                }

            }
            Console.WriteLine("Поздравляем! Игра завершена!");
        }
    }
}
