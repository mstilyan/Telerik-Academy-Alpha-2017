using FurnitureManufacturer.Interfaces;
using FurnitureManufacturer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace FurnitureManufacturer.Tests.Models.CompanyTests
{
    [TestClass]
    public class Find_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenPassedNullParam()
        {
            var validName = "Pesho";
            var validRegistrationNumber = "1234567890";
            var sut = new Company(validName, validRegistrationNumber);

            Assert.ThrowsException<ArgumentNullException>(() => sut.Find(null));
        }

        [TestMethod]
        public void AddFurnitureToLocalCollection_WhenPassedValidParam()
        {
            var validName = "Pesho";
            var validRegistrationNumber = "1234567890";

            var validModel = "Patka";
            var furnitureStub = new Mock<IFurniture>();
            furnitureStub.SetupGet(x => x.Model).Returns(validModel);

            var sut = new Company(validName, validRegistrationNumber);
            sut.Furnitures.Clear();
            sut.Furnitures.Add(furnitureStub.Object);

            var result = sut.Find(validModel);

            Assert.AreSame(furnitureStub.Object, result);
        }
    }
}
