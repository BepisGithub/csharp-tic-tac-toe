﻿using System;

namespace csharp_tic_tac_toe
{

    class Player
    {
        public string Name { get; set; }
        public char Symbol { get; set; }

        public bool Active = true;

        public Player(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        public int[] GetCoordChoice()
        {
            Console.WriteLine("What is the x coordinate you would like to choose? (The bottom left pos is 0, 0 for x and y)");
            int x = Convert.ToInt32(Console.ReadLine());
            while(x < 0 || x > 2)
            {
                Console.WriteLine("Oops, that doesn\'t seem to be valid! Try again");
                x = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("What is the y coordinate you would like to choose? (The bottom left pos is 0, 0 for x and y)");
            int y = Convert.ToInt32(Console.ReadLine());
            while (y < 0 || y > 2)
            {
                Console.WriteLine("Oops, that doesn\'t seem to be valid! Try again");
                y = Convert.ToInt32(Console.ReadLine());
            }

            int[] Coords = new int[] { x, y };
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
                return Grid[0, 0];
            }
            return ' ';
        }
        public char Winner()
        {
            //Call each of the winner methods
            char HWinner = HorizontalWinner();
            if (HWinner != ' ')
            {
                return HWinner;
            }
            char VWinner = VerticalWinner();
            if (VWinner != ' ')
            {
                return VWinner;
            }
            char DWinner = DiagonalWinner();
            if (DWinner != ' ')
            {
                return DWinner;
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

                Game();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Well, see you later!");
                return;
            }
        }

        static void Game()
        {
            Console.WriteLine("What is your name, player 1?:");
            string PlayerOneName = Console.ReadLine();
            Player PlayerOne = new Player(PlayerOneName, 'x');
            Console.WriteLine($"Hey there, {PlayerOne.Name}");

            Console.WriteLine("What is your name, player 2?:");
            string PlayerTwoName = Console.ReadLine();
            Player PlayerTwo = new Player(PlayerTwoName, 'o');
            Console.WriteLine($"Hey there, {PlayerTwo.Name}");

            Board Board = new Board();
            Player Winner = Round();
            while(Winner == null)
            {
                Winner = Round();
            }
        }

        static Player Round()
        {
            return null;
        }
    }
}
