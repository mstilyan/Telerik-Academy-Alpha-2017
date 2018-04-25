using FurnitureManufacturer.Interfaces;
using FurnitureManufacturer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FurnitureManufacturer.Tests.Models.CompanyTests
{
    [TestClass]
    public class Catalog_Should
    {
        [TestMethod]
        public void ReturnValidMessage_WhenCompanyHasNoFurniture()
        {
            var validName = "Pesho";
            var validRegistrationNumber = "1234567890";
            var sut = new Company(validName, validRegistrationNumber);

            var result = sut.Catalog();

            Assert.AreEqual($"{validName} - {validRegistrationNumber} - no furniture", result);
        }

        [TestMethod]
        public void ReturnValidMessage_WhenCompanyHasOneFurniture()
        {
            var validName = "Pesho";
            var validRegistrationNumber = "1234567890";

            var validModel = "Patka";
            var furnitureStub = new Mock<IFurniture>();
            furnitureStub.SetupGet(x => x.Model).Returns(validModel);

            var sut = new Company(validName, validRegistrationNumber);
            sut.Furnitures.Clear();
            sut.Furnitures.Add(furnitureStub.Object);

            var result = sut.Catalog();

            var expectedLine1 = $"{validName} - {validRegistrationNumber} - 1 furniture";

            Assert.IsTrue(result.Contains(expectedLine1)); // Why are we checking only line 1?
        }

        // What else can be tested?
    }
}
