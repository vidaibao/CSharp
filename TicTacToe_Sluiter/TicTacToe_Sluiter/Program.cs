using BoardLogic;

namespace TicTacToe_Sluiter
{
    internal class Program
    {
        static Board game = new Board();

        static void Main(string[] args)
        {
            
            printBoard();

            int userTurn = -1;
            int computerTurn = -1;
            Random rand = new Random();

            while (game.Check4Winner() == 0)
            {
                
                // DON'T doublicate choose
                while (userTurn == -1 || game.Grid[userTurn] != 0)
                {
                    Console.WriteLine("Please enter a number from 0 - 8 \n012\n345\n678");
                    userTurn = int.Parse(Console.ReadLine());
                    if (userTurn > 8)
                    {
                        Console.WriteLine("Invalid number. Try again!");
                        continue;
                    }
                    else if (userTurn < 0)
                    {
                        return;
                    }
                    Console.WriteLine($"You typed {userTurn}");

                }
                game.Grid[userTurn] = 1;

                if (IsBoardFull() == 1)
                {
                    if (ConfirmGame() == 0)
                        continue;
                    break;
                }

                // DON'T doublicate choose
                while (computerTurn == -1 || game.Grid[computerTurn] != 0) 
                {
                    computerTurn = rand.Next(8);
                }
                Console.WriteLine($"Computer chooses {computerTurn}");
                game.Grid[computerTurn] = 2;

                if (IsBoardFull() == 1)
                {
                    if (ConfirmGame() == 0)
                    {
                        continue;
                    }
                    break;
                }
                printBoard();
            }

            Console.WriteLine($"Player {game.Check4Winner()} won the game!");
            printBoard();

        }


        // return 0 if ok, 1 if no more place to pick
        private static int IsBoardFull()
        {
            // check space to pick 
            for (int i = 0; i < 9; i++)
                if (game.Grid[i] == 0)
                    return 0;

            //
            return 1;// ConfirmGame();
        }


        
        // return 0 if continue, 1 any key if no then exit game
        private static int ConfirmGame()
        {
            Console.WriteLine("No winner.");
            Console.WriteLine("Do you like continue game? (y/n)");
            Console.WriteLine("Press any key to exit.");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            int res = 1;
            if (keyInfo.Key == ConsoleKey.Y)
            {
                Console.WriteLine("That's great!");
                ResetBoard();
                return 0;
            }
            else if (keyInfo.Key == ConsoleKey.N)
            {
                Console.WriteLine("That's too bad.");
            }
            else
            {
                
            }

            return res;
        }

        private static void ResetBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                game.Grid[i] = 0;
            }
            printBoard();
        }

        private static void printBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                // print the board
                //Console.WriteLine($"Squre {i} contains {board[i]}");

                // print X or O for each square
                // 0 means unoccupied. 1 means player 1 (X) , 2 means player 2 (O)
                if (game.Grid[i] == 0) Console.Write(".");
                if (game.Grid[i] == 1) Console.Write("X");
                if (game.Grid[i] == 2) Console.Write("O");
                if ((i + 1) % 3 == 0) Console.WriteLine();
            }
        }
    }
}