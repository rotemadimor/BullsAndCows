using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex02.ConsoleUtils;


namespace Ex02
{
    internal class GameUI
    {
        private int m_numberOfGuesses;
        //private guess guesses;

        public GameUI() { }
        public void Start()
        {
            Console.WriteLine("Type number of guesses:");
            m_numberOfGuesses = Convert.ToInt32(Console.ReadLine());
            Screen.Clear();
            printTable(m_numberOfGuesses);
        }

        private static void printTable(int i_numberOfGuesses)
        {
            
            Console.WriteLine("Current board status:");
            Console.WriteLine("|Pins:    |Result:   |");
            Console.WriteLine("|=========|==========|");

            for(int i = 0; i < i_numberOfGuesses; i++)
            {
                Console.WriteLine("|         |          |");
                Console.WriteLine("|=========|==========|");
            }
            Console.ReadLine();
        }

        private void printGuessToTable()
        {
            printUserInputToTable();
            printResultToTable();
        }
        private void printUserInputToTable()
        {

        }

        private void printResultToTable()
        {

        }

        private void printGameSummery()
        {

        }

    }
}
