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
           //gamePlay.startMenu();
            Player player = new Player("Marco");
            Map map = new Map();
            //PatrolBoat patrolBoat = new PatrolBoat();
            AircraftCarrier air = new AircraftCarrier();
            //Battleship battle = new Battleship();
            //Destroyer destroyer = new Destroyer();
           // Submarine sub = new Submarine();



            map.fillMap(11, 11);
            map.drawMap();
            Console.WriteLine();

           player.moveShipOnMap(map, air);


            Console.ReadLine();
        }
    }
}
