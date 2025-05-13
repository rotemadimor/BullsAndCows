using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class Guess<T>
    {
        private T m_guessFromUser { get; set; }
        private Result m_result;
        //private bool m_isWin { get; set; }

        public Guess(T i_guessFromUser, int i_bulls, int i_cows /*,bool i_isWin*/)
        {
            m_guessFromUser = i_guessFromUser;
            m_result = new Result( i_bulls, i_cows );
            //m_isWin = i_isWin;
        }
    }
}
