using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Project
{
    public class CPU : Player
    {
        //Placing ships is likely going to be the hardest
        //part, so let's focus on the automated process
        //before moving on to validating user input.
        public CPU()
        {

        }
        public override void PlaceShips()
        {
            //Unlike the "Human" method, the input can
            //be generated randomly. First, let's decide
            //whether the ship will be vertical or horizontal
            fleet.Prepare();
            foreach (Ship ship in fleet)
            {
                int xValue;
                int yValue;
                Random random = new Random();
                bool vertical = false;
                int angle = random.Next(0, 2);
                if (angle == 0)
                {
                    vertical = true;
                    xValue = random.Next(0, grid.Height);
                    yValue = random.Next(0, grid.Width - ship.Size.Length);
                    ship.Move(grid, ship, xValue, yValue, vertical);
                }
                else
                {
                    xValue = random.Next(0, grid.Height-ship.Size.Length);
                    yValue = random.Next(0, grid.Width);
                    ship.Move(grid, ship, xValue, yValue, vertical);
                }
            }
        }

    }  
}
