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

        Dictionary<int, string> typeOfShip = new Dictionary<int, string>() { {0, "Aircraft Carrier"}, {1, "Battleship"}, {2, "Submarine"}, {3, "Destroyer"}, {4, "Patrol Boat"} };

        public List<List<Tuple<int, int>>> shipCoordinates = new List<List<Tuple<int, int>>>();

        public List<Tuple<int, int>> AllCoordinates = new List<Tuple<int, int>>();

        public List<List<Tuple<int, int>>> hitCoordinates = new List<List<Tuple<int, int>>>();



        public void saveShipCoordinate(Map map, Ship ship)
        {
          shipCoordinates.Add(new List<Tuple<int, int>> { });
          

            if (ship.horizontal == true)
            {
                for (int shipSection = 0; shipSection < ship.sizeOfShip; shipSection++)
                {
                    addCoordinatesToList(ship, shipSection, map);

                }
            }
            else if (ship.vertical == true)
            {
                for (int shipSection = 0; shipSection < ship.sizeOfShip; shipSection++)
                {
                    addCoordinatesToList(ship, shipSection, map);

                }
            }
        }

        public void addCoordinatesToList(Ship ship, int shipSection, Map map)
        {
            int shipNumber = nameOfShip[ship.shipName];


            if(ship.horizontal == true)
            {
                 Tuple<int, int> coordinates = new Tuple<int, int>(ship.yCoordinate, ship.xCoordinate + shipSection);
                shipCoordinates[shipNumber].Add(coordinates);
                map.placedShipsOnMap.Add(coordinates);

            }
            else if(ship.vertical == true)
            {
                Tuple<int, int> coordinates = new Tuple<int, int>(ship.yCoordinate + shipSection, ship.xCoordinate);
                shipCoordinates[shipNumber].Add(coordinates);
                map.placedShipsOnMap.Add(coordinates);
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


        public void checkToSeeIfShipWasSunk(Player player, int hitShip)
        {
           
            int hits = 0;

            for(int i = 0; i < player.CoorLogi.shipCoordinates[hitShip].Count; i++)
            {

                try
                {
                    if (player.CoorLogi.shipCoordinates[hitShip].Contains(player.CoorLogi.hitCoordinates[hitShip][i]))
                    {
                        hits++;
                    }
                    if(hits == player.CoorLogi.shipCoordinates[hitShip].Count)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You sunk a {0}", typeOfShip[hitShip]);
                        System.Media.SystemSounds.Beep.Play();
                        player.numberOfShipsSunk++;
                        player.numberOfShipsRemaining--;
                        player.sunkShips[hitShip] = true;

                        
                    }
                   
                }
                catch (Exception e)
                {

                }
            }
        }
    }
}
