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

        public List<string> shipCoordinates = new List<string>();


        public int yCoordinate = 1; //column
        public int xCoordinate = 2; //row
        public bool horizontal = true;
        public bool vertical = false;
        public bool atTop = false;
        public bool atLeft = false;
        public bool atRight = false;
        public bool atBottom = false;
        public bool pieceIsThere = false;


      /*  public void AddShipToMap(Map map, Ship ship)
        {   
            for(int i = 0; i<this.sizeOfShip; i++)
            {
                map.map[1][2 + i] = ship.gamePiece;
            }
            map.drawMap();
        }*/


        public void moveShipDown(Map map, Ship ship)
        {

            if (checkIfAtBottomOfMap())
            {
                Console.WriteLine("Can't Move down any more");
            }
            else
            {
                if (horizontal == true)
                {

                    for (int i = 0; i < this.sizeOfShip; i++)
                    {
                        map.map[this.yCoordinate][this.xCoordinate + i] = "?";
                        map.map[this.yCoordinate + 1][this.xCoordinate + i] = ship.gamePiece;
                    }

                    this.yCoordinate += 1;


                }
                else if (vertical == true)
                {
                    //move down if vertical - Works!!!! Check for edges

                    for (int i = 0; i < this.sizeOfShip; i++)
                    {
                        map.map[this.yCoordinate + i + 1][this.xCoordinate] = ship.gamePiece;

                    }
                    map.map[this.yCoordinate][this.xCoordinate] = "?";

                    this.yCoordinate += 1;

                }

                Console.WriteLine();
                map.drawMap();
            }

            atLeft = false;
            atRight = false;
            atTop = false;
            atBottom = false;


              

        }

        public void moveShipUp(Map map, Ship ship)
        {
            if (checkIfAtTopOfMap())
            {
                Console.WriteLine("Can't Move up any more");
            }
            else
            {
                if (horizontal == true)
                {

                    for (int i = 0; i < this.sizeOfShip; i++)
                    {
                        map.map[this.yCoordinate][this.xCoordinate + i] = "?";
                        map.map[this.yCoordinate - 1][this.xCoordinate + i] = ship.gamePiece;

                    }
                    this.yCoordinate -= 1;

                }
                else if (vertical == true)
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

            atLeft = false;
            atRight = false;
            atTop = false;
            atBottom = false;
        }





        public void moveShipRight(Map map, Ship ship)
        {

           if (checkIfAtRightOfMap())
            {
                Console.WriteLine();
                Console.WriteLine("You can't move right anymore");
            }
            else
            {
                if (horizontal == true)
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

            atLeft = false;
            atRight = false;
            atTop = false;
            atBottom = false;
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

            atLeft = false;
            atRight = false;
            atTop = false;
            atBottom = false;
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

            atRight = false;// TESTING
            atLeft = false;// TESTING 


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


            atRight = false;// TESTING
            atLeft = false;// TESTING 

            Console.WriteLine();
            map.drawMap();
        }


        public bool checkIfAtTopOfMap()
        {
            if(this.yCoordinate == 1)
            {
                atTop = true;
                atBottom = false;
                atRight = false;
                atLeft = false;
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
                atRight = false;
                atTop = false;
                atBottom = false;
            }
            else
            {
                atLeft = false;
            }

            return atLeft;
        }

        public bool checkIfAtRightOfMap()
        {
            if(horizontal == true)
            {
                if (this.xCoordinate == 11 - sizeOfShip) // this will have to change if you make the map dynamic 
                {
                    atRight = true;
                    atLeft = false;
                    atBottom = false;
                    atTop = false;
                }
               // else
                //{
                  //  atRight = false;
                //}
            }
            else if (vertical == true)
            {
                if (this.xCoordinate == 10) // this will have to change if you make the map dynamic 
                {
                    atRight = true;
                    atLeft = false;
                    atBottom = false;
                    atTop = false;
                }
                //else
                //{
                  //  atRight = false;
                //}
            }
            else
            {
                atRight = false;
            }

            

            return atRight;
        }


        public bool checkIfAtBottomOfMap()
        {
            if(horizontal == true)
            {
                if (this.yCoordinate == 10) // will need to change it map is dynamic 
                {
                    atBottom = true;
                    atTop = false;
                    atRight = false;
                    atLeft = false;
                }
            }
            else if(vertical == true)
            {
                if (this.yCoordinate == 11 - sizeOfShip) // will need to change it map is dynamic 
                {
                    atBottom = true;
                    atTop = false;
                    atRight = false;
                    atLeft = false;
                }
            }
            else
            {
                atBottom = false;
            }




            /*if (this.yCoordinate == 10) // will need to change it map is dynamic 
            {
                atBottom = true;
            }
            else
            {
                atBottom = false;
            }*/

            return atBottom;
        }





    }
}
