using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class CoordinateLogistic
    {

        //Dictionary<int, string> nameOfShip = new Dictionary<int, string>() { { 0, "Aircraft Carrier" }, { 1, "Battleship" }, { 2, "Submarine" }, { 3, "Destroyer" }, { 4, "Patrol Boat" } };
       // List<List<int[]>> shipCoordinates = new List<List<int[]>>();
       public List<List<Tuple<int, int>>> shipCoordinates = new List<List<Tuple<int, int>>>();

        public List<Tuple<int, int>> AllCoordinates = new List<Tuple<int, int>>();



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

           

            if(ship.horizontal == true)
            {
                 var coordinates = new Tuple<int, int>(ship.yCoordinate, ship.xCoordinate + shipSection);
                shipCoordinates[0].Add(coordinates);
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
