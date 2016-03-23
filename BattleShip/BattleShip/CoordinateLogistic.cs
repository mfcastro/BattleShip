using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class CoordinateLogistic
    {

        Dictionary<string, int> nameOfShip = new Dictionary<string, int>() { {"Aircraft Carrier",0 }, {"Battleship",1 }, {"Submarine",2 }, {"Destroyer",3 }, {"Patrol Boat",4 } };

        public List<List<Tuple<int, int>>> shipCoordinates = new List<List<Tuple<int, int>>>();

        public List<Tuple<int, int>> AllCoordinates = new List<Tuple<int, int>>();

        public List<Tuple<int, int>> hitCoordinates = new List<Tuple<int, int>>();



        public void saveShipCoordinate(Map map, Ship ship)
        {

            if (ship.horizontal == true)
            {
                for (int shipSection = 0; shipSection < ship.sizeOfShip; shipSection++)
                {
                    addCoordinatesToList(ship, shipSection);
                }
            }
            else if (ship.vertical == true)
            {
                for (int shipSection = 0; shipSection < ship.sizeOfShip; shipSection++)
                {
                    addCoordinatesToList(ship, shipSection);
                }
            }
        }

        public void addCoordinatesToList(Ship ship, int shipSection)
        {
            shipCoordinates.Add(new List<Tuple<int, int>> { });

            int shipNumber = nameOfShip[ship.shipName];

            Console.WriteLine("Ship name : {0} ship number: {1}", ship.shipName, shipNumber); // temporary




            if(ship.horizontal == true)
            {
                 var coordinates = new Tuple<int, int>(ship.yCoordinate, ship.xCoordinate + shipSection);
                shipCoordinates[0].Add(coordinates); // will need to change index to shipNumber. For now leave it.

                //will have to figure out how to access all the components
            }
            else if(ship.vertical == true)
            {
                 var coordinates = new Tuple<int, int>(ship.yCoordinate + shipSection, ship.xCoordinate);
                shipCoordinates[0].Add(coordinates);
            }
           


        }

        public void printShipCoordinates()
        {
            for(int i = 0; i < shipCoordinates.Count; i++)
            {
                for(int j = 0; j < shipCoordinates[i].Count; j++)
                {

                        Console.WriteLine(shipCoordinates[i][j]);
                        
                }
            }
        }


    }
}
