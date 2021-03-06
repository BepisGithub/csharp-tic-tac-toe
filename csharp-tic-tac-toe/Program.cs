using System;

namespace csharp_tic_tac_toe
{

    class Player
    {
        public string Name { get; set; }
        public char Symbol { get; set; }

        public bool Active = false;

        public Player(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        public int[] GetCoordChoice()
        {
            Console.WriteLine($"Your symbol is {Symbol}, {Name}");

            Console.WriteLine("What is the x coordinate you would like to choose?");
            int x = Convert.ToInt32(Console.ReadLine());
            while(x < 1 || x > 3)
            {
                Console.WriteLine("Oops, that doesn\'t seem to be valid! Try again");
                x = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("What is the y coordinate you would like to choose?");
            int y = Convert.ToInt32(Console.ReadLine());
            while (y < 1 || y > 3)
            {
                Console.WriteLine("Oops, that doesn\'t seem to be valid! Try again");
                y = Convert.ToInt32(Console.ReadLine());
            }

            int[] Coords = new int[] { --x, --y };
            return Coords;
        }
    }
    class Board
    {
        private char[,] Grid = new char[3, 3];

        public Board()
        {
            for(int Column = 0; Column < 3; Column++)
            {
                for (int Row = 0; Row < 3; Row++)
                {
                    Grid[Column, Row] = ' ';
                }
            }
        }
        public void Display()
        {
            for (int Row = 2; Row >= 0; Row--)
            {
                Console.Write('|');
                for (int Column = 0; Column < 3; Column++)
                {
                    Console.Write(Grid[Column, Row]);
                    Console.Write('|');
                }
                Console.WriteLine(' ');
            }
        }
        public int Draw(Player player, int[] coords)
        {
            if(Grid[coords[0],coords[1]] != ' ')
            {
                return -1;
            }
            else
            {
                Grid[coords[0], coords[1]] = player.Symbol;
                return 1;
            }
        }
        public char HorizontalWinner()
        {
            //Check each row from top to bottom
            for (int Row = 0; Row < 3; Row++)
            {
                if(Grid[0, Row] == ' ') //If the row has one space, there can't be a winner
                {
                    continue; //Skip to the next iteration of the for loop
                }
                if (Grid[0, Row] == Grid[1, Row] && Grid[1, Row] == Grid[2, Row]) //If all items in the row are the same
                {
                    return Grid[0, Row]; //Return the symbol of the winner
                }
            }
            return ' ';
        }
        public char VerticalWinner()
        {
            //Check each column from left to right
            for (int Column = 0; Column < 3; Column++)
            {
                if (Grid[Column, 0] == ' ') //If the column has one space, there can't be a winner
                {
                    continue; //Skip to the next iteration of the for loop
                }
                if (Grid[Column, 0] == Grid[Column, 1] && Grid[Column, 1] == Grid[Column, 2]) //If all items in the row are the same
                {
                    return Grid[Column, 0]; //Return the symbol of the winner
                }
            }
            return ' ';
        }
        public char DiagonalWinner()
        {
            //Check both diagonal directions
            if (Grid[1, 1] == ' ') //If the center doesn't have a symbol, there can't be a winner
            {
                return ' '; //Skip to the next iteration of the for loop
            }
            if (Grid[0, 0] == Grid[1, 1] && Grid[1, 1] == Grid[2, 2])
            {
                return Grid[0, 0];
            }
            if (Grid[2, 0] == Grid[1, 1] && Grid[1, 1] == Grid[0, 2])
            {
                return Grid[2, 0];
            }
            return ' ';
        }
        public char Tie()
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (Grid[i, j] == ' ')
                    {
                        return ' ';
                    }
                }
            }
            return 'd';
        }

        public char Winner()
        {

            char Result;
            //Call each of the winner methods
            Result = HorizontalWinner();
            if (Result != ' ')
            {
                return Result;
            }
            Result = VerticalWinner();
            if (Result != ' ')
            {
                return Result;
            }
            Result = DiagonalWinner();
            if (Result != ' ')
            {
                return Result;
            }
            /*At this point, no winners have been determined.
             *So that means, if the board is full, and there are no winners
             *It must be a tie. So let's check if the board is full
            */
            Result = Tie();
            if (Result != ' ')
            {
                return Result;
            }
            return ' ';
        }
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello there, welcome to my tic tac toe game!");
            Console.WriteLine("Would you like to play? y/n");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.WriteLine();
                Console.WriteLine("You would like to play!");

                InitialiseVariables();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Well, see you later!");
                return;
            }
        }

        static void InitialiseVariables()
        {
            //Create first player
            Console.WriteLine("What is your name, player 1?:");
            string PlayerOneName = Console.ReadLine();
            Player PlayerOne = new Player(PlayerOneName, 'x');
            Console.WriteLine($"Hey there, {PlayerOne.Name}");

            //Create second player
            Console.WriteLine("What is your name, player 2?:");
            string PlayerTwoName = Console.ReadLine();
            Player PlayerTwo = new Player(PlayerTwoName, 'o');
            Console.WriteLine($"Hey there, {PlayerTwo.Name}");

            //Randomly make a player active
            var random = new Random();
            if (random.Next(0, 10) % 2 == 0)
            {
                PlayerOne.Active = true;
            }
            else
            {
                PlayerTwo.Active = true;
            }

            Board Board = new Board();
            Game(PlayerOne, PlayerTwo, Board);
        }

        static void Game(Player PlayerOne, Player PlayerTwo, Board Board)
        {
            char Winner = ' ';
            Board.Display();
            while (Winner == ' ')
            {
                //Swap active players after each round
                Winner = Round(PlayerOne, PlayerTwo, Board);
                Board.Display();
                if (PlayerOne.Active)
                {
                    PlayerOne.Active = false;
                    PlayerTwo.Active = true;
                }
                else
                {
                    PlayerOne.Active = true;
                    PlayerTwo.Active = false;
                }
            }
            DetermineResult(PlayerOne, PlayerTwo, Winner);
        }

        static Char Round(Player P1, Player P2, Board Board)
        {
            Player Active;
            //Determine active player
            if (P1.Active)
            {
                Active = P1;
            }
            else
            {
                Active = P2;
            }
            //Get position choice, and place the symbol
            int CoordResult;
            int[] Coords;
            do
            {
                Coords = Active.GetCoordChoice();
                CoordResult = Board.Draw(Active, Coords);
            } while(CoordResult == -1);
            //Check for a winner
            return Board.Winner();
        }

        static void DetermineResult(Player P1, Player P2, char Result)
        {
            if(Result == 'd')
            {
                Console.WriteLine("The game ended in a draw!");
            }else if(Result == P1.Symbol)
            {
                Console.WriteLine($"{P1.Name} is the winner!");
            }
            else
            {
                Console.WriteLine($"{P2.Name} is the winner!");
            }
            Console.WriteLine("Would you like to play again? (y/n)");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.WriteLine();
                Console.WriteLine("With the same players? (y/n)");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    Console.WriteLine();
                    Board Board = new Board();
                    Game(P1, P2, Board);
                }
                else
                {
                    Console.WriteLine();
                    InitialiseVariables();
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Well, see you later!");
                return;
            }
        }
    }
}
