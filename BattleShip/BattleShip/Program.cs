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
            Player player = new Player("Marco");
            Map map = new Map();
            PatrolBoat patrolBoat = new PatrolBoat();
            AircraftCarrier air = new AircraftCarrier();
            Battleship battle = new Battleship();
            Destroyer destroyer = new Destroyer();
            Submarine sub = new Submarine();

            map.fillMap(10, 10);
            map.drawMap();
            Console.WriteLine();

           player.moveShipOnMap(map, battle);

            //patrolBoat.AddShipToMap(map);
            //air.AddShipToMap(map);
            //battle.AddShipToMap(map);
            //battle.moveShipDown(map);
            //battle.moveShipUp(map);
            //battle.moveShipRight(map);
            //battle.moveShipRight(map);

            //battle.moveShipLeft(map);
            //destroyer.AddShipToMap(map);
            //sub.AddShipToMap(map);

           //sub.moveShipRight(map);
           //sub.moveShipDown(map);
           // sub.moveShipDown(map);
            //sub.moveShipRight(map);
           // sub.moveShipLeft(map);

            Console.ReadLine();
        }
    }
}
