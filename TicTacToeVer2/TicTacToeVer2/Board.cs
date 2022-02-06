using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeVer2
{
    class Board
    {
        public List<Square> board = new List<Square>();

        public Board (int storlek) //konstruktor
        {
            storlek = storlek * storlek;

            for (int i = 0; i < storlek; i++)
            {
                board.Add(new Square(Player.Pjäs.E));
            }

        }
        public List<Square> GetCurrentGameState()
        {
            return board;
        }
        public bool IsPositionAvailable(int pos)
        {
            List<Square> list = GetCurrentGameState();
            if (list[pos].NuvarandeRuta == Player.Pjäs.E)
            {
                return true;
            }
            else
                return false;
        }

        // skriver ut sålänge som storleken (tex 3) är större än kolomnen, 
        // och sen tillbaka till första loopen som skriver allt igen på nästa rad.
        // if satsen kollar så att man inte skriver ut mer än vad listans längd är

        public void PrintBoard(int _storlek)
        {
            List<Square> list = GetCurrentGameState();
            int x = 0;

            Console.WriteLine();
            for (int vågrät = 0; vågrät < _storlek; vågrät++) // skriv detta sålänge storleken är större än vågrät
            {
                Console.Write("| ");
                for (int vertikal = 0; vertikal < _storlek; vertikal++) // skriver ut sålänge storleken (tex 3) är större än kolomnen, och sen tillbaka till första loopen som skriver allt igen på nästa rad.
                {
                    if (!(x == (_storlek * _storlek)))
                        Console.Write(list[x].NuvarandeRuta);
                        Console.Write(" | ");
                        x++; 
                }
                Console.WriteLine();
                for (int i = 0; i < _storlek; i++) // gör det lite finare
                {
                    Console.Write("----");
                }
                Console.WriteLine();
            }
        }
        


    }
}
