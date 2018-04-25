using FurnitureManufacturer.Interfaces;
using FurnitureManufacturer.Models;
using Moq;
using NUnit.Framework;

namespace FurnitureManufacturerTests.Models.CompanyTests
{
    [TestFixture]
    public class Add_Should
    {
        private ICompany company;

        [OneTimeSetUp]
        public void SetUp()
        {
            const string name = "FurnitureTelerik";
            const string registrationNumber = "1234567890";

            company = new Company(name, registrationNumber);
        }

        [Test]
        public void ThrowArgumentNullException_When_PassedNull()
        {
            Assert.That(() => this.company.Add(null), Throws.ArgumentNullException);
        }

        [Test]
        public void AddNewFurniture_When_IFurnitureArgumentIsNotNull()
        {
            var furnitureStub = new Mock<IFurniture>();
            this.company.Add(furnitureStub.Object);

            Assert.That(company.Furnitures, Contains.Item(furnitureStub.Object));

        }
    }
}