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
            Map map = new Map();
            PatrolBoat patrolBoat = new PatrolBoat();
            AircraftCarrier air = new AircraftCarrier();
            Battleship battle = new Battleship();
            Destroyer destroyer = new Destroyer();
            Submarine sub = new Submarine();

            map.fillMap(10, 10);
            map.drawMap();
            Console.WriteLine(); 

            //patrolBoat.AddShipToMap(map);
            //air.AddShipToMap(map);
            //battle.AddShipToMap(map);
            //destroyer.AddShipToMap(map);
            //sub.AddShipToMap(map);
            

            Console.ReadLine();
        }
    }
}
