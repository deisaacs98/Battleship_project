﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Project
{
    static class Menu
    {
        public static void Title()
        {
            Console.SetWindowSize(120, 43);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\t\t   ______  __  _____  _____  _     ____    _____  _  _  ____ ");
            Console.Write("\t\t  |  /  / /  ||_   _||_   _|| |   |  _|   / ___/ | || || -  |");
            Console.Write("\n\t\t  |   _/_/ / |  | |    | |  | |   |   |  / /_| |_| || ||  _/ ");
            Console.Write("\n\t\t  |     /    |  | |    | |  | |   |  _| /__  /  _  || || | ");
            Console.Write("\n\t\t  |  / /  /| |  | |    | |  | |__ |   |___/ /| | | || || |");
            Console.Write("\n\t\t  |___/__/ |_|  |_|    |_|  |____||___|____/ |_| |_||_||_|");
            Console.WriteLine("\n\n\n\n\n\t\t\t\tPress Enter to Continue");
            Console.ReadLine();
        }

        public static void DisplayError(string error)
        {
            Console.WriteLine(error);
            Console.ReadLine();
            Console.Clear();
        }



        public static int HowManyPlayers()
        {
            Tuple<bool, int> validatedInput;
            do
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\n\n\n\n\t\t\t\tHow many players?");
                Console.WriteLine("\n\t\t\t\t1 Player");
                Console.WriteLine("\t\t\t\t2 Player");
                int input;
                Int32.TryParse(Console.ReadLine(), out input);
                validatedInput = Validate1Or2(input);
            }
            while (!validatedInput.Item1);
            return validatedInput.Item2;
        }

        public static Tuple<bool, int> Validate1Or2(int input)
        {
            if (input == 1)
            {
                return Tuple.Create(true, 1);
            }
            else if (input == 2)
            {
                return Tuple.Create(true, 2);
            }
            else
            {
                DisplayError("Invalid input");
                return Tuple.Create(false, 0);
            }
        }


        public static void DisplayGrid(Grid grid)
        {
            Console.WriteLine("\n\n\t\t\t   1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16 17 18 19 20");
            for(int i=0;i<grid.Height;i++)
            {
                string yValue = Convert.ToString(i+1);
                Console.Write("\t\t\t"+yValue.PadRight(3));
                for(int j=0;j<grid.Width;j++)
                {
                    Console.Write(grid[i, j]+"  ");
                }
                Console.Write("\n");
            }
        }
        public static int ChooseAngle()
        {
            Tuple<bool, int> validatedInput;
            do
            {
                Console.WriteLine("\n\n\t\t\t\tEnter 1 to place the ship horizontally");
                Console.WriteLine("\n\t\t\t\tEnter 2 to place the ship vertically");
                int input;
                Int32.TryParse(Console.ReadLine(), out input);
                validatedInput = Validate1Or2(input);
            }
            while (!validatedInput.Item1);
            return validatedInput.Item2;

        }
        public static void PlaceShipPrompt(Ship ship, Grid grid)
        {
            Console.Clear();
            DisplayGrid(grid);
            Console.WriteLine("\n\n\t\t\t\tPlace your " + ship.Name);
            int angle = ChooseAngle();
            bool vertical = false;
            if (angle == 2)
            {
                vertical = true;
            }
            Tuple<bool, int[]> validatedPlacement;
            do
            {
                Console.Clear();
                DisplayGrid(grid);
                Console.WriteLine("\n\t\t\t\tEnter the X coordinate:");
                int number1;
                Int32.TryParse(Console.ReadLine(), out number1);
                Console.Clear();
                DisplayGrid(grid);
                Console.WriteLine("\n\t\t\t\tEnter the Y coordinate:");
                int number2;
                Int32.TryParse(Console.ReadLine(), out number2);
                number1--;
                number2--;
                validatedPlacement = ValidatePlacement(number2 , number1 , grid, vertical, ship);
            }
            while (!validatedPlacement.Item1);
            ship.Move(grid, validatedPlacement.Item2[0], validatedPlacement.Item2[1], vertical);
        }


        public static Tuple<bool, int[]> ValidatePlacement(int xValue, int yValue, Grid grid, bool vertical, Ship ship)
        {
            int[] loc = new int[2];
            while (xValue >= 0 && xValue < grid.Height && yValue >= 0 && yValue < grid.Width)
            {
                if (vertical)
                {
                    for (int i = 0; i < ship.Size.Length; i++)
                    {
                        int tempX = xValue + i;
                        if(tempX>=grid.Height)
                        {
                            DisplayError("\t\t\t\tInvalid input");
                            return Tuple.Create(false, loc);
                        }
                        else if (grid[tempX, yValue] != ".")
                        {
                            DisplayError("\t\t\t\tInvalid input");
                            return Tuple.Create(false, loc);
                        }

                    }
                    loc[0] = xValue;
                    loc[1] = yValue;
                    return Tuple.Create(true, loc);
                }
                else
                {
                    for (int i = 0; i < ship.Size.Length; i++)
                    {
                        int tempY = yValue + i;
                        if(tempY>=grid.Width)
                        {
                            DisplayError("\t\t\t\tInvalid input");
                            return Tuple.Create(false, loc);
                        }
                        else if (grid[xValue, tempY] != ".")
                        {
                            DisplayError("\t\t\t\tInvalid input");
                            return Tuple.Create(false, loc);
                        }

                    }
                    loc[0] = xValue;
                    loc[1] = yValue;
                    return Tuple.Create(true, loc);
                }
            }
            DisplayError("\t\t\t\tInvalid input");
            return Tuple.Create(false, loc);
        }

        public static int[] AttackPrompt(Grid grid, Grid guessGrid)
        {
            Tuple<bool, int[]> validatedAttack;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\tOpponent's grid\n");
                Menu.DisplayGrid(guessGrid);
                Console.WriteLine("\n\t\t\t\tYour grid\n");
                Menu.DisplayGrid(grid);
                Console.WriteLine("\n\n\t\t\t\tEnter the X coordinate for your attack:");
                int number1;
                Int32.TryParse(Console.ReadLine(),out number1);
                Console.Clear();
                Console.WriteLine("\t\t\t\tOpponent's grid\n");
                Menu.DisplayGrid(guessGrid);
                Console.WriteLine("\n\t\t\t\tYour grid\n");
                Menu.DisplayGrid(grid);
                Console.WriteLine("\n\n\t\t\t\tEnter the Y coordinate for your attack:");
                int number2;
                Int32.TryParse(Console.ReadLine(), out number2);

                validatedAttack = ValidateAttack(number2, number1,guessGrid);
            }
            while (!validatedAttack.Item1);
            return validatedAttack.Item2;

        }

        public static Tuple<bool, int[]> ValidateAttack(int xValue, int yValue, Grid grid)
        {
            int[] loc = new int[2];
            if (xValue<=grid.Height&&yValue<=grid.Width&&xValue>0&&yValue>0)
            {
                loc[0] = xValue;
                loc[1] = yValue;
                return Tuple.Create(true, loc);
            }
            else
            {
                loc[0] = 0;
                loc[1] = 0;
                DisplayError("\t\t\t\tInvalid input");
                return Tuple.Create(false, loc);
            }
        }
        
        public static void DisplayHit(Player player)
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\tYou hit a ship!");
            Console.WriteLine("\t\t\t\tOpponent's grid\n");
            Menu.DisplayGrid(player.guessGrid);
            Console.WriteLine("\n\t\t\t\tYour grid\n");
            Menu.DisplayGrid(player.grid);

        }
        public static void DisplayMiss(Player player)
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\tYou missed!");
            Console.WriteLine("\t\t\t\tOpponent's grid\n");
            Menu.DisplayGrid(player.guessGrid);
            Console.WriteLine("\n\t\t\t\tYour grid\n");
            Menu.DisplayGrid(player.grid);

        }
        public static void DisplayHitSameSpot(Player player)
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\tYou alrady hit this spot!");
            Console.WriteLine("\t\t\t\tOpponent's grid\n");
            Menu.DisplayGrid(player.guessGrid);
            Console.WriteLine("\n\t\t\t\tYour grid\n");
            Menu.DisplayGrid(player.grid);

        }
        public static bool DisplayWinScreen(Player player, string winnerName)
        {
            bool playAgain = false;
            Console.Clear();
            Console.WriteLine("\t\t\t\t"+winnerName + " has won the game!");
            Console.WriteLine("\n\n\t\t\t\tWould you like to play again?");
            Console.WriteLine("\n\t\t\t\t(Press Y for Yes or N for No)");
            string response = Console.ReadLine();
            if(response=="Y"||response=="y")
            {
                playAgain = true;
            }
            return playAgain;
        }
    }


}
