using Mathematics.Operands.Contracts;
using Mathematics.Operands.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;

namespace Mathematics.Tests.Operands.Models
{
    [TestClass]
    public class IntTypeTests
    {
        [TestMethod]
        public void AssignCorrectValueInConstructor()
        {        
            var intType = new Mathematics.Operands.Models.IntType(6);
            Assert.AreEqual(6, intType.Value);
        }

        [TestMethod]
        public void ParseMethod_Should_ThrowArgumentException_When_ParameterIsNotParsable()
        {
            Assert.ThrowsException<ArgumentException>(() => Mathematics.Operands.Models.IntType.Parse("aa"));
        }

        [TestMethod]
        public void ParseMethod_Should_Return_IntType_When_ValidParametersArePassed()
        {
            var num = Mathematics.Operands.Models.IntType.Parse("6");
            Assert.IsInstanceOfType(num, typeof(Mathematics.Operands.Models.IntType));
        }
    }
}
