using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Ship
    {
        public int sizeOfShip;
        public int xCoordinate; //column
        public int yCoordinate; //row

        public void AddShipToMap(Map map)
        {   
            for(int i = 0; i<this.sizeOfShip; i++)
            {
                map.map[1][2 + i] = "O";
            }
            map.drawMap();
        }
    }
}
