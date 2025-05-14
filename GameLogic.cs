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
        private List<Guess<T>> m_listOfGuesses;
        private int m_numberOfGusses;
        private Guess<T> m_correctAnswer;

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
            bool isAddedToList = false;
            Guess<T> guess = new Guess<T>(i_guessFromUser, i_itemsToChooseFrom);

            if(guess.GuessedSequence.Count != 0)
            {
                checkHowManyCowsAndBulls(i_guessFromUser, guess.ResultOfGuess.Bulls, guess.ResultOfGuess.Cows);
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
            bool isTheCurrentGuess = false;
            if (i_guessFromUser.ResultOfGuess.Bulls == 4) 
            {
                isTheCurrentGuess = true;
            }
            return isTheCurrentGuess;
        }
        public void checkHowManyCowsAndBulls(List<T> i_guessFromUser, int bulls, int cows)
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

        private bool isCellBull(List<T> i_guessFromUser, int index)
        {
            return i_guessFromUser[index].Equals(CorrectAnswer.GuessedSequence[index]);
        }

        public bool IsFailedGame()
        {
            bool isFailedGame = false;
            if(ListOfGuesses.Count == NumberOfGuesses && !IsTheCurrentGuessAWin(ListOfGuesses[NumberOfGuesses-1]))
            {
                isFailedGame = true;
            }
            return isFailedGame;
        }

        public bool IsUserQuitGame(List<T> i_inputFromUser, List<T> i_quitingInput)
        {
            bool isUserQuitGame = false;    
            if(i_inputFromUser.Equals(i_quitingInput))
            {
                isUserQuitGame = true;
            }
            return isUserQuitGame;
        }

    }
}
