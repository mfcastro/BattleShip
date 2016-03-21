using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Player
    {
        string name;
        bool moveShip = true;

        public Player(string name){
            this.name = name;
        }

      

        public void moveShipOnMap(Map map, Ship ship)
        {

            while (moveShip)
            {
                try
                {
                    Console.WriteLine("Where do you want to move your {0}?", ship.shipName);
                    string control = Console.ReadLine();

                    if (control.Equals("x"))
                    {
                        moveShip = false;
                    }
                    else if (control.Equals("w"))
                    {
                        ship.moveShipUp(map);
                    }
                    else if (control.Equals("s"))
                    {
                        ship.moveShipDown(map);
                    }
                    else if (control.Equals("d"))
                    {
                        ship.moveShipRight(map);
                    }
                    else if (control.Equals("a"))
                    {
                        ship.moveShipLeft(map);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Entry");
                    moveShipOnMap(map, ship);

                }
            }
        }

            
            

        }


    }


