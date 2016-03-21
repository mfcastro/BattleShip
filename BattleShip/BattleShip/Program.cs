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
           gamePlay.startMenu();
            Player player = new Player("Marco");
            Map map = new Map();
            //PatrolBoat patrolBoat = new PatrolBoat();
            AircraftCarrier air = new AircraftCarrier();
            //Battleship battle = new Battleship();
            //Destroyer destroyer = new Destroyer();
            // Submarine sub = new Submarine();


            Console.WriteLine();
            map.fillMap(11, 11);
             map.drawMap();
            Console.WriteLine();

          player.moveShipOnMap(map, air);


            Console.ReadLine();

            ///<remarks>
            /// Things to work on tomorrow:
            /// 1. figure out how to set ship on a spot and move to next piece
            /// 2. Don't allow ship to move outside of edges 
            /// 3. If ships overlap, repopulate where other ships were stored.
            /// 4. When ship is verical or has been verticalit won't go to next piece after hitting "q". 
            ///    Only when it is horizontal.
            /// 4. Create a second player and have a turn switcher
            /// 5. allow player to select a coordiate
            /// 6. Show hit/miss on map
            /// 7. display player 2's black map.
            /// 8. When rotaing back to horizontal, it doesn't always change the A's back to ?'s 
            ///
            ///</remarks>






        }
    }
}
