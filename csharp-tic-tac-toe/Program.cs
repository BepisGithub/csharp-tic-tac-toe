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
                    Grid[i,j] = ' ';
                }
            }
        }
        public void Draw()
        {
            Console.WriteLine("TEst");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Console.WriteLine("Hello World!");
        }
    }
}
