using Mathematics.Engine;
using Mathematics.General.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathematics.General.Contracts;
using Mathematics.Engine.Contracts;
using Mathematics.General.Exception;
using Mathematics.Operands.Models;
using Mathematics.Operations.Contracts;

namespace Mathematics.Tests.Engine
{
    [TestClass]
    public class PostfixCalculatorTests
    {
        private Mock<IOperationTable> operationTableMock;
        private Mock<IOperationFactory> opeartionFacotryMock;
        private IPostfixCalculator postfixCalculator;

        [TestInitialize]
        public void Initialize()
        {
            this.operationTableMock = new Mock<IOperationTable>();
            this.opeartionFacotryMock = new Mock<IOperationFactory>();
        }

        [TestMethod]
        public void EvaluateExpression_Should_ThrowArgumentNullException_When_PassedNull()
        {
            this.postfixCalculator =
                new PostfixCalculator(this.operationTableMock.Object, this.opeartionFacotryMock.Object);

            Assert.ThrowsException<ArgumentNullException>(() => this.postfixCalculator.EvaluateExpression(null));
        }

        [TestMethod]
        public void EvaluateExpression_Should_ThrowInvalidMathematicalExpressionException_When_PassedEmptyCollection()
        {
            this.postfixCalculator =
                new PostfixCalculator(this.operationTableMock.Object, this.opeartionFacotryMock.Object);

            Assert.ThrowsException<InvalidMathematicalExpressionException>(
                () => this.postfixCalculator.EvaluateExpression(new List<string>()));
        }

        [TestMethod]
        public void EvaluateExpression_Should_InvokeCreateOperation_When_Passed_StringEnumerableContainigOperation()
        {
            const string operation = "+";
            this.operationTableMock.Setup(x => x.Contains(operation)).Returns(true);
            this.opeartionFacotryMock.Setup(x => x.CreateOperation(operation)).Throws<NotImplementedException>();

            this.postfixCalculator =
                new PostfixCalculator(this.operationTableMock.Object, this.opeartionFacotryMock.Object);

            try
            {
                this.postfixCalculator.EvaluateExpression(new List<string> { "2", "2", operation });
            }
            catch (NotImplementedException) { }

            this.opeartionFacotryMock.Verify(x => x.CreateOperation(operation), Times.Once);
        }

        [TestMethod]
        public void EvaluateExpression_Should_ThrowInvalidMathematicaExpressionException_When_Passed_StringEnumerableWhitInvalidElement()
        {
            const string token = "Pesho";
            var args = new List<string> { token };
            this.operationTableMock.Setup(x => x.Contains(token)).Returns(false);

            this.postfixCalculator = new PostfixCalculator(this.operationTableMock.Object, this.opeartionFacotryMock.Object);

            Assert.ThrowsException<InvalidMathematicalExpressionException>(() => this.postfixCalculator
                .EvaluateExpression(args));
        }

        [TestMethod]
        public void EvaluateExpression_Should_ThrowInvalidOperationException_When_OperationCannotBeExecuted()
        {
            const string operation = "+";
            var args = new List<string> { operation };

            var operationStub = new Mock<IOperation>();

            this.operationTableMock.Setup(x => x.Contains(operation)).Returns(true);
            this.opeartionFacotryMock.Setup(x => x.CreateOperation(operation)).Returns(operationStub.Object);

            this.postfixCalculator = new PostfixCalculator(this.operationTableMock.Object, this.opeartionFacotryMock.Object);
            
            Assert.ThrowsException<InvalidOperationException>(() => this.postfixCalculator
                .EvaluateExpression(args));
        }
    }
}
