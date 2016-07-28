using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication2;

namespace UnitTestProject1
{
    [TestClass]
    public class VectorTest
    {
        [TestMethod]
        public void TestMethod()
        {
            Vector test1 = new Vector(100, 50);
            Vector test2 = new Vector(30, 20);
            Vector test3 = new Vector(30, 20);
            Vector test4 = new Vector(30, 20);
            Assert.AreEqual(test1.Add(test2), new Vector(130, 70));
            Assert.AreEqual(test1.Add(test2), test1.Add(test2));
            Assert.AreEqual(test1.Subtract(test2), new Vector(70, 30));
            Assert.AreEqual(test1.Subtract(test2), test1.Subtract(test2));
            Assert.AreEqual(test2, test2);
            Assert.AreEqual(test2, test2);
            Assert.AreEqual(test2, test3);
            Assert.AreEqual(test3, test2);
            Assert.AreEqual(test3, test4);
            Assert.AreEqual(test2, test4);
        }
        [TestMethod]
        public void TestMethodAdd()
        {
            Vector test1 = new Vector(100, 50);
            Vector test2 = new Vector(30, 20);
            Assert.AreEqual(test1.Add(test2), new Vector(130, 70));
            Assert.AreEqual(test1.Subtract(test2), new Vector(70, 30));
        }
        [TestMethod]
        public void TestMethodMultiply()
        {
            Vector test1 = new Vector(100, 50);
            Assert.AreEqual(test1.Multiply(5), new Vector(500, 250));
            Assert.AreEqual(test1.Multiply(0), new Vector(0, 0));
        }
        [TestMethod]
        public void TestMethodLen()
        {
            Vector test1 = new Vector(2, 2);
            Vector test2 = new Vector(0, 0);
            Assert.AreEqual(test1.Len(), Math.Sqrt(8));
            Assert.AreEqual(test2.Len(), 0);
        }
        [TestMethod]
        public void TestMethodGetHash()
        {
            Vector test1 = new Vector(100, 50);
            Vector test2 = new Vector(100, 50);
            Vector test3 = new Vector(50, 100);
            Assert.AreEqual(test1.GetHashCode(), test2.GetHashCode());
            Assert.AreNotEqual(test1.GetHashCode(), test3.GetHashCode());
        }
        [TestMethod]
        public void TestMethodEquals()
        {
            Vector test1 = new Vector(100, 50);
            Vector test2 = new Vector(100, 50);
            Vector test3 = new Vector(50, 100);
            Assert.AreEqual(test1.Equals(test1), true);
            Assert.AreEqual(test1.Equals(test2), true);
            Assert.AreNotEqual(test1.Equals(test3), true);
        }
    }
}
