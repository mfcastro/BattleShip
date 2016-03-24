using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Map
    {
        public List<List<string>> map = new List<List<string>>();

        string[] alphabet = {" ","  ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K" , "L", "M", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "BB", "CC" };

        public Dictionary<string, int> numberCoordinates =  new Dictionary<string, int>(){ {"A" , 2} , {"B" , 3 }, {"C", 4 }, {"D", 5 }, {"E" , 6 }, {"F", 7 }, {"G",8 }, {"H",9 }, {"I",10 }, {"J", 11}, {"K", 12}, {"L",13}, {"M",14 }, {"N", 15  }, {"O", 16 }, {"P", 17 }, {"Q", 18 }, {"R", 19 }, {"S", 20}, {"T",21 }, {"U", 22}, {"V",23 }, {"W",24 }, {"X",25 }, {"Y",26 }, {"Z",27 } };

        public int mapLength = 11;
        public int mapWidth = 11;


        public void drawMap()
        {

            for (int i = 0; i < map.Count; i++)
            {

                
                for (int j = 0; j < map[i].Count; j++)
                {
                    if (map[i][j] == "*")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(map[i][j] + " ");
                    }
                    else if (map[i][j] == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(map[i][j] + " ");
                    }
                    else if (i == 0 || j == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(map[i][j] + " ");
                    }
                    else if (map[i][j] == "A" || map[i][j] == "B" || map[i][j] == "S" || map[i][j] == "D" || map[i][j] == "P")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(map[i][j] + " ");
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.Write(map[i][j] + " ");
                    }
                }
                Console.WriteLine();
            }
      }


        public void drawOwnMap()
        {
          
            for (int i = 0; i < map.Count; i++)
            {

                for (int j = 0; j < map[i].Count; j++)
                {
                    if (map[i][j] == "*")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(map[i][j] + " ");
                    }
                    else if (map[i][j] == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(map[i][j] + " ");
                    }
                    else if (i == 0 || j == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write(map[i][j] + " ");
                    }
                    else if (map[i][j] == "A" || map[i][j] == "B" || map[i][j] == "S" || map[i][j] == "D" || map[i][j] == "P")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(map[i][j] + " ");
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.Write(map[i][j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }


        public void fillMap(int length, int width)
        {
            
            for(int row = 0; row < length; row++)
            {
                map.Add(new List<string>());

                for ( int column = 0; column < width; column++)
                {
                    if(row  == 0)
                    {
                        map[row].Add(alphabet[column].ToString());
                    }

                    else if (column == 0)
                    {
                        if(row < 10) {
                            map[row].Add(String.Format(" {0}", row.ToString()));
                        }
                        else
                        {
                            map[row].Add(row.ToString());
                        }
                        
                    }
                   
                    else if(column == 1)
                    {
                        map[row].Add(" ");
                    }
 
                    else
                    {
                        map[row].Add("?");
                    }
                    
                }

                }

            }

        }
    }

