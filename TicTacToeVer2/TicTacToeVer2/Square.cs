using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeVer2
{
    class Square
    {
        public Player.Pjäs NuvarandeRuta
        {
            get;
            set;
        }
        public Square(Player.Pjäs _argument)
        {
            NuvarandeRuta = _argument;
        }

    }
}
