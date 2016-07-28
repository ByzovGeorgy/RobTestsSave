using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAplication117;
using ConsoleApplication117;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodAngle1()
        {

            Angle test = new Angle(Math.PI/4);
            Assert.AreEqual(test.A, Math.PI / 4);
            Angle test1 = new Angle(Math.PI);
            Assert.AreEqual(test1.A, Math.PI);
            Angle test2 = new Angle(-Math.PI);
            Assert.AreEqual(test2.A, Math.PI);
            Angle test3 = new Angle(0);
            Assert.AreEqual(test3.A, 0);
            Angle test4 = new Angle(0.0004);
            Assert.AreEqual(test4.A, 0.0004);
            Angle test5 = new Angle(10 * Math.PI);
            Assert.AreEqual(test5.A, 0);
            Angle test6 = new Angle(100 * Math.PI);
            Assert.AreEqual(test6.A, 0);
            Angle test7 = new Angle(10000 * Math.PI);
            Assert.AreEqual(test7.A, 0);
            Angle test8 = new Angle(-1 * Math.PI);
            Assert.AreEqual(test8.A, Math.PI);
            Angle test9 = new Angle(-10000 * Math.PI);
            Assert.AreEqual(test9.A, 0);
            Angle test10 = new Angle(-3 * Math.PI/4);
            Assert.AreEqual(test10.A, -3 * Math.PI / 4);
        }
    }
}
