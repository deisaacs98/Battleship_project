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
                Menu.PlaceShipPrompt(ship, grid);
            }
        }
        public override int[] Attack()
        {
            //Menu.DisplayFleet(this);

            int[] loc;
            loc=Menu.AttackPrompt(grid, guessGrid);
            return loc;
        }

    }
}
