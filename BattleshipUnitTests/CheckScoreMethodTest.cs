using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Battleship_Project;

namespace BattleshipUnitTests
{
    [TestClass]
    public class CheckScoreMethodTest
    {
        [TestMethod]
        public void CheckScore_CPU_true()
        {
            //Arrange
            Game game = new Game();
            Player player = new CPU();
            bool expected = true;
            bool actual;
            //Act
            player.hits = 14;
            actual = game.CheckScore(player);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CheckScore_Human_true()
        {
            //Arrange
            Game game = new Game();
            Player player = new Human();
            bool expected = true;
            bool actual;
            //Act
            player.hits = 14;
            actual = game.CheckScore(player);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CheckScore_CPU_false()
        {
            //Arrange
            Game game = new Game();
            Player player = new CPU();
            bool expected = false;
            bool actual;
            //Act
            player.hits = 1;
            actual = game.CheckScore(player);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CheckScore_Human_false()
        {
            //Arrange
            Game game = new Game();
            Player player = new Human();
            bool expected = true;
            bool actual;
            //Act
            player.hits = 4;
            actual = game.CheckScore(player);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
