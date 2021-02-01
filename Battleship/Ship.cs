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
        
    }
}
