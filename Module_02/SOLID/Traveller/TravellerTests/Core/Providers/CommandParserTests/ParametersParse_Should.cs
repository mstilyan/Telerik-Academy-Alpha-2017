using System;
using System.Linq;
using Moq;
using NUnit.Framework;
using Traveller.Core.Contracts;
using Traveller.Core.Providers;

namespace TravellerTests.Core.Providers.CommandParserTests
{
    [TestFixture]
    public class ParseParameters_Should
    {
        [Test]
        public void ThrowArgumentNullException_When_PassedNull()
        {
            var commandFactoryStub = new Mock<ICommandFactory>();
            var commandParser = new CommandParser(commandFactoryStub.Object);

            Assert.That(() => commandParser.ParseParameters(null), Throws.ArgumentNullException);
        }

        [Test]
        public void ThrowArgumentException_When_PassedEmptyString()
        {
            var commandFactoryStub = new Mock<ICommandFactory>();
            var commandParser = new CommandParser(commandFactoryStub.Object);

            Assert.That(() => commandParser.ParseParameters(""), Throws.ArgumentException);
        }

        [Test]
        public void ReturnParametersList_When_PassedNotNullOrEmptyString()
        {
            const string commandLine = "samplecommand";
            var commandFactoryStub = new Mock<ICommandFactory>();
            var commandParser = new CommandParser(commandFactoryStub.Object);

            var actualCommandParametersList = commandParser.ParseParameters(commandLine);
            Assert.That(actualCommandParametersList, Is.Not.Null);
        }

        [Test]
        public void ReturnValidListOfCommand_When_ArgumentIsSplitByWhiteSpaces()
        {
            const string commandLine = "createjourney Sofia vTurnovo 300 0";

            var commandFactoryStub = new Mock<ICommandFactory>();
            var commandParser = new CommandParser(commandFactoryStub.Object);

            var expectedParametersList = commandLine.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToList();

            var actualCommandParametersList = commandParser.ParseParameters(commandLine);

            Assert.That(actualCommandParametersList, Is.EquivalentTo(expectedParametersList));
        }
    }
}