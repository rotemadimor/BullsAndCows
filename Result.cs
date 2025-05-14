using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal struct Result
    {
        public int Bulls { get; set; }
        public int Cows { get; set; }
        public Result(int i_bulls, int i_cows)
        {
            Bulls = i_bulls;
            Cows = i_cows;
        }
    }
}
