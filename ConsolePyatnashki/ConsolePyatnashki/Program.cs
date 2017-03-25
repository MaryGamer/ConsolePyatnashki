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
                var gmb = new Game3(1, 3, 2, 4, 5, 0, 7, 8, 6);
                ConsoleGameUI MyGame = new ConsoleGameUI(gmb);
                MyGame.Print();
                MyGame.StartGame();
            }
            catch (Exception ex) //возможные ошибки при создании игры
            {
                Console.WriteLine(string.Format("Критическая ошибка! {0}", ex.Message));
            }
            Console.ReadKey();
        }
    }
}
