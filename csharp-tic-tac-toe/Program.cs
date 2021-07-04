using System;

namespace csharp_tic_tac_toe
{

    class Player
    {
        public string Name;
        public char Symbol;
        
        public Player(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }
    }
    class Board
    {
        private char[,] Grid = new char[3, 3];

        public Board()
        {
            for(int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Grid[i,j] = 'd';
                }
            }
        }
        public void Display()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Write('|');
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(Grid[i, j]);
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
            return ' ';
        }
        public char VerticalWinner()
        {
            return ' ';
        }
        public char DiagonalWinner()
        {
            return ' ';
        }
        public char Winner()
        {
            //Call each of the winner methods
            char HWinner = HorizontalWinner();
            char VWinner = VerticalWinner();
            char DWinner = DiagonalWinner();
            //If a winner is found, return the symbol
            //TODO: Maybe have the two users passed in as parameters
            //then return the user with the winning symbol

            return ' ';
        }
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello there, welcome to my tic tac toe game!");
            Console.WriteLine("Would you like to play? y/n");
            if(Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.WriteLine("You would like to play!");
            }
        }
    }
}
