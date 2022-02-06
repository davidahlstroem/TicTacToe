using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeVer2
{
    class Player
    {
        public enum Pjäs
        {
            E, X, O
                
        }

        public Pjäs SpelarensPjäs
        {
            get;
            private set;
            
        }
        public Player(Player.Pjäs _argument)
        {
            SpelarensPjäs = _argument;
        }
    }
}
