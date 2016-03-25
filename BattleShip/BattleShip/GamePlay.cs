using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class GamePlay
    {
       Ship[] gamepieces = { new AircraftCarrier(), new Battleship(), new Submarine(), new Destroyer(), new PatrolBoat()};
       public int xcoord = 0;
       public int ycoord = 0;
       bool noWinner = true;

        string[] controlMenu = {"[w] move ship up" , "[s] move ship down" , "[d] move ship right" , "[a] move ship right" , 
                              "[r] rotate ship vertical or horizontal", "[q] place ship" , "[m] game menu"}; 

 
        public void startGame()
        {
            Console.ResetColor();
            Player player1 = new Player("Player 1", 1);
            Player player2 = new Player("Player 2", 2);

            startMenu(player1);

            //getNewMapSize(player1, player2); // may be temporary
            Console.WriteLine("Player 1 Ships are set. Press <Enter> for Player 2 to set ships.");
            Console.ReadLine();

            gameMenu(player2);

            Console.WriteLine("Ships are set! Press <Enter> to Start Game!");
            Console.ReadLine();

            turnSwitcher(player1, player2);
        }

        public void startMenu(Player player)
        {
            Console.WriteLine("WELCOME TO BATTLESHIP!");
            Console.WriteLine();
            Console.WriteLine("Play [p] Instructions [i] Controls [c]");
            Console.WriteLine();
            ConsoleKeyInfo keyPressed = Console.ReadKey(true);


            if (keyPressed.KeyChar.Equals('p'))
            {
                gameMenu(player);
            }
            else if (keyPressed.KeyChar.Equals('i'))
            {
                getGameInstructions();
                startMenu(player);
            }
            else if (keyPressed.KeyChar.Equals('c'))
            {
                getControlMenu();
                startMenu(player);
            }
            
            else{
                Console.WriteLine();
                Console.WriteLine("Invalid Entry");
                startMenu(player);
            }
        }

        public void getControlMenu()
        {
            Console.WriteLine("Available Game Controls: ");
            Console.WriteLine();

            foreach(string control in controlMenu)
            {
                Console.WriteLine(control);
            }
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
        }

        public void getGameInstructions()
        {
            Console.WriteLine("GAME RULES: ");

            Console.WriteLine();

            Console.WriteLine("Before play begins, each player secretly arranges their ships on their primary grid. Each " 
                + "\nship occupies a number of consecutive spaces on the grid, arranged either horizontally or" 
                + "\nvertically. The number of squares for each ship is determined by the type of ship. The "
                +"\nships cannot overlap (i.e., only one ship can occupy any given square in the grid). The" 
                +"\ntypes and numbers of ships allowed are the same for each player.");

            Console.WriteLine();

            Console.WriteLine("After the ships have been positioned, the game proceeds in a series of rounds. In each round," 
                               +"\neach player takes a turn to announce a target square in the opponent's grid which is to be shot" 
                               +"\nat. The opponent announces whether or not the square is occupied by a ship, and if it is a \"miss\"," 
                               +"\nthe player marks their primary grid with a \"O\"; if a \"hit\" they mark this on their own" 
                               +"\nprimary grid with a \" * \". The attacking player notes the hit or miss on their own \"tracking\""
                               +"\ngrid with the appropriate mark (* for \"hit\", X for \"miss\"), in order to build up a picture" 
                               +"\nof the opponent's fleet.");

            Console.WriteLine();

            Console.WriteLine("When all of the squares of a ship have been hit, the ship is sunk, and the ship's owner announces"
                              + "\nwhich ship has been sunk (e.g. \"You sank my battleship!\"). If all of a player's ships have been" 
                              +"\nsunk, the game is over and their opponent wins");

            Console.WriteLine();

            Console.WriteLine("Type of ship and number of spaces: Aircraft Carrier - 5, Battleship - 4, Submarine - 3;"
                                +"\n\t\t\t\t   Destroyer - 3; Patrol Boat - 2");

            Console.WriteLine();

            Console.WriteLine("Game controls: \t[w] move ship up , [s] move ship down, [d] move ship right, [a] move ship right,"
                               + "\n\t\t[r] rotate ship vertical or horizontal, [q] place ship [m] game menu");

            Console.WriteLine();

            Console.WriteLine("---------------------------------------------------------------------------------------------------------");

            Console.WriteLine();    
        }


        public void gameMenu(Player player)
        {
            //Console.WriteLine();
            Console.WriteLine("{0}: What is your name: ", player.name);
            player.name = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Hello {0}! Arrange your Ships on your grid below.", player.name);
            Console.WriteLine();

            
            prepareStartMap(player);
            prepareOpponetViewMenu(player);

            foreach(Ship piece in gamepieces)
            {
                player.moveShipOnMap(player.map, piece);

            }

            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            Console.WriteLine();

        }


        private void prepareOpponetViewMenu(Player player)
        {
            player.mapThatOpponentSees.fillMap(player.map.mapLength, player.map.mapWidth);
        }


        /*public void resetShipPlacement(Ship ship, Player player)
        {
            player.map.map[ship.yCoordinate][ship.xCoordinate + ship.sizeOfShip - 1] = "X";

        }*/


        public void prepareStartMap(Player player)
        {
            player.map.fillMap(player.map.mapLength,player.map.mapWidth);
            player.map.drawMap();
        }

        /*public void getAttackMap(Player player)
        {
            player.map.fillMap(player.map.mapLength, player.map.mapWidth);
            player.map.drawMap();
        }*/


        public void attackPlayer(Player player)
        {
            player.mapThatOpponentSees.drawMap();

            Console.ResetColor();
            Console.WriteLine("Hits: {0}, Misses: {1}, Ship Sunk: {2}, Ships Remaining: {3}", player.hits, player.misses, player.numberOfShipsSunk, player.numberOfShipsRemaining); // figure out how to display # of ships sunk 
            Console.WriteLine("To Attack Enter Coordinates [ex. a1]: ");
            string coordinates = Console.ReadLine();

            coordinates = coordinates.ToUpper();
            Tuple<int, int> newCoord = seperateCoordinates(coordinates, player);

            bool hit = didYouHitAShip(player,newCoord);

        }

        public void populateHitList(Player player)
        {
            for(int i = 0; i<5; i++)
            {
                player.CoorLogi.hitCoordinates.Add(new List<Tuple<int, int>> { });
            }
        }
        

        public Tuple<int, int> seperateCoordinates(string coord, Player player)
        {

            int moreThanOneInt = 1;
            string currentInt = "";
            string current;

            foreach (char x in coord)
            {
                if(int.TryParse(x.ToString(), out xcoord) == true)
                {
                    current = x.ToString();

                    if (moreThanOneInt == 1)
                    {
                        moreThanOneInt = 2;
                        currentInt += current;
                    }
                    else if (moreThanOneInt == 2)
                    {
                        xcoord = int.Parse(currentInt + current);  
                    }
                }
                else
                {
                    ycoord = player.map.numberCoordinates[x.ToString()];  
                }
            }

            player.CoorLogi.AllCoordinates.Add(new Tuple<int, int>(ycoord, xcoord));

            Tuple<int, int> currentAttack = new Tuple<int, int>(xcoord, ycoord);

            return currentAttack;

        }

        public bool didYouHitAShip(Player player, Tuple <int, int> coord)
        {
            bool hit = false;
            int shipHit = 0;

            for (int ship = 0; ship < player.CoorLogi.shipCoordinates.Count; ship++)
            {
                for(int shipSection = 0; shipSection < player.CoorLogi.shipCoordinates[ship].Count; shipSection++)
                {
                hit = player.CoorLogi.shipCoordinates[ship].Contains(coord);

                
                if(hit == true)
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }

                }

                if (hit == true)
                {
                    shipHit = ship;
                    break;
                }
                else
                {
                    continue;
                }
            }


            if (hit == true)
            {
                displayHitShip(player.mapThatOpponentSees);
                Console.ResetColor();

                showHitShipOnOwnMap(player.map);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\aYou just HIT a ship!! Press <Enter> to continue.");
                player.hits++;

                player.CoorLogi.hitCoordinates[shipHit].Add(coord);
                
                player.CoorLogi.checkToSeeIfShipWasSunk(player, shipHit);


                Console.ReadLine();
                Console.ResetColor();
                Console.WriteLine();

            }
            else
            {
                displayMissedShot(player.mapThatOpponentSees);
                Console.ResetColor();

                showMissedShotOnMap(player.map);
                System.Media.SystemSounds.Beep.Play();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You just missed! Press <Enter> to continue");
                player.misses++;

                Console.ReadLine();
                Console.ResetColor();
                Console.WriteLine();

            }

            return hit;
        }

        public void displayHitShip(Map map)
        {
            try
            {
                map.map[this.xcoord][this.ycoord] = "*";

                map.drawMap();


            }
            catch (Exception e)
            {
                Console.WriteLine("Out of range");
            }
        }  


        public void showHitShipOnOwnMap(Map map)
        {
            try
            {
                map.map[this.xcoord][this.ycoord] = "*";

            }
            catch (Exception e)
            {
                Console.WriteLine("Out of range");
            }
        }


        public void displayMissedShot(Map map)
        {
            try
            {
                map.map[this.xcoord][this.ycoord] = "X";
                map.drawMap();

            }
            catch (Exception e)
            {
                Console.WriteLine("Out of range");
            }
        }

        public void showMissedShotOnMap(Map map)
        {
            try
            {
                map.map[this.xcoord][this.ycoord] = "X";

            }
            catch (Exception e)
            {
                Console.WriteLine("Out of range");
            }
        }


        public void turnSwitcher(Player player1, Player player2)
        {
            populateHitList(player1);
            populateHitList(player2);


            while (noWinner)
            {
                Console.ResetColor();
                Console.WriteLine("Player 1: {0} to attack {1} " , player1.name, player2.name);

                Console.WriteLine(); 
                Console.WriteLine("Your map:"); 
                player1.map.drawOwnMap();
                Console.ResetColor();
                Console.WriteLine("------------------------"); 
                Console.WriteLine("Player 2 Map:"); 
                attackPlayer(player2);

                Console.WriteLine();


                if (checkForWinner(player2))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Player 1 Wins : {0} you sunk all of {1}'s ships. You Won!!!", player1.name, player2.name);

                    noWinner = false;
                    
                }
                else
                {
                    Console.ResetColor();
                    Console.WriteLine("Player 2: {0} to attack {1} ", player2.name, player1.name);

                    Console.WriteLine(); 
                    Console.WriteLine("Your map:"); 
                    player2.map.drawOwnMap();
                    Console.ResetColor();
                    Console.WriteLine("------------------------"); 
                    Console.WriteLine("Player 1 Map:"); 

                    attackPlayer(player1);


                    if (checkForWinner(player1))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Player 2 Wins : {0} you sunk all of {1}'s ships. You Won!!!", player2.name, player1.name);
                        noWinner = false;
                    }
                }
            }
        }

        public bool checkForWinner(Player player)
        {
            bool isWinner = false;
            int numberOfShips =0;

            foreach (bool shipSunk in player.sunkShips)
            {
                numberOfShips++;

                if (shipSunk == false)
                {
                    break;
                }

                if(numberOfShips == player.sunkShips.Length)
                {
                    isWinner = true;
                }
            }

            return isWinner;
            
        }
    }
}
