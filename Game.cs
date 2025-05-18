using Ex02.ConsoleUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class Game
    {
        private GameUI m_gameUI = new GameUI();
        private GameLogic<char> m_gameLogic;
        private bool m_isGameOn;
        private readonly List<char> m_itemsToChooseFromToGuess = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
        private readonly List<char> m_quitingInput = new List<char> { 'Q' };


        public void GameLoop()
        {
            m_isGameOn = true;
            while (m_isGameOn)
            {
                m_gameUI.Start();
                m_gameLogic = new GameLogic<char>(m_gameUI.NumberOfGuesses, m_itemsToChooseFromToGuess);
                for (int i = 0; i < m_gameUI.NumberOfGuesses && m_isGameOn; i++)
                {
                    List<char> userInput = m_gameUI.GetGuessInputFromUser();
                    if (m_gameLogic.IsUserQuitGame(userInput, m_quitingInput))
                    {
                        m_isGameOn = false;
                        break;
                    }
                    if (!m_gameLogic.addGuessToList(userInput, m_itemsToChooseFromToGuess))
                    {
                        i--;
                        continue;
                    }
                    else
                    {
                        m_gameUI.PrintTableWithGuesses(m_gameLogic.ListOfGuesses, false, m_gameLogic.CorrectAnswer);
                        if (m_gameLogic.IsTheCurrentGuessAWin(m_gameLogic.ListOfGuesses[i]))
                        {
                            m_gameUI.PrintGameSummery(m_gameLogic.ListOfGuesses,false,m_gameLogic.CorrectAnswer);
                        }
                        else if (m_gameLogic.IsFailedGame())
                        {
                            m_gameUI.PrintGameSummery(m_gameLogic.ListOfGuesses, true, m_gameLogic.CorrectAnswer);
                        }
                        else
                        {
                            continue;
                        }
                        isContinueToANewGame();
                        break;
                    }
                }

            }
        }

        public void PrintGoodbye()
        {
            Console.WriteLine("Bye Bye!! press any key to continue...");
            Console.ReadLine();
        }

        private void isContinueToANewGame()
        {
            Console.WriteLine("Would you like to start a new game? (Y/N)");
            string userAnswer = Console.ReadLine();
            if (userAnswer == "N")
            {
                m_isGameOn = false;
            }
        }
    }
}
