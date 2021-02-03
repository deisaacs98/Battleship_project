using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Battleship_Project;

namespace BattleshipUnitTests
{
    [TestClass]
    public class MoveShipMethodTest
    {
        [TestMethod]
        public void MoveShip_Destroyer_Vertical()
        {
            //Arrange
            Player player = new Human();
            
            string[] expected = new string[2];
            string[] actual=new string[2];

            //Act
            player.fleet.Prepare();
            Ship ship = player.fleet[0];
            ship.Move(player.grid, 2, 2, true);
            string value1 = player.grid[2, 2];
            string value2 = player.grid[2, 3];
            actual[0] = value1;
            actual[1] = value2;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MoveShip_Submarine_Horizontal()
        {
            //Arrange


            //Act

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MoveShip_Battleship_Vertical()
        {
            //Arrange


            //Act

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MoveShip_AircraftCarrier_Horizontal()
        {
            //Arrange


            //Act


            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
