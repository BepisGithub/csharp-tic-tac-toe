﻿using System;

namespace csharp_tic_tac_toe
{
    class Board
    {
        private char[,] Grid = new char[3, 3];
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
