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
        public Map mapThatOpponentSees = new Map();
        public CoordinateLogistic CoorLogi = new CoordinateLogistic();
        public GamePlay controls = new GamePlay();

        public int hits = 0;
        public int misses = 0;
        public int numberOfShipsSunk = 0;
        public int numberOfShipsRemaining = 5;

        public bool aircraftCarrierSunk = false;
        public bool battleshipSunk = false;
        public bool submarineSunk = false;
        public bool destroyerSunk = false;
        public bool patrolBoatSunk = false;
        public bool[] sunkShips = new bool [5];


        public Player(string name, int playerNumber){
            this.name = name;
            this.playerNumber++;
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
                Console.ResetColor();
                Console.WriteLine("Player {0}: {1} - Where do you want to move your {2}?  [m] control menu", this.playerNumber, this.name, ship.shipName);
                try
                {
                    ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                    if (keyPressed.KeyChar.Equals('x'))
                    {
                        moveShip = false;
                    }
                    else if (keyPressed.KeyChar.Equals('q'))
                    {
                       
                        moveShip = setHere;
                        Console.WriteLine();
                        map.drawMap();
                        CoorLogi.saveShipCoordinate(map, ship);

                    }
                    else if (keyPressed.KeyChar.Equals('w'))
                    {
                        ship.moveShipUp(map, ship);
                    }
                    else if (keyPressed.KeyChar.Equals('s'))
                    {
                        ship.moveShipDown(map, ship);
                    }
                    else if (keyPressed.KeyChar.Equals('d'))
                    {
                        ship.moveShipRight(map, ship);
                    }
                    else if (keyPressed.KeyChar.Equals('a'))
                    {
                        ship.moveShipLeft(map, ship);
                    }
                    else if (keyPressed.KeyChar.Equals('r'))
                    {
                        ship.rotateShip(map, ship);
                    }
                    else if (keyPressed.KeyChar.Equals('m'))
                    {
                        Console.WriteLine();
                        controls.getControlMenu();
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

                }
            }
            moveShip = true;
            setHere = false;
        }

    }

}


