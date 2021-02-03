using System;
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
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("BATTLESHIP");
            Console.WriteLine("\n\n\nPress Enter to Continue");
            Console.ReadLine();
        }

        public static void DisplayError(string error)
        {
            Console.WriteLine(error);

        }

        public static Tuple<bool, int> Validate1Or2(int input)
        {
            if(input == 1)
            {
                return Tuple.Create(true, 1);
            }
            else if(input == 2)
            {
                return Tuple.Create(true, 2);
            }
            else
            {
                DisplayError("Invalid input");
                return Tuple.Create(false, 0);
            }
        }

        public static int HowManyPlayers()
        {
            Tuple<bool, int> validatedInput;
            do
            {
                Console.Clear();
                Console.WriteLine("How many players?");
                Console.WriteLine("1 Player");
                Console.WriteLine("2 Player");
                int input;
                Int32.TryParse(Console.ReadLine(), out input);
                validatedInput = Validate1Or2(input);
            }
            while (!validatedInput.Item1);
            return validatedInput.Item2;
        }
        public static void PlaceShipPrompt(Ship ship,Grid grid)
        {
            Console.Clear();
            DisplayGrid(grid);
            Console.WriteLine("Place your "+ship);
            int angle = ChooseAngle();
            bool vertical = false;
            if(angle ==2)
            {
                vertical = true;
            }
            Tuple<bool, int[]> validatedPlacement;
            do
            {
                    
                Console.WriteLine("Enter the X coordinate:");
                int number1;
                Int32.TryParse(Console.ReadLine(), out number1);
                Console.WriteLine("Enter the Y coordinate:");
                int number2;
                Int32.TryParse(Console.ReadLine(), out number2);
                validatedPlacement = ValidatePlacement(number1, number2, grid, vertical, ship);
            }
            while (!validatedPlacement.Item1);
        }
            
        

        public static int ChooseAngle()
        {
            Tuple<bool, int> validatedInput;
            do
            {
                Console.WriteLine("\nEnter 1 to place the ship horizontally");
                Console.WriteLine("Enter 2 to place the ship vertically");
                int input;
                Int32.TryParse(Console.ReadLine(), out input);
                validatedInput = Validate1Or2(input);
            }
            while (!validatedInput.Item1);
            return validatedInput.Item2;

        }
        public static void DisplayGrid(Grid grid)
        {
            Console.WriteLine("  1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16 17 18 19 20");
            for(int i=0;i<grid.Height+1;i++)
            {
                string yValue = Convert.ToString(i+1);
                Console.WriteLine(yValue.PadRight(3));
                for(int j=0;j<grid.Width;j++)
                {
                    Console.Write(grid[i, j]);
                }
            }
        }
        //public static void DisplayFleet(Player player)
        //{
        //    foreach (Ship ship in player.fleet)
        //    {
        //        Console.WriteLine(ship.Name + "\t\t");
        //        for (int i = 0; i < ship.Size.Length; i++)
        //        {
        //            Console.Write(ship.Size[i]);
        //        }
        //    }
        //}



        

        public static int[] AttackPrompt(Grid grid, Grid guessGrid)
        {
            Menu.DisplayGrid(guessGrid);
            Menu.DisplayGrid(grid);
            Tuple<bool, int[]> validatedAttack;
            do
            {
                Console.WriteLine("Enter the X coordinate for your attack:");
                int number1; 
                Int32.TryParse(Console.ReadLine(),out number1);
                Console.WriteLine("Enter the Y coordinate for your attack:");
                int number2;
                Int32.TryParse(Console.ReadLine(), out number2);
                validatedAttack = ValidateAttack(number1, number2,grid,guessGrid);
            }
            while (!validatedAttack.Item1); 
        }

        public static Tuple<bool, int[]> ValidatePlacement(int xValue, int yValue, Grid grid, bool vertical, Ship ship)
        {
            int[] loc = new int[2];
            if (vertical)
            {
                for (int i = 0; i < ship.Size.Length; i++)
                {
                    if(grid[xValue+i, yValue] != ".")
                    {
                        return Tuple.Create(false, loc);
                    }
                }
                loc[0] = xValue;
                loc[1] = yValue;
                return Tuple.Create(true, loc);
            }
            else
            {
                for (int i = 0; i<ship.Size.Length;i++)
                {
                    if (grid[xValue, yValue+i] != ".")
                    {
                        return Tuple.Create(false, loc);
                    }
                }
                loc[0] = xValue;
                loc[1] = yValue;
                return Tuple.Create(true, loc);
            }
        }

        public static Tuple<bool, int[]> ValidateAttack(int xValue, int yValue, Grid grid, Grid guessGrid)
        {
            int[] loc = new int[2];
            if (grid[xValue, yValue] == "O")
            {

                loc[0] = xValue;
                loc[1] = yValue;
                return Tuple.Create(true, loc);
            }
            else
            {
                loc[0] = 0;
                loc[1] = 0;
                DisplayError("Invalid input");
                return Tuple.Create(false, loc);
            }
        }
    }


}
