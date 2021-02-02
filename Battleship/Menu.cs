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

        public static Tuple<bool, int> ValidateNumberOfPlayers(int input)
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
                validatedInput = ValidateNumberOfPlayers(input);
            }
            while (!validatedInput.Item1);
            return validatedInput.Item2;
        }
        public static void PlaceShipPrompt(Ship ship)
        {
            Console.WriteLine("Place your "+ship);
            Console.WriteLine("\n Use the arrow keys to move your ship");
            Console.WriteLine("Use the spacebar to switch between vertical and horizontal.");
        }
        public static void DisplayGrid(Grid grid)
        {
            Console.WriteLine(" ABCDEFGHIJKLMNOPQRST");
            for(int i=0;i<grid.Height+1;i++)
            {
                Console.Write((i+1)+"\n");
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



        

        public static int[] AttackPrompt()
        {

            Tuple<bool, int> validatedLetter;
            do
            {
                Console.WriteLine("Enter the coordinates for your attack.");
                Console.WriteLine("Letter: ");
                string letter = Console.ReadLine();
                validatedLetter = ValidateLetter(letter);
            }
            while (!validatedLetter.Item1);
            Console.WriteLine("Number: ");
            string number = Console.ReadLine();
            
        }
        
        public static Tuple<bool, int> ValidateLetter(string letter)
        {
            List<string> letters = 
        }
    }
}
