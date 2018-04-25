using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Traveller.Commands.Creating;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Models.Abstractions;

namespace TravellerTests.Commands.Create.CreateTicketCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        private Mock<ITravellerFactory> travelerFactoryMock;
        private Mock<IDataStore> dataStoreMock;
        private CommandConstants commandConstants;
        private CreateTicketCommand createTicketCommand;

        [SetUp]
        public void SetUp()
        {
            this.travelerFactoryMock = new Mock<ITravellerFactory>();
            this.dataStoreMock = new Mock<IDataStore>();
            commandConstants = new CommandConstants();
        }

        [Test]
        public void ThrowsArgumentException_When_ArgumentIsNull()
        {
            this.createTicketCommand = new CreateTicketCommand(this.travelerFactoryMock.Object, 
                this.dataStoreMock.Object, this.commandConstants);

            Assert.That(() => createTicketCommand.Execute(null), Throws.ArgumentException);
        }

        [Test]
        public void ThrowsArgumentException_When_CannotParseArgumentList()
        {
            var args = new List<string>{"Sofia", "vTurnovo"};

            this.createTicketCommand = new CreateTicketCommand(this.travelerFactoryMock.Object,
                this.dataStoreMock.Object, this.commandConstants);


            Assert.That(() => this.createTicketCommand.Execute(args), Throws.ArgumentException);
        }

        [Test]
        public void ThrowsArgumentException_When_JourneyDoesNotExistInDataStore()
        {
            var journeyId = 999;
            var args = new List<string> {journeyId.ToString(), "21"};
            
            var journyStub1 = new Mock<IJourney>();
            var journyStub2 = new Mock<IJourney>();
            var journyStub3 = new Mock<IJourney>();

            var dataStoredJourneys = new List<IJourney>
            {
                journyStub1.Object,
                journyStub2.Object,
                journyStub3.Object
            };

            this.dataStoreMock
                .Setup(x => x.Journeys)
                .Returns(dataStoredJourneys);

            this.createTicketCommand = new CreateTicketCommand(this.travelerFactoryMock.Object,
                this.dataStoreMock.Object, this.commandConstants);


            Assert.That(() => this.createTicketCommand.Execute(args), Throws.ArgumentException);
        }

        [Test]
        public void CallCreteTicketFromTravellerFactory_When_PassedValidArgumentLists()
        {
            var args = new List<string> { "0", "21" };

            var journyStub = new Mock<IJourney>();

            this.travelerFactoryMock
                .Setup(x => x.CreateTicket(It.IsAny<IJourney>(), It.IsAny<decimal>()));

            this.dataStoreMock
                .Setup(x => x.Journeys)
                .Returns(new List<IJourney> {journyStub.Object});

            this.createTicketCommand = 
                new CreateTicketCommand(this.travelerFactoryMock.Object,
                this.dataStoreMock.Object, this.commandConstants);

            createTicketCommand.Execute(args);

            this.travelerFactoryMock
                .Verify(x => x.CreateTicket(It.IsAny<IJourney>(), It.IsAny<decimal>()),Times.Once);
        }


        [Test]
        public void SaveTicketIntoDataStore_When_PassedValidArgumentLists()
        {
            var args = new List<string> { "0", "21" };

            var journyStub = new Mock<IJourney>();
            var ticketStub = new Mock<ITicket>();
            var dataStoreTickets = new List<ITicket>();

            this.travelerFactoryMock
                .Setup(x => x.CreateTicket(It.IsAny<IJourney>(), It.IsAny<decimal>()))
                .Returns(ticketStub.Object);

            this.dataStoreMock
                .Setup(x => x.Journeys)
                .Returns(new List<IJourney> { journyStub.Object });


            this.dataStoreMock
                .Setup(x => x.AddTicket(ticketStub.Object)).Returns(() =>
                {
                    dataStoreTickets.Add(ticketStub.Object);
                    var ticketId = 0;
                    return ticketId;
                });

            this.createTicketCommand = new CreateTicketCommand(this.travelerFactoryMock.Object,
                this.dataStoreMock.Object, this.commandConstants);

            createTicketCommand.Execute(args);

            Assert.That(dataStoreTickets, Contains.Item(ticketStub.Object));
        }

        [Test]
        public void ReturnCreatedTicketSuccessMessage_When_PassedValidArgumentLists()
        {
            var ticketId = 112;
            var args = new List<string> { "0", "21" };

            var journyStub = new Mock<IJourney>();
            var ticketStub = new Mock<ITicket>();

            this.travelerFactoryMock
                .Setup(x => x.CreateTicket(It.IsAny<IJourney>(), It.IsAny<decimal>()))
                .Returns(ticketStub.Object);

            this.dataStoreMock
                .Setup(x => x.Journeys)
                .Returns(new List<IJourney> { journyStub.Object });


            this.dataStoreMock
                .Setup(x => x.AddTicket(ticketStub.Object)).Returns(() => ticketId);

            this.createTicketCommand = new CreateTicketCommand(this.travelerFactoryMock.Object,
                this.dataStoreMock.Object, this.commandConstants);

            var expectedMessage = string.Format(this.commandConstants.TicketCreatedSuccessMessage, ticketId);
            var actualMessage = createTicketCommand.Execute(args);

            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }
    }
}