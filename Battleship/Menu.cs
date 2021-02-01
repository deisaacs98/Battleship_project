using System;
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
                Console.WriteLine("1 Player");
                Console.WriteLine("2 Player");
                int input;
                Int32.TryParse(Console.ReadLine(), out input);
                validatedInput = ValidateNumberOfPlayers(input);
            }
            while (!validatedInput.Item1);

            return validatedInput.Item2;

        }

        public static void DisplayGrid(Player player)
        {
            for(int i=0;i<player.grid.GetLength(0);i++)
            {
                Console.Write("\n");
                for(int j=0;j<player.grid.GetLength(1);j++)
                {
                    Console.Write(player.grid[i, j]);
                }
            }
        }

        public static void DisplayFleet(Player player)
        {
            foreach(Ship ship in player.fleet)
            {
                Console.WriteLine(ship.Name+"\t\t");
                for(int i=0;i<ship.Size.Length;i++)
                {
                    Console.Write(ship.Size[i]);
                }
            }
        }
    }
}
