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
        public Fleet fleet=new Fleet();
        public Grid grid = new Grid();
        public Grid guessGrid = new Grid();


        //The ships will start with a set number of O's
        //depending on the type of ship. Once the corresponding
        //spot is hit, the O will be changed into an X.
        //
        //This is where we give them the starting "O" value.
        public Player()
        {
            
        }
        

        public virtual void PlaceShips()
        {

        }

        public virtual int[] Attack()
        {
            return null;
        }
    }
}
