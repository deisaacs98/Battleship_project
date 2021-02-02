using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Project
{
    
    public class Fleet : IEnumerable
    {
        Ship[] ships;

        public Fleet()
        {
            this.ships = new Ship[4];
        }

        public void AddShips()
        {
            Destroyer destroyer = new Destroyer();
            Submarine submarine = new Submarine();
            Battleship battleship = new Battleship();
            Aircraft_Carrier carrier = new Aircraft_Carrier();
            ships[0] = destroyer;
            ships[1] = submarine;
            ships[2] = battleship;
            ships[3] = carrier;
        }
        public void Prepare()
        {
            AddShips();
            foreach (Ship ship in ships)
            {
                for (int i = 0; i < ship.Size.Length; i++)
                {
                    ship.Size[i] = "O";
                }
            }
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < ships.Length;i++)
            {
                yield return ships[i];
            }
        }
    }

    
}
