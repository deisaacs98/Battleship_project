using System;
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

        public override void PlaceShips()
        {
            //Unlike the "Human" method, the input can
            //be generated randomly. First, let's decide
            //whether the ship will be vertical or horizontal
            foreach (Ship ship in fleet)
            {
                Random random = new Random();
                bool vertical = false;
                int angle = random.Next(0, 2);
                if (angle == 0)
                {
                    vertical = true;
                    int xValue = random.Next(0, grid.GetLength(1));
                    int yValue = random.Next(0, grid.GetLength(0) - ship.Size.Length);
                    ship.Move(grid, ship, xValue, yValue, vertical);

                }
                while (vertical)
                {

                }
            }

        }
    }

    
}
