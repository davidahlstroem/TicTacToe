using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeVer2
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe startgame = new TicTacToe();
            startgame.StartGame();


            Console.ReadLine();
        }
    }
}
