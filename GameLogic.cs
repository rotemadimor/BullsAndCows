using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ex02
{
    internal class GameLogic<T>
    {
        public List<Guess<T>> ListOfGuesses { get; set; }
        public int NumberOfGuesses { get; set; }
        public Guess<T> CorrectAnswer { get; set; }

        public GameLogic(int i_numberOfGuesses, List<T> i_itemsToChooseFrom)
        {
            setRandomCorrectAnswer(i_itemsToChooseFrom);
            NumberOfGuesses = i_numberOfGuesses;
            ListOfGuesses = new List<Guess<T>>(NumberOfGuesses);
        }

        public bool addGuessToList(List<T> i_guessFromUser, List<T> i_itemsToChooseFrom)
        {
            bool isAddedToList;
            int bulls = 0, cows = 0;
            Guess<T> guess = new Guess<T>(i_guessFromUser, i_itemsToChooseFrom);
            
            if (!guess.IsGuessValid(i_guessFromUser, i_itemsToChooseFrom))
            {
                isAddedToList = false;
            }
            else
            {
                checkHowManyCowsAndBulls(i_guessFromUser, ref bulls, ref cows);
                guess.ResultOfGuess = new Result(bulls, cows);
                ListOfGuesses.Add(guess);
                isAddedToList = true;
            }
            return isAddedToList;
        }

        private void setRandomCorrectAnswer(List<T> i_itemsToChooseFrom)
        {
            Random random = new Random();
            CorrectAnswer = new Guess<T>(i_itemsToChooseFrom, random);
        }

        public bool IsTheCurrentGuessAWin(Guess<T> i_guessFromUser)
        {
            bool isTheCurrentGuess = (i_guessFromUser.ResultOfGuess.Bulls == 4);

            return isTheCurrentGuess;
        }

        public void checkHowManyCowsAndBulls(List<T> i_guessFromUser, ref int bulls, ref int cows)
        {
            for (int index = 0; index < i_guessFromUser.Count; index++)
            {
                if (isCellBull(i_guessFromUser, index))
                {
                    bulls++;
                }
                else if (isCellCow(i_guessFromUser, index))
                {
                    cows++;
                }
            }
        }

        private bool isCellCow(List<T> i_guessFromUser, int index)
        {
            return i_guessFromUser.Contains(CorrectAnswer.GuessedSequence[index]);
        }

        private bool isCellBull(List<T> i_guessFromUser, int i_index)
        {
            return i_guessFromUser[i_index].Equals(CorrectAnswer.GuessedSequence[i_index]);
        }

        public bool IsFailedGame()
        {
            bool isFailedGame = ListOfGuesses.Count == NumberOfGuesses && !IsTheCurrentGuessAWin(ListOfGuesses[NumberOfGuesses-1]);
            return isFailedGame;
        }

        public bool IsUserQuitGame(List<T> i_inputFromUser, List<T> i_quitingInput)
        {
            bool isUserQuitGame = i_inputFromUser.Equals(i_quitingInput);
            return isUserQuitGame;
        }

    }
}
