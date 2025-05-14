using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class Guess<T>
    {
        private Result m_result;
        private List<T> m_guessedSequence;
        public List<T> GuessedSequence { get; set; }
        public Result ResultOfGuess { get; set; }
        
        public Guess(List<T> i_guessFromUser, int i_bulls, int i_cows)
        {
            m_guessedSequence = i_guessFromUser;
            m_result = new Result(i_bulls, i_cows);
        }
        public Guess(List<T> i_guessFromUser, List<T> i_itemsToChooseFrom)
        {
            if (isGuessValid(i_guessFromUser, i_itemsToChooseFrom))
            {
                GuessedSequence = i_guessFromUser;
            }
            else
            {
                m_guessedSequence.Clear();
            }
        }
        public Guess(List<T> i_itemsToChooseFrom, Random i_randomSeed)
        {
            GuessedSequence = setRandomT(i_itemsToChooseFrom, i_randomSeed);
            ResultOfGuess = new Result();
            ResultOfGuess.Bulls = GuessedSequence.Count;
        }
        private List<T> setRandomT(List<T> i_itemsToChooseFrom, Random randomSeed)
        {
            List<T> randomGuess = new List<T>(4);
            int numberOfFilledCells = 0;
            while(numberOfFilledCells < 4)
            {
                T randomCell = GetRandomFromList(i_itemsToChooseFrom, randomSeed);
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
        private bool isGuessValid(List<T> i_guessSequenceFromUser, List<T> i_itemsToChooseFrom)
        {
            bool isValid = true;
            if (i_guessSequenceFromUser.Count != 4)
            {
                isValid = false;
            }
            else
            {
                foreach (T guess in i_guessSequenceFromUser)
                {
                    if (!i_itemsToChooseFrom.Contains(guess))
                    {
                        isValid = false;
                    } 
                }
            }
            return isValid;
        }
    }
}
