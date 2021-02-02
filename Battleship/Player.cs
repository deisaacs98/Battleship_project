using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Project
{
    public abstract class Player
    {
        public Ship[] fleet;
        public string[,] grid = new string[20, 20];

        //The ships will start with a set number of O's
        //depending on the type of ship. Once the corresponding
        //spot is hit, the O will be changed into an X.
        //
        //This is where we give them the starting "O" value.
        public void AddShips()
        {
            fleet = new Ship[4];
            Destroyer destroyer = new Destroyer();
            Submarine submarine = new Submarine();
            Battleship battleship = new Battleship();
            Aircraft_Carrier carrier = new Aircraft_Carrier();
            fleet[0]=destroyer;
            fleet[1] = submarine;
            fleet[2] = battleship;
            fleet[3] = carrier;
        }
        public void PrepareFleet()
        {
            foreach(Ship ship in fleet)
            {
                for(int i = 0;i<ship.Size.Length;i++)
                {
                    ship.Size[i] = "O";
                }
            }
        }

        public virtual void PlaceShips()
        {

        }

        public virtual void Attack()
        {

        }
    }
}
