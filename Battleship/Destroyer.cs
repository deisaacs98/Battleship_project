﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Project
{
    class Destroyer : Ship
    {
        public Destroyer()
        {
            Name = "Destroyer";
            size = new string[2];
            health = 2;
        }
    }
}
