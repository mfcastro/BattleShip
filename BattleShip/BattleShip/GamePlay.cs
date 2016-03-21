using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class GamePlay
    {
        Map map = new Map();
       

        Ship[] gamepieces = { new AircraftCarrier(), new Battleship(), new Submarine(), new Destroyer(), new PatrolBoat()};
       

        public void getGamePieces()
        {

        }
        
        public void startMenu()
        {
            Console.WriteLine("WELCOME TO BATTLESHIP!");
            Console.WriteLine("What is your name: ");
            string name = Console.ReadLine();

            Player player = new Player(name);

            Console.WriteLine("Hello {0}!", player.name);
            Console.WriteLine();

            Console.WriteLine("Play [p] Instructions [i]");
            string selection = Console.ReadLine();

            if (selection.Equals("p"))
            {
                gameMenu(player);
            }
            else if (selection.Equals("i"))
            {
                getGameInstructions();
            }
            else{
                Console.WriteLine("Invalid Entry");
            }


        }

        public void getGameInstructions()
        {
            Console.WriteLine("Before play begins, each player secretly arranges their ships on their primary grid. Each " 
                + "\nship occupies a number of consecutive spaces on the grid, arranged either horizontally or" 
                + "\nvertically. The number of squares for each ship is determined by the type of the ship. The "
                +"\nships cannot overlap (i.e., only one ship can occupy any given square in the grid). The" 
                +"\ntypes and numbers of ships allowed are the same for each player.");

            Console.WriteLine();

            Console.WriteLine("After the ships have been positioned, the game proceeds in a series of rounds. In each round," 
                               +"\neach player takes a turn to announce a target square in the opponent's grid which is to be shot" 
                               +"\nat. The opponent announces whether or not the square is occupied by a ship, and if it is a \"miss\"," 
                               +"\nthe player marks their primary grid with a \"O\"; if a \"hit\" they mark this on their own" 
                               +"\nprimary grid with a \" * \". The attacking player notes the hit or miss on their own \"tracking\""
                               +"\ngrid with the appropriate mark (* for \"hit\", O for \"miss\"), in order to build up a" 
                               +"\npicture of the opponent's fleet.");

            Console.WriteLine();

            Console.WriteLine("When all of the squares of a ship have been hit, the ship is sunk, and the ship's owner announces" 
                              + "\nthis (e.g. \"You sank my battleship!\"). If all of a player's ships have been sunk, the game is over"
                              + "\nand their opponent wins");
        }

        public void gameMenu(Player player)
        {
            prepareStartMap();

            foreach(Ship piece in gamepieces)
            {
                player.moveShipOnMap(map, piece);
                piece.AddShipToMap(map);
            }
            
        }

 

        public void prepareStartMap()
        {
            map.fillMap(10,10);
            map.drawMap();
        }

    }
}
