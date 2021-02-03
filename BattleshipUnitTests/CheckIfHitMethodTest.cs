using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Battleship_Project;

namespace BattleshipUnitTests
{
    [TestClass]
    public class CheckIfHitMethodTest
    {
        [TestMethod]
        public void CheckIfHit_HumanVsHuman_true()
        {
            //Arrange
            Game game = new Game();
            Player player1 = new Human();
            Player player2 = new Human();
            int[] loc = new int[2];
            loc[0] = 1;
            loc[1] = 1;
            player1.grid[0, 0] = "O";
            int expected = 1;
            int actual;
            //Act
            player2.hits = 0;
            game.CheckIfHit(loc,player1,player2);
            actual = player2.hits;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckIfHit_HumanVsCPU_true()
        {
            //Arrange
            Game game = new Game();
            Player player1 = new Human();
            Player player2 = new CPU();
            int[] loc = new int[2];
            loc[0] = 5;
            loc[1] = 6;
            player2.grid[4, 5] = "O";
            int expected = 10;
            int actual;
            //Act
            player1.hits = 9;
            game.CheckIfHit(loc, player2, player1);
            actual = player1.hits;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckIfHit_CPUVsCPU_false()
        {
            //Arrange
            Game game = new Game();
            Player player1 = new CPU();
            Player player2 = new CPU();
            int[] loc = new int[2];
            loc[0] = 2;
            loc[1] = 2;
            int expected = 9;
            int actual;
            //Act
            player1.hits = 9;
            game.CheckIfHit(loc, player2, player1);
            actual = player1.hits;
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
