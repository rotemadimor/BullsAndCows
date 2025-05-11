using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class Game
    {
        private GameUI m_gameUI;
        private GameLogic m_gameLogic;


        public void Start()
        {
            m_gameUI.start();

            GameLoop();
        }

        public void GameLoop()
        {
            m_gameUI.start();
        }

    }
}
