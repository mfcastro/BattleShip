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

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
