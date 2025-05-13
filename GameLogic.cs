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
        private List< Guess<T>> m_guesses = new List< Guess<T>>();
        private int m_numberOfGusses;
        private  Guess<T> m_correctAnswer;

        public int NumberOfGuesses { get; set; }
        public  Guess<T> CorrectAnswer
        {
            get
            {
                return m_correctAnswer;
            }
        }


        public GameLogic(int i_numberOfGuesses)
        {
            setRandomCorrectAnswer();
            NumberOfGuesses = i_numberOfGuesses;
            m_guesses.Capacity = i_numberOfGuesses;
        }

        private void addGuessToList(StringBuilder i_guessFromUser)
        {
            int bulls = 0, cows = 0;
            checkHowManyCowsAndBulls(i_guessFromUser, ref bulls, ref cows);
            Guess<T> guess = new Guess<T>(i_guessFromUser.ToString(), bulls, cows /*,isTheCurrentGuessAWin(i_guessFromUser)*/);
            m_guesses.Add(guess);
        }
        private void setRandomCorrectAnswer()
        {
            Random randomSeed = new Random();
            int numberOfFilledChars = 0;

            while(numberOfFilledChars < m_correctAnswer.Length)
            {
                char c = (char)randomSeed.Next(65, 73);
                if(isCharUniqueInGuess(c,numberOfFilledChars))
                {
                    m_correctAnswer[numberOfFilledChars++] = c;
                }
            }

            m_correctAnswer = new Guess<T>(/*m_correctAnswer.ToString()*/ 0, 0 /*,false*/);
        }

        private bool isCharUniqueInGuess(char i_charToCheck, int i_indexToCheck)
        {
            bool isUnique = true;
            for(int index = i_indexToCheck; index > 0; index--)
            {
                if(i_charToCheck == (char)CorrectAnswer[index])
                {
                    isUnique = false;
                }
            }

            return isUnique;
        }
        private bool isTheCurrentGuessAWin(StringBuilder i_guessFromUser)
        {
            bool isWin = true;
            if (!isGuessValid(i_guessFromUser))
            {
                isWin = false;
            }
            else
            {
                for (int index = 0; index < m_correctAnswer.Length; index++)
                {
                    if (i_guessFromUser[index] != m_correctAnswer[index])
                    {
                        isWin = false;
                    }
                }
            }
            return isWin;


            // if (bulls == 4)
            //return true;
        }
        public void checkHowManyCowsAndBulls(StringBuilder i_guessFromUser, ref int bulls, ref int cows)
        {
            for (int index = 0; index < m_correctAnswer.Length; index++)
            {
                if (i_guessFromUser[index] == m_correctAnswer[index])
                {
                    bulls++;
                }
                else if (m_correctAnswer.ToString().Contains(i_guessFromUser[index]))
                {
                    cows++;
                }
            }

        }
        private bool isGuessValid(StringBuilder i_guessFromUser)
        {
            bool isValid = true;
            if (i_guessFromUser.Length != m_correctAnswer.Length)
            {
                isValid = false;
            }
            else
            {
                for (int index = 0; index < i_guessFromUser.Length; index++)
                {
                    if (!isCharUniqueInGuess(i_guessFromUser[index], index))
                    {
                        isValid = false;
                    }
                    else if (i_guessFromUser[index] < 65 || i_guessFromUser[index] > 72)
                    {
                        isValid = false;
                    }
                }
            }
            return isValid;
        }
        private bool isFailedGame()
        {
            return false;
        }

        private bool isUserQuitGame()
        {
            return false;
        }


        }

        private bool isFailedGame()
        {
            return false;
        }

        private bool isUserQuitGame()
        {
            return false;
        }


        }

        private bool isFailedGame()
        {
            return false;
        }

        private bool isUserQuitGame()
        {
            return false;
        }


    }
}
