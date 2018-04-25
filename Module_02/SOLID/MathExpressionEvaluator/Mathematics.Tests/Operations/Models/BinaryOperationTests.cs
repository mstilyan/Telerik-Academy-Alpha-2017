using System;
using Mathematics.Operands.Contracts;
using Mathematics.Operations.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Mathematics.Tests.Operations.Models
{
    [TestClass]
    public class BinaryOperationTests
    {
        private Mock<BinaryOperation> binaryOperationMock;

        [TestInitialize]
        public void Initialize()
        {
            this.binaryOperationMock = new Mock<BinaryOperation>();
        }

        [TestMethod]
        public void AddOperad_Should_AddOperadToList_When_ArgumentNotNull()
        {
            var operandStub = new Mock<IOperand>();
            var binaryOperationFake = new BinaryOperationFake();

            binaryOperationFake.AddOperand(operandStub.Object);

            Assert.IsTrue(binaryOperationFake.OperationContainsOperand(operandStub.Object));
        }

        [TestMethod]
        public void AddOperad_Should_ThrowInvalidOperationException_AfterSecondCallback()
        {
            var operandStub = new Mock<IOperand>();

            this.binaryOperationMock.Object.AddOperand(operandStub.Object);
            this.binaryOperationMock.Object.AddOperand(operandStub.Object);

            Assert.ThrowsException<InvalidOperationException>(
                () => this.binaryOperationMock.Object.AddOperand(operandStub.Object));
        }

        [TestMethod]
        public void AddOperad_Should_ThrowArgumentNullException_When_ArgumentIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => this.binaryOperationMock.Object.AddOperand(null));
        }

        [TestMethod]
        public void Result_Should_ThrowInvalidOperationException_When_IsCompleteReturnsFalse()
        {
            Assert.ThrowsException<InvalidOperationException>(() => this.binaryOperationMock.Object.Result);
        }

        [TestMethod]
        public void Result_Should_InvokeApplyOperation_When_IsCompleReturnsTrue()
        {
            var operand = new Mock<IOperand>();

            var binaryOperationFake = new BinaryOperationFake();

            binaryOperationFake.AddOperand(operand.Object);
            binaryOperationFake.AddOperand(operand.Object);

            Assert.ThrowsException<NotImplementedException>(() => binaryOperationFake.Result);
        }

        [TestMethod]
        public void IsComplete_Should_ReturnTrue_When_BeforehandAddOperandCalledAtLeastTwice()
        {
            var operand = new Mock<IOperand>();

            this.binaryOperationMock.Object.AddOperand(operand.Object);
            this.binaryOperationMock.Object.AddOperand(operand.Object);

            Assert.IsTrue(this.binaryOperationMock.Object.IsComplete);
        }

        [TestMethod]
        public void IsComplete_Should_ReturnFalse_When_BeforehandAddOperandCalledLessThanTwice()
        {
            var operand = new Mock<IOperand>();

            this.binaryOperationMock.Object.AddOperand(operand.Object);

            Assert.IsFalse(this.binaryOperationMock.Object.IsComplete);
        }

        internal class BinaryOperationFake : BinaryOperation
        {
            protected override IOperand ApplyOperation(IOperand o1, IOperand o2)
            {
                throw new NotImplementedException();
            }

            public bool OperationContainsOperand(IOperand operand)
            {
                return this.Operands.Contains(operand);
            }
        }
    }
}