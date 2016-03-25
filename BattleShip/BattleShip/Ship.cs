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

        public int yCoordinate = 1; 
        public int xCoordinate = 2;
        public bool horizontal = true;
        public bool vertical = false;
        public bool atTop = false;
        public bool atLeft = false;
        public bool atRight = false;
        public bool atBottom = false;
        public bool pieceIsThere = false;
       CoordinateLogistic coorlogi = new CoordinateLogistic();
      


        public void moveShipDown(Map map, Ship ship)
        {
            int coordinate = 0;

            if (checkIfAtBottomOfMap(map))
            {
                Console.WriteLine("Can't Move down any more");
            }
            else
            {
                if (horizontal == true)
                {

                    Tuple<int, int> tempCoordinate = new Tuple<int, int>(this.yCoordinate + 1, this.xCoordinate + coordinate + this.sizeOfShip - 1);

                    if (map.placedShipsOnMap.Contains(tempCoordinate))
                    {
                        Console.WriteLine("There is a ship there already");
                    }
                    else
                    {
                        for (int i = 0; i < this.sizeOfShip; i++)
                        {
                            map.map[this.yCoordinate][this.xCoordinate + i] = "?";
                            map.map[this.yCoordinate + 1][this.xCoordinate + i] = ship.gamePiece;
                        }

                        this.yCoordinate += 1;
                    }

                }
                else if (vertical == true)
                {
                    Tuple<int, int> tempCoordinate = new Tuple<int, int>(this.yCoordinate +this.sizeOfShip, this.xCoordinate);

                    if (map.placedShipsOnMap.Contains(tempCoordinate))
                    {
                        Console.WriteLine("There is a ship there already");
                    }
                    else
                    {
                        for (int i = 0; i < this.sizeOfShip; i++)
                        {
                            map.map[this.yCoordinate + i + 1][this.xCoordinate] = ship.gamePiece;

                        }
                        map.map[this.yCoordinate][this.xCoordinate] = "?";

                        this.yCoordinate += 1;
                    }

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
            int coordinate = 0;

            if (checkIfAtTopOfMap(map))
            {
                Console.WriteLine("Can't Move up any more");
            }
            else
            {
                if (horizontal == true)
                {
                    Tuple<int, int> tempCoordinate = new Tuple<int, int>(this.yCoordinate - 1, this.xCoordinate + coordinate + this.sizeOfShip-1);

                    if (map.placedShipsOnMap.Contains(tempCoordinate)) 
                    {
                        Console.WriteLine("There is a ship there already");
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
                else if (vertical == true)
                {
                    Tuple<int, int> tempCoordinate = new Tuple<int, int>(this.yCoordinate -1 , this.xCoordinate);

                    if (map.placedShipsOnMap.Contains(tempCoordinate))
                    {
                        Console.WriteLine("There is a ship there already");
                    }
                    else
                    {
                        for (int i = 0; i < this.sizeOfShip; i++)
                        {
                            map.map[this.yCoordinate + i - 1][this.xCoordinate] = ship.gamePiece;

                        }
                        map.map[this.yCoordinate + this.sizeOfShip - 1][this.xCoordinate] = "?";

                        this.yCoordinate -= 1;
                    }
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
            int coordinate = 0;

            if (checkIfAtRightOfMap(map))
            {
                Console.WriteLine();
                Console.WriteLine("You can't move right anymore");
            }
            else
            {
                if (horizontal == true)
                {
                    Tuple<int, int> tempCoordinate = new Tuple<int, int>(this.yCoordinate, this.xCoordinate + coordinate+this.sizeOfShip);

                    if (map.placedShipsOnMap.Contains(tempCoordinate)) 
                    {
                        Console.WriteLine("There is a ship there already");
                    }
                    else
                    {
                        for (int i = 0; i < this.sizeOfShip; i++)
                        {
                            map.map[this.yCoordinate][this.xCoordinate] = "?";
                            map.map[this.yCoordinate][this.xCoordinate + i + 1] = ship.gamePiece;

                        }
                        this.xCoordinate += 1;
                    }

                }
                else if (vertical == true)
                {
                    Tuple<int, int> tempCoordinate = new Tuple<int, int>(this.yCoordinate + coordinate, this.xCoordinate +1);

                    if (map.placedShipsOnMap.Contains(tempCoordinate))
                    {
                        Console.WriteLine("There is a ship there already");
                    }
                    else
                    {
                        for (int i = 0; i < this.sizeOfShip; i++)
                        {
                            map.map[this.yCoordinate + i][this.xCoordinate] = "?";
                            map.map[this.yCoordinate + i][this.xCoordinate + 1] = ship.gamePiece;
                        }

                        this.xCoordinate += 1;
                    }
                   
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

            int coordinate = 0;
            
            if (checkIfAtLeftOfMap(map))
            {
                Console.WriteLine();
                Console.WriteLine("You can't move left anymore");
            }
            else
            {
                if (horizontal == true)
                {
                    Tuple<int, int> tempCoordinate = new Tuple<int, int>(this.yCoordinate, this.xCoordinate + coordinate - 1);

                    if (map.placedShipsOnMap.Contains(tempCoordinate))
                    {
                        Console.WriteLine("There is a ship there already");
                    }
                   else
                    {
                    for (int i = 0; i < this.sizeOfShip; i++)
                        {
                            map.map[this.yCoordinate][this.xCoordinate + i - 1] = ship.gamePiece;
                            coordinate = i;
                        }
                        map.map[this.yCoordinate][this.xCoordinate + this.sizeOfShip - 1] = "?";

                        this.xCoordinate -= 1;
                    }
                }
                else if (vertical == true)
                {
                    Tuple<int, int> tempCoordinate = new Tuple<int, int>(this.yCoordinate + coordinate, this.xCoordinate - 1);

                    if (map.placedShipsOnMap.Contains(tempCoordinate))
                    {
                        Console.WriteLine("There is a ship there already");
                    }
                    else
                    {
                        for (int i = 0; i < this.sizeOfShip; i++)
                        {
                            map.map[this.yCoordinate + i][this.xCoordinate] = "?";
                            map.map[this.yCoordinate + i][this.xCoordinate - 1] = ship.gamePiece;
                        }

                        this.xCoordinate -= 1;
                    }
                   
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
            atRight = false;
            atLeft = false;
            atTop = false;
            atBottom = false;
            vertical = true;
            horizontal = false;



            for (int i = 0; i < this.sizeOfShip; i++)
            {
                for(int j = 0; j< this.sizeOfShip; j++)
                {
                    map.map[this.yCoordinate][this.xCoordinate + i+1] = "?";
                    map.map[this.yCoordinate + j][this.xCoordinate] = ship.gamePiece;
                }
            }

            
            Console.WriteLine();
            map.drawMap();
        }

        public void rotateShipToHorizontal(Map map, Ship ship)
        {

            atRight = false;
            atLeft = false;
            atTop = false;
            atBottom = false;
            vertical = false;
            horizontal = true;


            for (int i = 0; i < this.sizeOfShip; i++)
            {
                for (int j = 0; j < this.sizeOfShip; j++)
                {
                    map.map[this.yCoordinate + i + 1][this.xCoordinate] = "?";
                    map.map[this.yCoordinate][this.xCoordinate + j] = ship.gamePiece;
                }

            }

            Console.WriteLine();
            map.drawMap();
        }


        public bool checkIfAtTopOfMap(Map map)
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

        public bool checkIfAtLeftOfMap(Map map)
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

        public bool checkIfAtRightOfMap(Map map)
        {
            if(horizontal == true)
            {
                if (this.xCoordinate == map.mapWidth - sizeOfShip)
                {
                    atRight = true;
                    atLeft = false;
                    atBottom = false;
                    atTop = false;
                }
            }
            else if (vertical == true)
            {
                if (this.xCoordinate == map.mapWidth -1)
                {
                    atRight = true;
                    atLeft = false;
                    atBottom = false;
                    atTop = false;
                }
            }
            else
            {
                atRight = false;
            }

            

            return atRight;
        }


        public bool checkIfAtBottomOfMap(Map map)
        {
            if(horizontal == true)
            {
                if (this.yCoordinate == map.mapLength -1) 
                {
                    atBottom = true;
                    atTop = false;
                    atRight = false;
                    atLeft = false;
                }
            }
            else if(vertical == true)
            {
                if (this.yCoordinate == map.mapLength - sizeOfShip)
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

            return atBottom;

        }
    }
}
