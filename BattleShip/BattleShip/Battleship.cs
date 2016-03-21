using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Battleship : Ship
    {
        
        public Battleship()
        {
            this.sizeOfShip = 4;
            this.shipName = "Battleship";
            this.gamePiece = "B";
        }
    }
}
