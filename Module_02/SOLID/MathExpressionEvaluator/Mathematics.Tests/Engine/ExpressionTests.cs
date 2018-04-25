using Mathematics.Engine;
using Mathematics.Engine.Contracts;
using Mathematics.Operands.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics.Tests.Engine
{
    [TestClass]
    public class ExpressionTests
    {
        [TestMethod]
        public void Evaluate_Should_Throw_NullArgumentExceptionWithNullString()
        {
            var parser = new Mock<IExpressionParser>();
            parser.Setup(x => x.Parse(null)).Throws(new ArgumentNullException());

            var postfixConverter = new Mock<IInfixToPostfixConverter>();
            var postfixCalculator = new Mock<IPostfixCalculator>();

            var expression = new Expression(parser.Object, postfixConverter.Object, postfixCalculator.Object);

            string message = expression.Evaluate(null);

            StringAssert.Contains(message, "Value cannot be null");
        }

        [TestMethod]
        public void Evaluate_Should_Call_ParseMethod_Once()
        {
            var parser = new Mock<IExpressionParser>();
            var postfixConverter = new Mock<IInfixToPostfixConverter>();
            var postfixCalculator = new Mock<IPostfixCalculator>();
            var operand = new Mock<IOperand>();
            var expression = new Expression(parser.Object, postfixConverter.Object, postfixCalculator.Object);
            postfixCalculator.Setup(x => x.EvaluateExpression(It.IsAny<IEnumerable<string>>())).Returns(operand.Object);
            expression.Evaluate("2+2");
            parser.Verify(x => x.Parse(It.IsAny<string>()), Times.Once);           
        }

        [TestMethod]
        public void Evaluate_Should_Call_InfixToPostfix_Once()
        {
            var parser = new Mock<IExpressionParser>();
            var postfixConverter = new Mock<IInfixToPostfixConverter>();
            var postfixCalculator = new Mock<IPostfixCalculator>();
            var operand = new Mock<IOperand>();

            var expression = new Expression(parser.Object, postfixConverter.Object, postfixCalculator.Object);
            postfixCalculator.Setup(x => x.EvaluateExpression(It.IsAny<IEnumerable<string>>())).Returns(operand.Object);
            expression.Evaluate("2+2");
            postfixConverter.Verify(x => x.ConvertInfixToPostfix(It.IsAny<string[]>()), Times.Once);
        }

        [TestMethod]
        public void Evaluate_Should_Call_EvaluateExpression_Once()
        {
            var parser = new Mock<IExpressionParser>();
            var postfixConverter = new Mock<IInfixToPostfixConverter>();
            var postfixCalculator = new Mock<IPostfixCalculator>();
            var operand = new Mock<IOperand>();

            var expression = new Expression(parser.Object, postfixConverter.Object, postfixCalculator.Object);
            postfixCalculator.Setup(x => x.EvaluateExpression(It.IsAny<IEnumerable<string>>())).Returns(operand.Object);
            expression.Evaluate("2+2");
            postfixCalculator.Verify(x => x.EvaluateExpression(It.IsAny<IEnumerable<string>>()), Times.Once);
        }
    }
}
