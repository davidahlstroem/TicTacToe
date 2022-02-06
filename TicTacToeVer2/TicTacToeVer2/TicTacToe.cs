using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeVer2
{
    class TicTacToe
    {
        Board board1;
        Player player1;
        Player player2;
        Player currentPlayer;
        
        public string val = "";
        public int bordstorlek;

        public void StartGame()
        {
            player1 = new Player(Player.Pjäs.X);
            player2 = new Player(Player.Pjäs.O);
            currentPlayer = player1;

            Introduktion();
            while (true)
            {
                Console.Clear();
                board1.PrintBoard(bordstorlek);
                Console.WriteLine();

                if (player1 == currentPlayer)
                {
                    Console.WriteLine("Skriv in din sifferposition: ");
                    int playerpos;
                    if (!int.TryParse(Console.ReadLine(), out playerpos) || !(playerpos < bordstorlek * bordstorlek))
                    {
                        Console.WriteLine("Felaktig input!");
                        System.Threading.Thread.Sleep(1000);
                        continue;
                    }
                    if (board1.IsPositionAvailable(playerpos))
                    {
                        board1.board[playerpos].NuvarandeRuta = currentPlayer.SpelarensPjäs;
                    }
                    else
                    {
                        Console.WriteLine("Rutan är redan spelad!");
                        System.Threading.Thread.Sleep(1000);
                        continue;
                    } 
                }
                if (player2 == currentPlayer)
                {
                    int input = MakeRandomAIMove();
                    board1.board[input].NuvarandeRuta = currentPlayer.SpelarensPjäs;
                }
                if (CheckIfDraw())
                {
                    Console.Clear();
                    board1.PrintBoard(bordstorlek);
                    Console.WriteLine("Spelet blev oavgjort!");
                    Console.WriteLine("Vill du spela igen? Skriv 'Ja' eller 'Nej'.");
                    string val = Console.ReadLine();
                    if (val == "Ja" || val == "ja" || val == "j")
                    {
                        LoadingScreen();
                        board1 = new Board(bordstorlek);
                        continue;
                    }
                    else { break; }
                }
                if (CheckIfWin(Player.Pjäs.X))
                {
                    VinnareX();
                    val = Console.ReadLine();
                    if (val == "Ja" || val == "ja" || val == "j")
                    {
                        LoadingScreen();
                        board1 = new Board(bordstorlek);
                        currentPlayer = player1;
                        continue;
                    }
                    else { break; }
                }
                if (CheckIfWin(Player.Pjäs.O))
                {
                    VinnareO();
                        val = Console.ReadLine();
                    if (val == "Ja" || val == "ja" || val == "j")
                    {
                        LoadingScreen();
                        board1 = new Board(bordstorlek);
                        currentPlayer = player1;
                        continue;
                    }
                    else { break; }
                }
                
                SwapPlayer();
                
            }
        }
        public void Introduktion()
        {
            Console.WriteLine("Välkommen till TicTacToe!");
            Console.WriteLine("Välj storlek på bordet");
            bordstorlek = int.Parse(Console.ReadLine());
            board1 = new Board(bordstorlek);
            Console.WriteLine("Spelare X börjar");
            System.Threading.Thread.Sleep(1000);
            
        }
        public bool CheckIfDraw()
        {
            for (int i = 0; i < board1.board.Count; i++)
            {
                Square square = board1.board[i];
                if (square.NuvarandeRuta == Player.Pjäs.E)
                    return false;
            }
            return true;
        }


        public bool CheckIfWin(Player.Pjäs pjäspos)
        {
            int Sum = 0;
            int x = 0;
            int antalrutor = bordstorlek * bordstorlek;

            //Kolla vågrätt
            for (int i = 0; i < antalrutor; i+=bordstorlek) 
            {
                Sum = 0;
                for (int j = 0; j < bordstorlek; j++)
                {
                    if (board1.board[j+x].NuvarandeRuta == pjäspos)
                    {
                        Sum++;
                    } 
                }
                x += bordstorlek;
                if (Sum == bordstorlek) { return true; }
            }

            // Kolla vertikalt 
            for (int i = 0; i < bordstorlek; i++) 
            {
                Sum = 0;
                x = 0;
                for (int j = 0+i; x < antalrutor;)
                {
                    if (board1.board[j + x].NuvarandeRuta == pjäspos)
                    {
                        Sum++;
                    }
                    x += bordstorlek;
                }
                if (Sum == bordstorlek) { return true; }
            }
            

            //Kollar diagonalt från vänster
            Sum = 0;
            x = 0;
            for (int j = 0; x < antalrutor;)
            {
                if (board1.board[j + x].NuvarandeRuta == pjäspos)
                {
                    Sum++;
                }
                x += bordstorlek+1;
                if (Sum == bordstorlek) { return true; }
            }
            

            //Kollar diagonalt från höger
            Sum = 0;
            x = 0;
            for (int j = bordstorlek - 1; x < antalrutor; j--)
            {
                if (board1.board[j + x].NuvarandeRuta == pjäspos)
                {
                    Sum++;
                }
                x += bordstorlek;
                if (Sum == bordstorlek) { return true; }
            }

            return false;
        }
        public void SwapPlayer()
        {
            if (currentPlayer == player1)
                currentPlayer = player2;
            else
                currentPlayer = player1;
        }
        public void LoadingScreen()
        {
            Console.Clear();
            Console.Write(".");
            System.Threading.Thread.Sleep(300);
            Console.Write(".");
            System.Threading.Thread.Sleep(300);
            Console.Write(".");
            System.Threading.Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("Lycka till!");
            System.Threading.Thread.Sleep(700);
        }
        public void VinnareX ()
        {
            Console.Clear();
            board1.PrintBoard(bordstorlek);
            Console.WriteLine(Player.Pjäs.X + " vann!");
            Console.WriteLine("Vill du spela igen? Skriv 'Ja' eller 'Nej'.");
        }
        public void VinnareO()
        {
            Console.Clear();
            board1.PrintBoard(bordstorlek);
            Console.WriteLine(Player.Pjäs.O + " vann!");
            Console.WriteLine("Vill du spela igen? Skriv 'Ja' eller 'Nej'.");
        }
        public int MakeRandomAIMove()
        {
            List<int> list = new List<int>();
            Random rnd = new Random();
            
            for (int i = 0; i < board1.GetCurrentGameState().Count; i++)
            {
                if (board1.IsPositionAvailable(i) == true)
                {
                    list.Add(i);
                }
            }

            int val = rnd.Next(list.Count-1);
            return list[val];
        }
        public void Player1Plays()
        {

        }
        public void Player2Plays()
        {
            if (player2 == currentPlayer)
            {
                int input = MakeRandomAIMove();
                board1.board[input].NuvarandeRuta = currentPlayer.SpelarensPjäs;
            }
        }
    }
    
}
