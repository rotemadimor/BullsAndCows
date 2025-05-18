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
        private GameUI m_GameUI = new GameUI();
        private GameLogic<char> m_GameLogic;
        private bool m_IsGameOn;
        private readonly List<char> r_ItemsToChooseFromToGuess = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
        private readonly List<char> r_QuitingInput = new List<char> { 'Q' };

        public void GameLoop()
        {
            m_IsGameOn = true;

            while (m_IsGameOn)
            {
                m_GameUI.Start();
                m_GameLogic = new GameLogic<char>(m_GameUI.NumberOfGuesses, r_ItemsToChooseFromToGuess);
                for (int i = 0; i < m_GameUI.NumberOfGuesses && m_IsGameOn; i++)
                {
                    List<char> userInput = m_GameUI.GetGuessInputFromUser();
                    if (m_GameLogic.IsUserQuitGame(userInput, r_QuitingInput))
                    {
                        m_IsGameOn = false;
                        break;
                    }
                    if (!m_GameLogic.addGuessToList(userInput, r_ItemsToChooseFromToGuess))
                    {
                        i--;
                        continue;
                    }
                    else
                    {
                        m_GameUI.PrintTableWithGuesses(m_GameLogic.ListOfGuesses, false, m_GameLogic.CorrectAnswer);
                        if (m_GameLogic.IsTheCurrentGuessAWin(m_GameLogic.ListOfGuesses[i]))
                        {
                            m_GameUI.PrintGameSummery(m_GameLogic.ListOfGuesses,false,m_GameLogic.CorrectAnswer);
                        }
                        else if (m_GameLogic.IsFailedGame())
                        {
                            m_GameUI.PrintGameSummery(m_GameLogic.ListOfGuesses, true, m_GameLogic.CorrectAnswer);
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
            Console.WriteLine("Bye Bye!!");
        }

        private void isContinueToANewGame()
        {
            Console.WriteLine("Would you like to start a new game? (Y/N)");
            string userAnswer = Console.ReadLine();
            if (userAnswer != null && userAnswer.ToUpper() != "Y")
            {
                m_IsGameOn = false;
            }
        }
    }
}
