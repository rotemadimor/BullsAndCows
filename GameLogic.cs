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

        private void setRandomStringToGuess()
        {
            Random randomSeed = new Random();
            m_correctAnswer = new StringBuilder(4);
            int numberOfFilledChars = 0;

            while(numberOfFilledChars < m_correctAnswer.Length)
            {
                char c = (char)randomSeed.Next(65, 73);
                if(isUnique(c,numberOfFilledChars))
                {
                    m_correctAnswer[numberOfFilledChars++] = c;
                }
            }
        }

        private bool isUnique(char i_charToCheck, int i_indexToCheck)
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


        private struct Guess
        {
            private string m_guessFromUser;
            private int m_bulls;
            private int m_cows;
            private bool m_isWin;

            public Guess(string i_guessFromUser, int i_bulls, int i_cows, bool i_isWin)
            {
                m_guessFromUser = i_guessFromUser;
                m_bulls = i_bulls;
                m_cows = i_cows;
                m_isWin = i_isWin;
            }
        }
    }
}
