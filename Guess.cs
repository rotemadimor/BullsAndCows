using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class Guess<T>
    {
        private const int k_NumberOfItemsInGuess = 4;
        public List<T> GuessedSequence { get; set; }
        public Result ResultOfGuess { get; set; }
        
        public Guess(List<T> i_guessFromUser, int i_bulls, int i_cows)
        {
            GuessedSequence = new List<T>(i_guessFromUser);
            ResultOfGuess = new Result(i_bulls, i_cows);
        }

        public Guess(List<T> i_guessFromUser, List<T> i_itemsToChooseFrom)
        {
           GuessedSequence = new List<T>(i_guessFromUser);
        }

        public Guess(List<T> i_itemsToChooseFrom, Random i_randomSeed)
        {
            GuessedSequence = setRandomT(i_itemsToChooseFrom, i_randomSeed);
            ResultOfGuess = new Result(0, 0);
        }

        private List<T> setRandomT(List<T> i_itemsToChooseFrom, Random i_randomSeed)
        {
            List<T> randomGuess = new List<T>(k_NumberOfItemsInGuess);
            int numberOfFilledCells = 0;
            while(numberOfFilledCells < k_NumberOfItemsInGuess)
            {
                T randomCell = GetRandomFromList(i_itemsToChooseFrom, i_randomSeed);
                if (isCellUniqueInGuess(randomCell, numberOfFilledCells,randomGuess))
                {
                    randomGuess.Add(randomCell);
                    numberOfFilledCells++;
                }
            }

            return randomGuess;
        }

        public T GetRandomFromList(List<T> i_itemsToChoose, Random i_randomSeed)
        {
            int index = i_randomSeed.Next(i_itemsToChoose.Count);
            return i_itemsToChoose[index];
        }

        private bool isCellUniqueInGuess(T i_cellToCheck, int i_indexToCheck, List<T> i_arrayToCheck)
        {
            bool isUnique = true;

            for (int index = 0; index < i_indexToCheck; index++)
            {
                if (i_cellToCheck.Equals(i_arrayToCheck[index]))
                {
                    isUnique = false;
                }
            }

            return isUnique;
        }

        public bool IsGuessValid(List<T> i_guessSequenceFromUser, List<T> i_itemsToChooseFrom)
        {
            bool isValid = true;
            int index = 0;

            foreach (T guess in i_guessSequenceFromUser)
            {
                if (i_guessSequenceFromUser.Count != k_NumberOfItemsInGuess || guess.GetType() != typeof(T))
                {
                    Console.WriteLine("Invalid input: 4 characters required");
                    isValid = false;
                    break;
                }
                else if (!char.IsLetter(char.Parse(guess.ToString())))
                {
                    Console.WriteLine("Invalid input: input must contain english letters only");
                    isValid = false;
                    break;
                }
                else if (!isCellUniqueInGuess(guess,index, i_guessSequenceFromUser))
                {
                    Console.WriteLine("Invalid input: input must contain unique english letters ");
                    isValid = false;
                    break;
                }
                else if (!i_itemsToChooseFrom.Contains(guess))
                {
                    Console.WriteLine("Invalid input: input must contain uppercase letters between A and H only");
                    isValid = false;
                    break;
                }
                index++;
            }

            return isValid;
        }
    }
}
