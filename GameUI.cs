using System;
using System.Collections;
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
        public int NumberOfGuesses { get; set; }

        public GameUI() { }

        public void Start()
        {
            Screen.Clear();
            Console.WriteLine("Type number of guesses:");
            NumberOfGuesses = Convert.ToInt32(Console.ReadLine());
            printEmptyTable();
        }

        public List<char> GetGuessInputFromUser()
        {
            Console.WriteLine("Please type your next guess 'A' to 'H' or 'Q' to quit");
            string input = (Console.ReadLine());
            return input.ToList();
        }

        public void PrintTableWithGuesses(List<Guess<char>> i_guesses)
        {
            Screen.Clear();
            printHeadlineOfTable();
            int numberOfEmptyCells = NumberOfGuesses - i_guesses.Count;
            printGuessesToTable(i_guesses);
            for (int i = 0; i < numberOfEmptyCells; i++)
            {
                Console.WriteLine("|         |          |");
                Console.WriteLine("|=========|==========|");
            }

        }

        private void printEmptyTable()
        {
            Screen.Clear();
            printHeadlineOfTable();

            for (int i = 0; i < NumberOfGuesses; i++)
            {
                Console.WriteLine("|         |          |");
                Console.WriteLine("|=========|==========|");
            }
        }

        private static void printHeadlineOfTable()
        {
            Console.WriteLine("Current board status:");
            Console.WriteLine("|Pins:    |Result:   |");
            Console.WriteLine("|=========|==========|");
            Console.WriteLine("| # # # # |          |");
            Console.WriteLine("|=========|==========|");
        }

        private void printGuessesToTable(List<Guess<char>> i_guesses)
        {
            foreach (Guess<char> guessToPrint in i_guesses)
            {
                printGuess(guessToPrint);
            }
        }

        private static void printGuess(Guess<char> i_guessToPrint)
        {
            string printableGuessSequence = printableUserInputToTable(i_guessToPrint);
            string printableResult = printableResultToTable(i_guessToPrint.ResultOfGuess);

            Console.WriteLine($"| {printableGuessSequence} | {printableResult}  |");
            Console.WriteLine("|=========|==========|");
        }

        private static string printableUserInputToTable(Guess<char> i_guessToPrint)
        {
            string guessSequence = new string(i_guessToPrint.GuessedSequence.ToArray());
            return addSpacesBetweenChars(guessSequence);  
        }

        private static string printableResultToTable(Result i_resultToPrint)
        {
            int numberOfSpaces = 4 - i_resultToPrint.Bulls - i_resultToPrint.Cows;
            List<char> toPrintResult = new List<char>(4);
            for (int b = 0; b < i_resultToPrint.Bulls; b++)
            {
                toPrintResult.Add('V');
            }
            for (int c = 0; c < i_resultToPrint.Cows; c++)
            {
                toPrintResult.Add('X');
            }
            for(int s = 0;  s < numberOfSpaces; s++)
            {
                toPrintResult.Add(' ');
            }
            string printableResult = new string(toPrintResult.ToArray());
            return addSpacesBetweenChars(printableResult);
        }

        public void PrintGameSummeryWin(List<Guess<char>> i_guesses)
        {
            Screen.Clear();
            PrintTableWithGuesses(i_guesses);
            Console.WriteLine($"You guessed after {i_guesses.Count} steps!");
        }

        public void PrintGameSummeryLose(List<Guess<char>> i_guesses)
        {
            Screen.Clear();
            PrintTableWithGuesses(i_guesses);
            Console.WriteLine("No more guesses allowed. You Lost.");
        }

        private static string addSpacesBetweenChars(string i_input)
        {
            return string.Join(" ", i_input.ToCharArray());
        }
    }
}
