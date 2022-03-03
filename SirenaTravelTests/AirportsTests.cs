using Microsoft.VisualStudio.TestTools.UnitTesting;

using SirenaTravel.Services;

namespace SirenaTravelTests
{
    [TestClass]
    public class AirportsTests
    {
        RequestsService service = new RequestsService();

        [TestMethod]
        public void GetAirportData_1()
        {
            // Arrange
            string arrange = "KJA";

            // Act
            var act = service.GetAirportData("KJA").Result.iata;

            // Assert
            Assert.AreEqual(arrange, act);
        }

        [TestMethod]
        public void GetAirportData_2()
        {
            // Arrange

            // Act
            var airport = service.GetAirportData("123").Result;

            // Assert
            Assert.IsNull(airport, "airport is null");
        }

        [TestMethod]
        public void GetAirportData_3()
        {
            // Arrange

            // Act
            var airport = service.GetAirportData("KjA").Result;

            // Assert
            Assert.IsNull(airport, "airport is null");
        }

        [TestMethod]
        public void GetAirportData_4()
        {
            // Arrange

            // Act
            var act = service.GetAirportData("Kja").Result;

            // Assert
            Assert.IsNull(act);
        }

        [TestMethod]
        public void GetAirportData_5()
        {
            // Arrange

            // Act
            var act = service.GetAirportData("SVOS").Result;

            // Assert
            Assert.IsNull(act);
        }
    }
}