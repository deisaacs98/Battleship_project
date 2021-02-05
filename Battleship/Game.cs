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
        public bool onePlayer=false;

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
                onePlayer = true;
                player2 = new CPU();
            }
            else
            {
                player2 = new Human();
            }
            player1.grid.Create();
            player1.guessGrid.Create();
            player2.grid.Create();
            player2.guessGrid.Create();
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
                CheckIfHit(loc,player2, player1,true);
                playGame = CheckScore(player2, player1, "Player 1");
                loc=player2.Attack();
                if (onePlayer)
                {
                    CheckIfHit(loc, player1, player2, false);
                    playGame = CheckScore(player1, player2, "Player 2");
                }
                else
                {
                    CheckIfHit(loc, player1, player2, true);
                    playGame = CheckScore(player1, player2, "Player 2");
                }
            }

        }
        public void CheckIfHit(int[] loc,Player player1, Player player2, bool isHuman)
        {
            int xValue = loc[0];
            int yValue = loc[1];
            if(player1.grid[xValue-1,yValue-1]=="O")
            {
                player2.guessGrid[xValue-1, yValue-1] = "X";
                player1.grid[xValue-1, yValue-1] = "X";
                if(isHuman)
                {
                    Menu.DisplayHit(player2);
                    Console.WriteLine("\n\n\t\t\t\tPress Enter to end your turn");
                    Console.ReadLine();
                }
                player2.hits++;   
            }
            else if(player1.grid[xValue-1,yValue-1]==".")
            {
                player2.guessGrid[xValue-1, yValue-1] = "O";
                if (isHuman)
                {
                    Menu.DisplayMiss(player2);
                    Console.WriteLine("\n\n\t\t\t\tPress Enter to end your turn");
                    Console.ReadLine();
                }
            }
            else
            {
                if (isHuman)
                {
                    Menu.DisplayHitSameSpot(player2);
                    Console.WriteLine("\n\n\t\t\t\tPress Enter to end your turn");
                    Console.ReadLine();
                }        
            }

        }
        public bool CheckScore(Player player1, Player player2, string winnerName)
        {
            bool playAgain = false;
            int totalSize=0;
            foreach(Ship ship in player1.fleet)
            {
                totalSize += ship.Size.Length;
            }
            if(player1.hits>=totalSize)
            {
                playAgain = Menu.DisplayWinScreen(player2, winnerName);
                
                return playAgain;
            }
            else
            {
                return true;
            }
        }

    }
}
