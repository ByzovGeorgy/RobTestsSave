using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAplication117;
using ConsoleApplication117;

namespace UnitTestProject1
{
    [TestClass]
    public class VectorTest
    {
        [TestMethod]
        public void TestMethodAdd()
        {
            Vector test1 = new Vector(100, 50);
            Vector test2 = new Vector(30, 20);
            Assert.AreEqual(test1.Add(test2), new Vector(130, 70));
        }
        [TestMethod]
        public void TestMethodMultiply()
        {
            Vector test1 = new Vector(100, 50);
            double a = 5;
            Assert.AreEqual(test1.Multiply(a), new Vector(500, 250));
        }
        [TestMethod]
        public void TestMethodLen()
        {
            Vector test1 = new Vector(2, 2);
            double a = 8;
            Assert.AreEqual(test1.Len(), Math.Sqrt(a));
        }        

    }
}
