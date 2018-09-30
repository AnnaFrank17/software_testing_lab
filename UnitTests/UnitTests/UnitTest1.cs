using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private Triangle _triangle;
        
        [TestInitialize]
        public void Before()
        {
            _triangle = new Triangle();
        }

        [TestMethod]
        public void CurrectResult()
        {
            Assert.IsTrue(_triangle.IsExist(5, 7, 3));
        }

        [TestMethod]
        public void IncorrectResult()
        {
            Assert.IsFalse(_triangle.IsExist(1, 8, 14));
        }

        [TestMethod]
        public void ThrowWhenNegativeA()
        {
            Assert.ThrowsException<ArgumentException>(() => _triangle.IsExist(-1, 8, 14));
        }

        [TestMethod]
        public void ThrowWhenNegativeB()
        {
            Assert.ThrowsException<ArgumentException>(() => _triangle.IsExist(1, -8, 14));
        }

        [TestMethod]
        public void ThrowWhenNegativeC()
        {
            Assert.ThrowsException<ArgumentException>(() => _triangle.IsExist(1, 8, -14));
        }

        [TestMethod]
        public void ThrowNullExc()
        {
            _triangle = null;
            Assert.ThrowsException<NullReferenceException>(() => _triangle.IsExist(1, 8, 14));
        }

        [TestMethod]
        public void ZeroValueExc()
        {
            Assert.ThrowsException<ArgumentException>(() => _triangle.IsExist(0, 0, 0));
        }

        [TestMethod]
        public void TheSameResult()
        {
            var a = _triangle.IsExist(5, 7, 3);
            var b = _triangle.IsExist(5, 7, 3);

            Assert.IsTrue(a == b);
        }

        [TestMethod]
        public void OverflowExc()
        {
            // max int + max int = -2 (?)
            Assert.ThrowsException<OverflowException>(() => _triangle.IsExist(Int32.MaxValue, Int32.MaxValue, Int32.MaxValue));
        }

        [TestMethod]
        public void TheSameNegative()
        {
            var a = _triangle.IsExist(1, 8, 14);
            var b = _triangle.IsExist(1, 8, 14);

            Assert.IsTrue(a == b);
        }
    }
}
