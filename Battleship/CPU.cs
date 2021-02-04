using System;
using System.Collections;
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

        Tuple<bool, int[]> previousHit;

        public CPU()
        {

        }
        public override void PlaceShips()
        {
            //Unlike the "Human" method, the input can
            //be generated randomly. First, let's decide
            //whether the ship will be vertical or horizontal
            fleet.Prepare();
            foreach (Ship ship in fleet)
            {
                int xValue;
                int height;
                int yValue;
                int width;
                Random random = new Random();
                bool vertical = false;
                int angle = random.Next(0, 2);
                if (angle == 0)
                {
                    vertical = true;
                    height = grid.Height;
                    xValue = random.Next(0, height);
                    width = grid.Width - ship.Size.Length;
                    yValue = random.Next(0, width);
                    ship.Move(grid, xValue, yValue, vertical);
                }
                else
                {
                    height = grid.Height - ship.Size.Length;
                    xValue = random.Next(0, height);
                    width = grid.Width;
                    yValue = random.Next(0, width);
                    ship.Move(grid, xValue, yValue, vertical);
                }
            }
        }

        public override int[] Attack()
        {
            previousHit = CheckForPreviousHits();
            if (!previousHit.Item1)
            {
                Tuple<bool, int[]> validatedAttack;
                do
                {
                    Random random = new Random();
                    int height=grid.Height;
                    int width=grid.Width;
                    int xValue = random.Next(1, height+1);
                    int yValue = random.Next(1, width+1);
                    validatedAttack = Menu.ValidateAttack(xValue, yValue, guessGrid);
                }
                while (!validatedAttack.Item1);
                return validatedAttack.Item2;
            }
            else
            {
                Tuple<bool, int[]> validatedAttack;
                do
                {

                    int xValue = previousHit.Item2[0];
                    int yValue = previousHit.Item2[1];
                    validatedAttack = Menu.ValidateAttack(xValue, yValue, guessGrid);
                }
                while (!validatedAttack.Item1);
                return validatedAttack.Item2;
            }
        }
        

        public Tuple<bool,int[]> CheckForPreviousHits()
        {
            int[] loc = new int[2];
            for (int i = 0;i<guessGrid.Height;i++)
            {
                for(int j = 0; j<guessGrid.Width;j++)
                {
                    string point = guessGrid[i, j];
                    if(point=="X")
                    {
                        string pointToRight = guessGrid[i + 1, j];
                        string pointToLeft = guessGrid[i - 1, j];
                        string pointBelow = guessGrid[i, j-1];
                        string pointAbove = guessGrid[i, j+1];
                        if (pointToRight=="." && i < 19)
                        {
                            loc[0] = i + 1;
                            loc[1] = j;
                            return Tuple.Create(true, loc);
                        }                       
                        else if (pointToLeft == "." && i > 1)
                        {
                            loc[0] = i - 1;
                            loc[1] = j;
                            return Tuple.Create(true, loc);
                        }                        
                        else if (pointBelow == "." && j > 1)
                        {
                            loc[0] = i;
                            loc[1] = j-1;
                            return Tuple.Create(true, loc);
                        }                      
                        else if (pointAbove == "." && j < 19)
                        {
                            loc[0] = i;
                            loc[1] = j+1;
                            return Tuple.Create(true, loc);
                        }
                    }
                }
            }
            return Tuple.Create(false, loc);
        }

    }  
}
