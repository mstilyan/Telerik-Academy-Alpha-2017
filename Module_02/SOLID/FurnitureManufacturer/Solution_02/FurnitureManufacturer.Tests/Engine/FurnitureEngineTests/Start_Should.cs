using FurnitureManufacturer.Commands.Contracts;
using FurnitureManufacturer.Engine;
using FurnitureManufacturer.Engine.Contracts;
using FurnitureManufacturer.Interfaces.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace FurnitureManufacturer.Tests.Engine.FurnitureEngineTests
{
    [TestClass]
    public class Start_Should
    {
        [TestMethod]
        public void CallCreateCommandFactory_WithCorrectCommandName()
        {
            var commandLine = "somecommand some parameters";
            var commandName = commandLine.Split()[0];

            var factoryMock = new Mock<ICommandsFactory>();
            var rendererStub = new Mock<IRenderer>();
            rendererStub.Setup(x => x.Input()).Returns(new List<string>() { commandLine });

            var sut = new FurnitureEngine(rendererStub.Object, factoryMock.Object);
            sut.Start();

            factoryMock.Verify(x => x.GetCommand(commandName), Times.Once);
        }

        [TestMethod]
        public void ExecuteCommand_WithCorrectCommandParameters()
        {
            var commandLine = "somecommand some parameters";
            var commandName = commandLine.Split()[0];
            var commandParams = commandLine.Split().Skip(1).ToList();

            var rendererStub = new Mock<IRenderer>();
            rendererStub.Setup(x => x.Input()).Returns(new List<string>() { commandLine });

            var commandMock = new Mock<ICommand>();
            var factoryStub = new Mock<ICommandsFactory>();
            factoryStub.Setup(x => x.GetCommand(commandName)).Returns(commandMock.Object);

            var sut = new FurnitureEngine(rendererStub.Object, factoryStub.Object);
            sut.Start();

            commandMock.Verify(x => x.Execute(commandParams), Times.Once);
        }

        [TestMethod]
        public void ReturnCorrectResultFromExecuteCommand_WithCorrectCommandParameters()
        {
            var commandLine = "somecommand some parameters";
            var commandName = commandLine.Split()[0];
            var commandParams = commandLine.Split().Skip(1).ToList();
            var commandReturn = "Command executed succesfully!";

            var rendererMock = new Mock<IRenderer>();
            rendererMock.Setup(x => x.Input()).Returns(new List<string>() { commandLine });

            var commandStub = new Mock<ICommand>();
            commandStub.Setup(x => x.Execute(commandParams)).Returns(commandReturn);

            var factoryStub = new Mock<ICommandsFactory>();
            factoryStub.Setup(x => x.GetCommand(commandName)).Returns(commandStub.Object);

            var sut = new FurnitureEngine(rendererMock.Object, factoryStub.Object);
            sut.Start();

            var outputList = new List<string>() { commandReturn };
            rendererMock.Verify(x => x.Output(outputList), Times.Once);
        }
    }
}
