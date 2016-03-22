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
        int playerNumber = 0;

        public Map map = new Map();
        public CoordinateLogistic CoorLogi = new CoordinateLogistic();



        public Player(string name){
            this.name = name;
            this.playerNumber++;
            Map map = new Map();

        }


        public void moveShipOnMap(Map map, Ship ship)
        {

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
                       // CoorLogi.printShipCoordinates();

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
                        //ship.rotateShipToVertical(map, ship);
                        ship.rotateShip(map, ship);
                    
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Entry");
                    map.drawMap();
                    moveShipOnMap(map, ship);

                }

            }
            moveShip = true;
            setHere = false;
        }

       
       


    }


    }


