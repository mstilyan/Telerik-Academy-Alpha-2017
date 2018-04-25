using FurnitureManufacturer.Interfaces;
using FurnitureManufacturer.Models;
using Moq;
using NUnit.Framework;

namespace FurnitureManufacturerTests.Models.CompanyTests
{
    [TestFixture]
    public class Find_Should
    {
        private ICompany company;

        [SetUp]
        public void SetUp()
        {
            const string name = "FurnitureTelerik";
            const string registrationNumber = "1234567890";

            company = new Company(name, registrationNumber);
        }

        [Test]
        public void ThrowArgumentNullException_When_PassedNull()
        {
            Assert.That(() => company.Find(null), Throws.ArgumentNullException);
        }

        [Test]
        public void ReturnNull_When_PassedModelNotFound()
        {
            const string model = "Dani";
            var actualFurniture = this.company.Find(model);

            Assert.That(actualFurniture, Is.Null);
        }

        [TestCase("Dani")]
        [TestCase("DANI")]
        [TestCase("dani")]
        public void ReturnIFurniture_When_FurnitureWithSameModelFound(string modelToSearch)
        {
            const string model = "Dani";

            var furnitureMock = new Mock<IFurniture>();
            furnitureMock.Setup(x => x.Model).Returns(model);
            this.company.Add(furnitureMock.Object);

            var actualFurniture = this.company.Find(modelToSearch);

            Assert.That(actualFurniture, Is.EqualTo(furnitureMock.Object));
        }
    }
}