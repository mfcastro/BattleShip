using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Player
    {
        public string name;
        bool moveShip = true;
        bool setHere = false;
        public int playerNumber;

        public Map map = new Map();
        public CoordinateLogistic CoorLogi = new CoordinateLogistic();

        public Map mapThatOpponentSees = new Map();

        public int hits = 0;
        public int misses = 0;
        public int numberOfShipsSunk = 0;

        public bool aircraftCarrierSunk = false;
        public bool battleshipSunk = false;
        public bool submarineSunk = false;
        public bool destroyerSunk = false;
        public bool patrolBoatSunk = false;
        public bool[] sunkShips = new bool [5];

        public Player(string name, int playerNumber){
            this.name = name;
            this.playerNumber++;
            Map map = new Map();
            Map mapThatOpponentSees = new Map();
            this.playerNumber = playerNumber;
            getSunkShipArray();
    }

        public void getSunkShipArray()
        {
            this.sunkShips[0] = this.aircraftCarrierSunk;
            this.sunkShips[1] = this.battleshipSunk;
            this.sunkShips[2] = this.submarineSunk;
            this.sunkShips[3] = this.destroyerSunk;
            this.sunkShips[4] = this.patrolBoatSunk;
        }






        public void moveShipOnMap(Map map, Ship ship)
        {
            ship.xCoordinate = 2;
            ship.yCoordinate = 1;
            ship.atBottom = false;
            ship.atRight = false;
            ship.vertical = false;
            ship.horizontal = true;

            while (moveShip)
            {
                try
                {
                    Console.WriteLine("Player {0}: {1} - Where do you want to move your {2}?",this.playerNumber, this.name ,ship.shipName);
                    string control = Console.ReadLine();

                    if (control.Equals("x"))
                    {
                        moveShip = false;
                    }
                    else if (control.Equals("q"))
                    {
                        moveShip = setHere;
                        CoorLogi.saveShipCoordinate(map, ship);
                    

                    }
                    else if (control.Equals("w"))
                    {
                        ship.moveShipUp(map, ship);
                    }
                    else if (control.Equals("s"))
                    {
                        ship.moveShipDown(map, ship);
                    }
                    else if (control.Equals("d"))
                    {
                        ship.moveShipRight(map, ship);
                    }
                    else if (control.Equals("a"))
                    {
                        ship.moveShipLeft(map, ship);
                    }
                    else if (control.Equals("r"))
                    {
                        ship.rotateShip(map, ship);
                    
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("You moved your ship off the map. Please move it back. ");
                    map.drawMap();
                    //moveShipOnMap(map, ship);

                }

            }
            moveShip = true;
            setHere = false;
        }

    }

}


