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
          //  for(int i = 0; i < 5; i++)
            //{
                shipCoordinates.Add(new List<Tuple<int, int>> { });
            //}


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
            //shipCoordinates.Add(new List<Tuple<int, int>> { });

            int shipNumber = nameOfShip[ship.shipName];

            //Console.WriteLine("Ship name : {0} ship number: {1}", ship.shipName, shipNumber); // temporary
            //Console.WriteLine("****************************************************************");
            

            if(ship.horizontal == true)
            {
                 Tuple<int, int> coordinates = new Tuple<int, int>(ship.yCoordinate, ship.xCoordinate + shipSection);
                shipCoordinates[shipNumber].Add(coordinates); // will need to change index to shipNumber. For now leave it.

                //will have to figure out how to access all the components
            }
            else if(ship.vertical == true)
            {
                Tuple<int, int> coordinates = new Tuple<int, int>(ship.yCoordinate + shipSection, ship.xCoordinate);
                shipCoordinates[shipNumber].Add(coordinates);
            }
           

        }

        /*public void trackWhichShipYouHit(Player player, Ship ship)
        {
            int shipNumber = nameOfShip[ship.shipName];


            if (ship.horizontal == true)
            {
                var coordinates = new Tuple<int, int>(ship.yCoordinate, ship.xCoordinate + shipSection);
                hitCoordinates[0].Add(coordinates); // will need to change index to shipNumber. For now leave it.

                //will have to figure out how to access all the components
            }
            else if (ship.vertical == true)
            {
                var coordinates = new Tuple<int, int>(ship.yCoordinate + shipSection, ship.xCoordinate);
                shipCoordinates[0].Add(coordinates);
            }
        }*/



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
            //WILL ONLY SHOW WHEN AIRCRAFT CARRIER IS SUNK!!! NEED TO SHOW WHEN ANY SHIP IS SUNK!!!

            for(int i = 0; i < player.CoorLogi.shipCoordinates[hitShip].Count; i++)
            {

                try
                {
                    if (player.CoorLogi.shipCoordinates[hitShip].Contains(player.CoorLogi.hitCoordinates[hitShip][i]))
                    {
                        //Console.WriteLine("They are equal");
                        hits++;

                    }
                    if(hits == player.CoorLogi.shipCoordinates[hitShip].Count)
                    {
                        Console.WriteLine("You sunk a {0}", typeOfShip[hitShip]);
                        player.numberOfShipsSunk++;
                        player.sunkShips[hitShip] = true;

                    }
                   
                }
                catch (Exception e)
                {
                    //Console.WriteLine("still missing");
                }


            }



        }


    }
}
