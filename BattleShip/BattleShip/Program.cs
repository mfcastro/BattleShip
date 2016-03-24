using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Program
    {
        static void Main(string[] args)
        {
            GamePlay gamePlay = new GamePlay();
            gamePlay.startGame();


            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Hello ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("World");

            Console.ResetColor();
            Console.WriteLine("one");
            Console.ReadLine();



            Console.WriteLine();
            
        }
    }
}
