using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ex02
{
    internal class GameUI
    {
        private int m_numberOfGuesses;
        private int nisayon;
        public GameUI() { }
        public void Start()
        {
            char[,] table = new char[24, 19];
            for(int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    if(j == 0 || j == 10 || j == 18)
                    {
                        table[i, j] = '|';
                    }
                    else if (i % 2 != 0)
                    {
                        table[i, j] = '=';
                    }
                    else
                    {
                        table[i, j] = ' ';
                    }
                }
                
            }
            printTable(table);
            Console.ReadLine();
        }

        private static void printTable(char[,] table)
        {
            for(int i = 0; i < 24; i++)
            {
                for(int j = 0; j < 19; j++)
                {
                    Console.Write(table[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
