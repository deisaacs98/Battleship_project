using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Project
{
    class Aircraft_Carrier : Ship
    {
        public Aircraft_Carrier()
        {
            Name = "Aircraft Carrier";
            size = new string[5];
            health = 5;
        }
    }
}
