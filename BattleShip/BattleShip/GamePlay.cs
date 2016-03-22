﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class GamePlay
    {
        //Map map = new Map();
       

        Ship[] gamepieces = { new AircraftCarrier(), new Battleship(), new Submarine(), new Destroyer(), new PatrolBoat()};
       public int xcoord = 0;
       public int ycoord = 0;
        bool noWinner = true;


        public void getGamePieces()
        {

        }
        
        public void startMenu(Player player)
        {
            Console.WriteLine("WELCOME TO BATTLESHIP!");
            Console.WriteLine();
            Console.WriteLine("Play [p] Instructions [i]");
            string selection = Console.ReadLine();
            Console.WriteLine();

            if (selection.Equals("p"))
            {
                
                Console.WriteLine("What is your name: ");
                player.name = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine("Hello {0}! Arrange your Ships on your grid below.", player.name);
                Console.WriteLine();

                gameMenu(player);
            }
            else if (selection.Equals("i"))
            {
                getGameInstructions();
                startMenu(player);
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



            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            Console.WriteLine();    

        }

        public void gameMenu(Player player)
        {
            prepareStartMap(player);
            

            foreach(Ship piece in gamepieces)
            {
               // piece.xCoordinate = 2;// tells each piece where to start
              //  piece.yCoordinate = 1;//

              // resetShipPlacement(piece, player); // sets the start location at top left corner. 

                player.moveShipOnMap(player.map, piece);
                //piece.AddShipToMap(player.map, piece);
            }

            //attackPlayer(player);
            /*
            for(int piece = 0; piece < gamepieces.Length; piece++)
            {
                player.moveShipOnMap(map, gamepieces[piece]);
                gamepieces[piece].AddShipToMap(map, gamepieces[piece].gamePiece);
            }
            */

            /*
            for(int i = 0; i< gamepieces.Length; i++)
            {
                piece.xCoordinate = 2;// tells each piece where to start
                 piece.yCoordinate = 1;//

                resetShipPlacement(piece, player);

                for (int j = 0; j < gamepieces.Length; j++)
                {
                    player.moveShipOnMap(player.map, piece);
                    piece.AddShipToMap(player.map, piece);
                }
            }*/




        }

        public void resetShipPlacement(Ship ship, Player player)
        {
            player.map.map[ship.yCoordinate][ship.xCoordinate + ship.sizeOfShip - 1] = "X";

        }

 

        public void prepareStartMap(Player player)
        {
            player.map.fillMap(11,11);
            player.map.drawMap();
        }


        public void attackPlayer(Player player)
        {
            Console.WriteLine("Enter Coordinates: ");
            string coordinates = Console.ReadLine();

            coordinates = coordinates.ToUpper();
            var newCoord = seperateCoordinates(coordinates, player);

            bool hit = didYouHitAShip(player,newCoord);

        }

        
       



        public Tuple<int, int> seperateCoordinates(string coord, Player player)
        {
            

            foreach (char x in coord)
            {
                
                //bool result = integer.TryParse(x.ToString(), out integer);
                if(int.TryParse(x.ToString(), out xcoord) == true)
                {
                    //Console.WriteLine("We got an integer");
                    //xcoord += 2;
                }
                else
                {
                   // Console.WriteLine("We got a letter");
                   
                    ycoord = player.map.numberCoordinates[x.ToString()];
                   
                }
 
            }

           // Console.WriteLine("[{0},{1}]", ycoord, xcoord);
            //Console.WriteLine("B: {0} , 2: {1}", ycoord, xcoord);

            player.CoorLogi.AllCoordinates.Add(new Tuple<int, int>(ycoord, xcoord));

           var  currentAttack = new Tuple<int, int>(xcoord, ycoord);

           // Console.WriteLine(currentAttack);
            return currentAttack;


        }

        public bool didYouHitAShip(Player player, Tuple <int, int> coord)
        {
           bool hit =  player.CoorLogi.shipCoordinates[0].Contains(coord);

            if(hit == true)
            {
                displayHitShip(player.map);
                Console.WriteLine("You just HIT a ship!!");
                
               
            }
            else
            {
                displayMissedShot(player.map);
                Console.WriteLine("You just missed!");

            }

            return hit;
         
        }

        public void displayHitShip(Map map)
        {
           // map.drawMap();
            try
            {
                //Console.WriteLine("X: {0}, Y: {1}", this.xcoord, this.ycoord);
                //Console.WriteLine(map.map.Count);

                map.map[this.xcoord][this.ycoord] = "*";
                map.drawMap();
                
                

            } catch(Exception e)
            {
                Console.WriteLine("Out of range");
            }
            
        }


        public void displayMissedShot(Map map)
        {
            // map.drawMap();
            try
            {
                //Console.WriteLine("X: {0}, Y: {1}", this.xcoord, this.ycoord);
                //Console.WriteLine(map.map.Count);

                map.map[this.xcoord][this.ycoord] = "X";
                map.drawMap();
            }
            catch (Exception e)
            {
                Console.WriteLine("Out of range");
            }

        }


        public void turnSwitcher(Player player1, Player player2)
        {
            while (noWinner)
            {
                Console.WriteLine("Player 1: ");
                attackPlayer(player2);

                Console.WriteLine();

                Console.WriteLine("Player 2:");
                attackPlayer(player1);

            }
        }

    }
}
