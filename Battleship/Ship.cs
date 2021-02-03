using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Project
{
    public abstract class Ship : IMoveable
    {
        protected string[] size;
        public string Name;
        public int health;

        public string[] Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }

        public Ship()
        {

        }

        public void Move(Grid grid, int xValue, int yValue, bool vertical)
        {

            if (!vertical)
            {
                for (int i = 0; i < Size.Length; i++)
                {
                    grid[xValue, yValue + i] = Size[i];
                }
            }
            else
            {
                for (int i = 0; i < Size.Length; i++)
                {
                    grid[xValue+i, yValue] = Size[i];
                }
            }
            
        }

    }
}
