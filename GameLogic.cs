using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ex02
{
    internal class GameLogic
    {
        private List<Guess> m_guesses = new List<Guess>();
        private int m_numberOfGusses;
        private StringBuilder m_correctAnswer;

        public int NumberOfGuesses { get; set; }
        public StringBuilder CorrectAnswer
        {
            get
            {
                return m_correctAnswer;
            }
        }


        public GameLogic(int i_numberOfGuesses)
        {
            setRandomStringToGuess();
            NumberOfGuesses = i_numberOfGuesses;
            m_guesses.Capacity = i_numberOfGuesses;
        }

        private void run(StringBuilder i_guessFromUser)
        {
            int bulls = 0, cows = 0;
            checkHowManyCowsAndBulls(i_guessFromUser, ref bulls, ref cows);
            Guess guess = new Guess(i_guessFromUser.ToString(), bulls, cows, isTheCurrentGuessAWin(i_guessFromUser));
            m_guesses.Add(guess);
        }
        private void setRandomStringToGuess()
        {
            Random randomSeed = new Random();
            m_correctAnswer = new StringBuilder(4);
            int numberOfFilledChars = 0;

            while(numberOfFilledChars < m_correctAnswer.Length)
            {
                char c = (char)randomSeed.Next(65, 73);
                if(isCharUniqueInGuess(c,numberOfFilledChars))
                {
                    m_correctAnswer[numberOfFilledChars++] = c;
                }
            }
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


        internal struct Guess
        {
            private string m_guessFromUser { get; set; }
            private int m_bulls { get; set; }
            private int m_cows { get; set; }
            private bool m_isWin { get; set; }

            public Guess(string i_guessFromUser,int i_bulls,int i_cows, bool i_isWin)
            {
                m_guessFromUser = i_guessFromUser;
                m_bulls = i_bulls; 
                m_cows = i_cows;
                m_isWin = i_isWin;
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
