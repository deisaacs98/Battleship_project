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
            player1.grid.Create();
            player2.grid.Create();
        }

        public void Run()
        {
            StartGame();
            player1.PlaceShips();
            player2.PlaceShips();
            bool playGame = true;
            int[] loc;
            while(playGame)
            {
                loc=player1.Attack();
                CheckIfHit(loc,player2, player1);
                loc=player2.Attack();
                CheckIfHit(loc,player1, player2);
            }

        }
        public void CheckIfHit(int[] loc,Player player1, Player player2)
        {
            int xValue = loc[0];
            int yValue = loc[1];
            if(player1.grid[xValue,yValue]=="O")
            {
                //HIT
                player2.grid[xValue, yValue] = "X";
                player1.grid[xValue, yValue] = "X";  
            }
            else
            {
                player2.grid[xValue, yValue] = "O";
            }
        }
        public void CheckScore()
        {

        }

    }
}
