using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Project
{
    public class Game
    {
        public Player player1;
        public Player player2;
        

        public Game()
        {

        }

        public void StartGame()
        {
            Menu.Title();
            int players=Menu.HowManyPlayers();
            player1 = new Human();
            if (players == 1)
            {
                player2 = new CPU();
            }
            else
            {
                player2 = new Human();
            }
        }

        public void Run()
        {
            StartGame();
            player1.PlaceShips();
            player2.PlaceShips();
            bool playGame = true;
            while(playGame)
            {
                player1.Attack();

                player2.Attack();
            }

        }

        public bool CheckScore

    }
}
