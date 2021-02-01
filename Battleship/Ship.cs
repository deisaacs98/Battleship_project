using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Project
{
    public abstract class Ship:IMoveable
    {
        protected string[] size;
        public string Name;

        public string[] Size
        {
            get
            {
                return size;
            }
        }

        public Ship()
        {

        }

        public void Move(string[,] grid, Ship ship, int xValue, int yValue, bool vertical)
        {
            if (vertical)
            {
                for (int i = 0; i < ship.Size.Length; i++)
                {
                    if (grid[xValue, yValue + i] != ".")
                    {
                        break;
                    }
                    else
                    {
                        grid[xValue, yValue + i] = ship.Size[i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < ship.Size.Length; i++)
                {
                    if (player.grid[xValue+i, yValue] != ".")
                    {
                        break;
                    }
                    else
                    {
                        player.grid[xValue+i, yValue] = ship.Size[i];
                    }
                }
            }
            
        }

    }
}
