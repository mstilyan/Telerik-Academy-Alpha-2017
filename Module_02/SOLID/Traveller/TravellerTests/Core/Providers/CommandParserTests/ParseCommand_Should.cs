using System;
using Moq;
using NUnit.Framework;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;
using Traveller.Core.Providers;

namespace TravellerTests.Core.Providers.CommandParserTests
{
    [TestFixture]
    public class ParseCommand_Should
    {
        [Test]
        public void ThrowArgumentNullException_When_PassedNull()
        {
            var commandFactoryStub = new Mock<ICommandFactory>();
            var commandParser = new CommandParser(commandFactoryStub.Object);

            Assert.That(() => commandParser.ParseCommand(null), Throws.ArgumentNullException);
        }

        [Test]
        public void ThrowArgumentException_When_PassedEmptyString()
        {
            var commandFactoryStub = new Mock<ICommandFactory>();
            var commandParser = new CommandParser(commandFactoryStub.Object);

            Assert.That(() => commandParser.ParseCommand(""), Throws.ArgumentException);
        }

        [Test]
        public void CallsCreateCommandOnce_When_ArgumentIsNotNull()
        {
            const string commandLine = "createjourney Sofia vTurnovo 300 0";

            var commandFactoryMock = new Mock<ICommandFactory>();
            var commandParser = new CommandParser(commandFactoryMock.Object);

            commandParser.ParseCommand(commandLine);

            commandFactoryMock.Verify(x => x.CreateCommand(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void ThrowArgumentException_When_PassedIvalidCommandString()
        {
            const string commandLine = "createjourney Sofia vTurnovo 300 0";

            var commandFactoryStub = new Mock<ICommandFactory>();
            commandFactoryStub.Setup(x => x.CreateCommand(It.IsAny<string>())).Throws<ArgumentException>();

            var commandParser = new CommandParser(commandFactoryStub.Object);

            Assert.That(() => commandParser.ParseCommand(commandLine), Throws.ArgumentException);
        }

        [Test]
        public void ReturnsICommand_When_PassedValidCammandNameStringArgument()
        {
            const string commandLine = "createjourney Sofia vTurnovo 300 0";

            var commandMock = new Mock<ICommand>();
            var commandFactoryStub = new Mock<ICommandFactory>();

            commandFactoryStub.Setup(x => x.CreateCommand(It.IsAny<string>())).Returns(commandMock.Object);

            var commandParser = new CommandParser(commandFactoryStub.Object);

            var expectedCommand = commandMock.Object;
            var actualCommand = commandParser.ParseCommand(commandLine);

            Assert.That(expectedCommand, Is.EqualTo(actualCommand));
        }
    }
}