using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Battleship_Project;

namespace BattleshipUnitTests
{
    [TestClass]
    public class CheckScoreMethodTest
    {
        [TestMethod]
        public void CheckScore_CPUvsCPU_true()
        {
            //Arrange
            Game game = new Game();
            Player player1 = new CPU();
            Player player2 = new CPU();
            bool expected = true;
            bool actual;
            //Act
            player1.hits = 14;
            actual = game.CheckScore(player1, player2, "Player 1");
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CheckScore_HumanVsHuman_true()
        {
            //Arrange
            Game game = new Game();
            Player player1 = new Human();
            Player player2 = new Human();
            bool expected = true;
            bool actual;
            //Act
            player1.hits = 14;
            actual = game.CheckScore(player1, player2, "Player 1");
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CheckScore_CPUvsHuman_false()
        {
            //Arrange
            Game game = new Game();
            Player player1 = new CPU();
            Player player2 = new Human();
            bool expected = false;
            bool actual;
            //Act
            player1.hits = 1;
            actual = game.CheckScore(player1,player2,"CPU");
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CheckScore_HumanVsHuman_false()
        {
            //Arrange
            Game game = new Game();
            Player player1 = new Human();
            Player player2 = new Human();
            bool expected = true;
            bool actual;
            //Act
            player1.hits = 4;
            actual = game.CheckScore(player1,player2,"Player 1");
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
