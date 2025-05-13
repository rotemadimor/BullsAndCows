using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal struct Result
    {
        private int m_bulls { get; set; }
        private int m_cows { get; set; }

        public Result (int i_bulls, int i_cows)
        {
            m_bulls = i_bulls;
            m_cows = i_cows;
        }
    }
}
