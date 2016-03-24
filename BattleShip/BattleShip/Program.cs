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

            Player player1 = new Player("Player 1", 1);
            Player player2 = new Player("Player 2", 2);


            gamePlay.startMenu(player1);

            gamePlay.gameMenu(player2);

            gamePlay.turnSwitcher(player1, player2);

            Console.WriteLine();

            Console.ReadLine();

            ///<remarks>
            /// Things to work on tomorrow:
            /// 3. If ships overlap, repopulate where other ships were stored.
            ///
            ///</remarks>

        }
    }
}
