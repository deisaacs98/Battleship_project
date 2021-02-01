using System;
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
        
    }
}
