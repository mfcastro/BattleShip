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

        public void drawMap()
        {
                       
            for(int i = 0; i<map.Count; i++)
            {
                for(int j = 0;j < map[i].Count; j++)
                {
                    Console.Write(map[i][j] + " ");
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
                        map[row].Add("X");
                    }
                    
                }

                }

            }
        }
    }

