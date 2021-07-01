using System;

namespace csharp_tic_tac_toe
{
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
    }
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.Display();
            Console.WriteLine("Hello World!");
        }
    }
}
