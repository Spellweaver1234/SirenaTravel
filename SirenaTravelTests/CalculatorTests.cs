using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using SirenaTravel.Models;

namespace SirenaTravelTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void DistanceBetweenAirports_1()
        {
            var lonA = 92.482859;
            var latA = 56.18113;
            var lonB = 37.416574;
            var latB = 55.966324;

            // Arrange
            var arrange = 3325.1;

            // Act
            var distance = Calculator.DistanceBetweenAirports(lonA, latA, lonB, latB);
            var act = Math.Round(distance, 1);

            // Assert
            Assert.AreEqual(arrange, act);
        }

        [TestMethod]
        public void DistanceBetweenAirports_2()
        {
            var lonA = 92.482859;
            var latA = 56.18113;
            var lonB = 37.416574;
            var latB = 55.966324;

            // Arrange
            var arrange = 2066.1;

            // Act
            var km = Calculator.DistanceBetweenAirports(lonA, latA, lonB, latB);
            var miles = Calculator.KmToMiles(km);
            var act = Math.Round(miles, 1);

            // Assert
            Assert.AreEqual(arrange, act);
        }
    }
}