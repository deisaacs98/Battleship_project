using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Project
{
    public class Human : Player
    {
        public Grid guessGrid = new Grid();
        public Human()
        {

        }

        public override void PlaceShips()
        {
            fleet.Prepare();
            foreach (Ship ship in fleet)
            {
                int xValue=0;
                int yValue=0;
                Menu.PlaceShipPrompt(ship);
                Menu.DisplayGrid(grid);
                bool vertical = false;
                if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                {
                    vertical = !vertical;
                }

                if (vertical)
                {


                    ship.Move(grid, ship, xValue, yValue, vertical);
                }
                else
                {

                    ship.Move(grid, ship, xValue, yValue, vertical);
                }
            }
        }
        public override int[] Attack()
        {
            //Menu.DisplayFleet(this);
            Menu.DisplayGrid(guessGrid);
            Menu.DisplayGrid(grid);
            int[] loc;
            loc=Menu.AttackPrompt();
            return loc;
        }

    }
}
