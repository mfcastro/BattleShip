using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Ship
    {
        public int sizeOfShip;
        public string shipName = "Ship";
        public string gamePiece;

        public const int startX = 2;
        public const int startY = 1;


        public List<string> shipCoordinates = new List<string>();


        public int yCoordinate = 1; //column
        public int xCoordinate = 2; //row
        public bool horizontal = true;
        public bool vertical = false;
        public bool atTop = false;
        public bool atLeft = false;
        public bool pieceIsThere = false;


        public void AddShipToMap(Map map, Ship ship)
        {   
            for(int i = 0; i<this.sizeOfShip; i++)
            {
                map.map[startY][startX + i] = ship.gamePiece;
            }
            map.drawMap();
        }


        public void moveShipDown(Map map, Ship ship)
        {
            if (horizontal == true)
            {
                for (int i = 0; i < this.sizeOfShip; i++)
                {
                    map.map[this.yCoordinate][this.xCoordinate + i] = "?";
                    map.map[this.yCoordinate + 1][this.xCoordinate + i] = ship.gamePiece;
                }

                this.yCoordinate += 1;

               // Console.WriteLine();
                //map.drawMap();
            }
            else if (vertical == true)
            {
                //move down if vertical - Works!!!! Check for edges

                for (int i = 0; i < this.sizeOfShip; i++)
                {
                    map.map[this.yCoordinate+i+1][this.xCoordinate] = ship.gamePiece;

                }
                map.map[this.yCoordinate][this.xCoordinate] = "?";

                this.yCoordinate += 1;

            }

            Console.WriteLine();
            map.drawMap();

        }

        public void moveShipUp(Map map, Ship ship)
        {
            if (horizontal == true)
            {
                if (checkIfAtTopOfMap()) {
                    Console.WriteLine("Can't Move up any more");
                }
                else
                {
                    for (int i = 0; i < this.sizeOfShip; i++)
                    {
                        map.map[this.yCoordinate][this.xCoordinate + i] = "?";
                        map.map[this.yCoordinate - 1][this.xCoordinate + i] = ship.gamePiece;

                    }
                    this.yCoordinate -= 1;
                }

            }
            else if(vertical == true)
            {
                //move up if vertical  - WORKS JUST NEED TO CHECK FOR EDGES!!!!!


                for (int i = 0; i < this.sizeOfShip; i++)
                {
                    map.map[this.yCoordinate + i - 1][this.xCoordinate] = ship.gamePiece;

                }
                map.map[this.yCoordinate + this.sizeOfShip - 1][this.xCoordinate] = "?";

                this.yCoordinate -= 1;
            }

            Console.WriteLine();
            map.drawMap();

        }

        public void moveShipRight(Map map, Ship ship)
        {
            if(horizontal == true)
            {
                for (int i = 0; i < this.sizeOfShip; i++)
                {
                    map.map[this.yCoordinate][this.xCoordinate] = "?";
                    map.map[this.yCoordinate][this.xCoordinate + i + 1] = ship.gamePiece;

                }
                this.xCoordinate += 1;


                
            }
            else if (vertical == true)
            {
                //move right if vertical -  WORKS!!! JUST NEED TO CHECK EDGES OF MAP
                for (int i = 0; i < this.sizeOfShip; i++)
                {
                    map.map[this.yCoordinate + i][this.xCoordinate] = "?";
                    map.map[this.yCoordinate + i][this.xCoordinate + 1] = ship.gamePiece;
                }

                this.xCoordinate += 1;
            }

            Console.WriteLine();
            map.drawMap();

        }


        public void moveShipLeft(Map map, Ship ship)
        {


            if (checkIfAtLeftOfMap())
            {
                Console.WriteLine();
                Console.WriteLine("You can't move left anymore");
            }
            else
            {
                if (horizontal == true)
                {
                    
                        for (int i = 0; i < this.sizeOfShip; i++)
                        {
                            map.map[this.yCoordinate][this.xCoordinate + i - 1] = ship.gamePiece;

                        }
                        map.map[this.yCoordinate][this.xCoordinate + this.sizeOfShip - 1] = "?";

                        this.xCoordinate -= 1;

                }
                else if (vertical == true)
                {
                    //move left if horizontal - WORKS JUST NEED TO CHECK IF AT LEFT OF MAP
                    for (int i = 0; i < this.sizeOfShip; i++)
                    {
                        map.map[this.yCoordinate + i][this.xCoordinate] = "?";
                        map.map[this.yCoordinate + i][this.xCoordinate - 1] = ship.gamePiece;
                    }

                    this.xCoordinate -= 1;
                }


                Console.WriteLine();
                map.drawMap();
            }


        }

        public void rotateShip(Map map, Ship ship)
        {
            if(horizontal == true && vertical == false)
            {
                rotateShipToVertical(map, ship);
            }
            else if(horizontal == false && vertical == true)
            {
                rotateShipToHorizontal(map, ship);
            }
        }


        public void rotateShipToVertical(Map map, Ship ship)
        {
            for (int i = 0; i < this.sizeOfShip; i++)
            {
                for(int j = 0; j< this.sizeOfShip; j++)
                {
                    map.map[this.yCoordinate][this.yCoordinate + i+1] = "?";
                    map.map[this.yCoordinate + j][this.xCoordinate] = ship.gamePiece;
                }
                
            }

            vertical = true;
            horizontal = false;
            Console.WriteLine();
            map.drawMap();
        }

        public void rotateShipToHorizontal(Map map, Ship ship)
        {
            for (int i = 0; i < this.sizeOfShip; i++)
            {
                for (int j = 0; j < this.sizeOfShip; j++)
                {
                    map.map[this.yCoordinate + i + 1][this.yCoordinate] = "?";
                    map.map[this.yCoordinate][this.xCoordinate + j] = ship.gamePiece;
                }

            }

            vertical = false;
            horizontal = true;
            Console.WriteLine();
            map.drawMap();
        }


        public bool checkIfAtTopOfMap()
        {
            if(this.yCoordinate == 1)
            {
                atTop = true;
            }
            else
            {
                atTop = false;
            }

            return atTop;
        }

        public bool checkIfAtLeftOfMap()
        {
            if (this.xCoordinate == 2)
            {
                atLeft = true;
            }
            else
            {
                atLeft = false;
            }

            return atLeft;
        }


        


       
    }
}
