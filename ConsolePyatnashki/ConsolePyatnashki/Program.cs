using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePyatnashki
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ConsoleGameUI MyGame = new ConsoleGameUI(1, 3, 2, 4, 5, 0, 7, 8, 6);
                MyGame.Print();
                MyGame.StartGame();

                #region старый код
                //Game3 gmb = new Game3(1, 3, 2, 4, 5, 0, 7, 8, 6);

                //Print(gmb);

                //while (!gmb.IsFinished)
                //{
                //    Console.Write("Какое значение двигаем? ");
                //    int val = int.Parse(Console.ReadLine());

                //    try
                //    {
                //        if (val < 0)
                //        {
                //            gmb.Reverse(val * -1);
                //        }
                //        else
                //        {
                //            gmb.Shift(val);
                //        }

                //    }
                //    catch (Exception ex)  // возможные ошибки в ходе игры
                //    {
                //        Console.WriteLine(string.Format("Неправильный ход! {0}", ex.Message));
                //    }
                //    Print(gmb);
                //}
                //Console.WriteLine("Поздравляем! Игра завершена за {0} ходов!", gmb.NumTurns());
                #endregion
            }
            catch (Exception ex) //возможные ошибки при создании игры
            {
                Console.WriteLine(string.Format("Критическая ошибка! {0}", ex.Message));
            }
            Console.ReadKey();
        }
    }
}
