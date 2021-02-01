using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Project
{
    public abstract class Ship
    {
        protected int size;
        public string Name;

        public double Size
        {
            get
            {
                return size;
            }
        }

        public Ship()
        {

        }
        
    }
}
