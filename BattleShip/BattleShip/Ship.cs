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

        public int yCoordinate = 1; //column
        public int xCoordinate = 2; //row
        public bool horizontal = true;
        public bool vertical = false;

        public void AddShipToMap(Map map)
        {   
            for(int i = 0; i<this.sizeOfShip; i++)
            {
                map.map[yCoordinate][xCoordinate + i] = "O";
            }
            map.drawMap();
        }

        public void moveShipDown(Map map)
        {
            if (horizontal == true)
            {
                for (int i = 0; i < this.sizeOfShip; i++)
                {
                    map.map[this.yCoordinate][this.xCoordinate + i] = "X";
                    map.map[this.yCoordinate + 1][this.xCoordinate + i] = "O";
                }

                this.yCoordinate += 1;

                Console.WriteLine();
                map.drawMap();
            }
            else
            {
                //move down if vertical
            }

        }

        public void moveShipUp(Map map)
        {
            if (horizontal == true)
            {
                for (int i = 0; i < this.sizeOfShip; i++)
                {
                    map.map[this.yCoordinate][this.xCoordinate + i] = "X";
                    map.map[this.yCoordinate - 1][this.xCoordinate + i] = "O";

                }
                this.yCoordinate -= 1;


                Console.WriteLine();
                map.drawMap();
            }
            else
            {
                //move up if vertical 
            }


            

        }

        public void moveShipRight(Map map)
        {
            if(horizontal == true)
            {
                for (int i = 0; i < this.sizeOfShip; i++)
                {
                    map.map[this.yCoordinate][this.xCoordinate] = "X";
                    map.map[this.yCoordinate][this.xCoordinate + i + 1] = "O";

                }
                this.xCoordinate += 1;


                Console.WriteLine();
                map.drawMap();
            }
            else
            {
                //move right if vertical 
            }
            

        }


        public void moveShipLeft(Map map)
        {
            if (horizontal == true)
            {
                for (int i = 0; i < this.sizeOfShip; i++)
                {
                    map.map[this.yCoordinate][this.xCoordinate + i - 1] = "O";

                }
                map.map[this.yCoordinate][this.xCoordinate + this.sizeOfShip - 1] = "X";

                this.xCoordinate -= 1;

                Console.WriteLine();
                map.drawMap();
            }
            else
            {
                //move left if horizontal
            }

          

        }



    }
}
