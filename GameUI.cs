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
        public int NumberOfGuesses { get; set; }
        const int k_numberOfItemsInGuess = 4;
        const int k_minNumberOfGuesses = 4;
        const int k_maxNumberOfGuesses = 10;
        const char k_bullChar = 'V';
        const char k_cowChar = 'X';
        const char k_wrongGuessChar = ' ';

        public GameUI() { }

        public void Start()
        {
            Screen.Clear();
            getNumberOfGuessesFromUser();
            printEmptyTable(false, null);
        }

        private void getNumberOfGuessesFromUser()
        {
            Console.WriteLine("Type number of guesses (4-10):");
            NumberOfGuesses = Convert.ToInt32(Console.ReadLine());
            while (NumberOfGuesses > k_maxNumberOfGuesses || NumberOfGuesses < k_minNumberOfGuesses)
            {
                Console.WriteLine("Invalid number of guesses");
                Console.WriteLine("Type number of guesses(4-10):");
                NumberOfGuesses = Convert.ToInt32(Console.ReadLine());
            }
        }

        public List<char> GetGuessInputFromUser()
        {
            Console.WriteLine("Please type your next guess 'A' to 'H' or 'Q' to quit");
            string input = (Console.ReadLine());
            return input.ToList();
        }

        public void PrintTableWithGuesses(List<Guess<char>> i_guesses, bool i_isGameLost, Guess<char> i_correctAnswer)
        {
            Screen.Clear();
            printHeadlineOfTable(i_isGameLost,i_correctAnswer);
            int numberOfEmptyCells = NumberOfGuesses - i_guesses.Count;
            printGuessesToTable(i_guesses);
            for (int i = 0; i < numberOfEmptyCells; i++)
            {
                Console.WriteLine("|         |          |");
                Console.WriteLine("|=========|==========|");
            }

        }

        private void printEmptyTable(bool i_isGameLost, Guess<char> i_correctAnswer)
        {
            Screen.Clear();
            printHeadlineOfTable(i_isGameLost, i_correctAnswer);

            for (int i = 0; i < NumberOfGuesses; i++)
            {
                Console.WriteLine("|         |          |");
                Console.WriteLine("|=========|==========|");
            }
            

        }

        private static void printHeadlineOfTable(bool i_isGameLost, Guess<char> i_correctAnswer)
        {
            Console.WriteLine("Current board status:");
            Console.WriteLine("|Pins:    |Result:   |");
            Console.WriteLine("|=========|==========|");
            if (i_isGameLost)
            {
                printGuess(i_correctAnswer);
            }
            else
            {
            Console.WriteLine("| # # # # |          |");
            Console.WriteLine("|=========|==========|");
            }
           
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
            int numberOfSpaces = k_numberOfItemsInGuess - i_resultToPrint.Bulls - i_resultToPrint.Cows;
            List<char> toPrintResult = new List<char>(k_numberOfItemsInGuess);
            for (int b = 0; b < i_resultToPrint.Bulls; b++)
            {
                toPrintResult.Add(k_bullChar);
            }
            for (int c = 0; c < i_resultToPrint.Cows; c++)
            {
                toPrintResult.Add(k_cowChar);
            }
            for(int s = 0;  s < numberOfSpaces; s++)
            {
                toPrintResult.Add(k_wrongGuessChar);
            }
            string printableResult = new string(toPrintResult.ToArray());
            return addSpacesBetweenChars(printableResult);
        }

  
        public void PrintGameSummery(List<Guess<char>> i_guesses, bool i_isGameLost, Guess<char> i_correctAnswer)
        {
            Screen.Clear();
            PrintTableWithGuesses(i_guesses, i_isGameLost, i_correctAnswer);
            if (i_isGameLost)
            {
                Console.WriteLine("No more guesses allowed. You Lost.");
            }
            else
            {
                Console.WriteLine($"You guessed after {i_guesses.Count} steps!");
            }
            }

        private static string addSpacesBetweenChars(string i_input)
        {
            return string.Join(" ", i_input.ToCharArray());
        }
    }
}
