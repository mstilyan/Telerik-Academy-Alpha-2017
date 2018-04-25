using FurnitureManufacturer.Interfaces;
using FurnitureManufacturer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace FurnitureManufacturer.Tests.Models.CompanyTests
{
    [TestClass]
    public class Add_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenPassedNullParam()
        {
            var validName = "Pesho";
            var validRegistrationNumber = "1234567890";
            var sut = new Company(validName, validRegistrationNumber);

            Assert.ThrowsException<ArgumentNullException>(() => sut.Add(null));
        }

        [TestMethod]
        public void AddFurnitureToLocalCollection_WhenPassedValidParam()
        {
            var validName = "Pesho";
            var validRegistrationNumber = "1234567890";
            var furnitureStub = new Mock<IFurniture>();
            var sut = new Company(validName, validRegistrationNumber);

            sut.Add(furnitureStub.Object);

            Assert.IsTrue(sut.Furnitures.Count == 1 && sut.Furnitures.Contains(furnitureStub.Object));
        }
    }
}
