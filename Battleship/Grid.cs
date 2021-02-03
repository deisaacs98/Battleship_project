using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Project
{
    public class Grid
    {
        string[,] grid;
        private int width = 20;
        private int height = 20;
        public Grid()
        {
            grid = new string[height, width];
        }
        
        
        public void Create()
        {
            for (int i = 0;i<Height;i++)
            {
                for(int j=0;j<Width;j++)
                {
                    grid[i, j] = ".";
                }
            }
        }
        public string this[int xValue, int yValue]
        {
            get
            {
                return grid[xValue, yValue];
            }
            set
            {
                grid[xValue, yValue] = value;
            }
        }

        public int Width
        {
            get
            { return width; }
            set
            { width = value; }
        }
        public int Height
        {
            get
            { return height; }
            set
            { height = value; }
        }

    }
}
