using System;
using System.Collections.Generic;
using System.Linq;
using Mathematics.General.Contracts;
using Mathematics.General.Models;
using Mathematics.Operations.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mathematics.Tests.General.Models
{
    [TestClass]
    public class OperationTableTests
    {
        private IOperationTable operationTable;

        [TestInitialize]
        public void Initialize()
        {
            this.operationTable = new OperationTable();
        }
     
        [TestMethod]
        public void Contains_Should_ReturnTrue_WhenArgumentIsDefinedOperation()
        {
            var operation = "+";
            Assert.IsTrue(this.operationTable.Contains(operation));
        }

        [TestMethod]
        public void Contains_Should_ReturnFalse_WhenArgumentIsUndefinedOperation()
        {
            var operation = "#";
            Assert.IsFalse(this.operationTable.Contains(operation));
        }

        [TestMethod]
        public void Indexer_Should_ThrowArgumentException_When_ArgumentIsUndefinedOperation()
        {
            var operation = "@";
            Assert.ThrowsException<ArgumentException>(() => this.operationTable[operation]);
        }

        [TestMethod]
        public void Indexer_Should_ReturnValueTuple_When_ArgumentIsDefinedOperation()
        {
            var operation = "*";
            var expected = (Associativity: OperationAssociativity.LeftToRight, Priority: 6);

            Assert.AreEqual(expected, this.operationTable[operation]);
        }

        [TestMethod]
        public void Operations_Should_ReturnCollectionOfAllDefinedOperations()
        {          
            var expectedOperations = new List<string>
            {
                "*", "/", "%", "+", "-", "<<", ">>", "&", "^", "|",
            };

            Assert.IsTrue(expectedOperations.SequenceEqual(this.operationTable.Operations));
        }
    }
}
