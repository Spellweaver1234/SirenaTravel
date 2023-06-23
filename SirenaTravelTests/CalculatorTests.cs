using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using SirenaTravel.Models;

namespace SirenaTravelTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void VKO_KJA()
        {
            var lonA = 37.416574;
            var latA = 55.966324;
            var lonB = 92.482859;
            var latB = 56.18113;

            // Arrange
            var expected = 2066.1;

            // Act
            var km = Calculator.DistanceBetweenAirports(lonA, latA, lonB, latB);
            var miles = Calculator.KmToMiles(km);
            var actual = Math.Round(miles, 1);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void KJA_VKO()
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

        [TestMethod]
        public void SYD_VKO()
        {
            var lonA = 151.324087;
            var latA = -33.586929;
            var lonB = 37.292098;
            var latB = 55.60315;

            // Arrange
            var arrange = 9009.8;

            // Act
            var km = Calculator.DistanceBetweenAirports(lonA, latA, lonB, latB);
            var miles = Calculator.KmToMiles(km);
            var act = Math.Round(miles, 1);

            // Assert
            Assert.AreEqual(arrange, act);
        }

        [TestMethod]
        public void VKO_SYD()
        {
            var lonA = 37.292098;
            var latA = 55.60315;
            var lonB = 151.324087;
            var latB = -33.586929;

            // Arrange
            var arrange = 9009.8;

            // Act
            var km = Calculator.DistanceBetweenAirports(lonA, latA, lonB, latB);
            var miles = Calculator.KmToMiles(km);
            var act = Math.Round(miles, 1);

            // Assert
            Assert.AreEqual(arrange, act);
        }
    }
}

/*
Australia  SYD
Latitude	-33.947346
Longitude	151.179428

Внуково VKO 
Longitude 37.416574;
Latitude 55.966324;

SYD_VKO
14493.7 km
9006.0 miles

Красноярск KJA 
Longitude 92.482859;
Latitude 56.18113;
 */