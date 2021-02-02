using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Project
{
    interface IMoveable
    {
        void Move(Grid grid, Ship ship, int xValue, int yValue, bool vertical);
    }
}
