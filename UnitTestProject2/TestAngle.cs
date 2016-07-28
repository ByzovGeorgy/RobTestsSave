using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication2;

namespace UnitTestProject2
{
    [TestClass]
    public class AngleTest
    {
        [TestMethod]
        public void TestMethodAngle()
        {
            Angle test = new Angle(Math.PI / 4);
            Assert.AreEqual(test.A, Math.PI / 4);  // Pi/4
            Angle test1 = new Angle(Math.PI);
            Assert.AreEqual(test1.A, Math.PI);      //Pi
            Angle test2 = new Angle(-Math.PI);
            Assert.AreEqual(test2.A, Math.PI);        //-Pi                                   
            Angle test10 = new Angle(-3 * Math.PI / 4);
            Assert.AreEqual(test10.A, -3 * Math.PI / 4);   //-3*Pi/4
            Angle test3 = new Angle(-2*Math.PI);
            Assert.AreEqual(test3.A, 0);                    //-2*Pi
            Angle test4 = new Angle(2*Math.PI);
            Assert.AreEqual(test4.A, 0);                    //2*Pi
            Angle test5 = new Angle(-5*Math.PI/4);
            Assert.AreEqual(test5.A, 3*Math.PI/4);          //3*Pi/4
            Angle test6 = new Angle(-9*Math.PI/4);
            Assert.AreEqual(test6.A, -Math.PI/4);             //-9*Pi/4
            Angle test7 = new Angle(-13 * Math.PI / 4);
            Assert.AreEqual(test7.A, 3 * Math.PI / 4,Epsilon.epsilon);      //-13*Pi/4
        }
        [TestMethod]
        public void TestMethodAngleAdd()
        {
            Angle test1 = new Angle(0);
            Angle test2 = new Angle(3.44);
            Assert.AreEqual(test1.Add(0.7),new Angle(0.7));
            Assert.AreEqual(test1.Add(test2.A), new Angle(3.44 - 2 * Math.PI));
            Assert.AreEqual(test1.Add(3),new Angle( 3));
            Assert.AreEqual(test1.Add(5*Math.PI), new Angle( Math.PI));
            Assert.AreEqual(test1.Add(0), new Angle(0));
        }
        [TestMethod]
        public void TestMethodAngleSubtract()
        {
            Angle test1 = new Angle(0.0);
            Angle test2 = new Angle(3.44);
            Assert.AreEqual(test1.Subtract(3.44),new Angle( -3.44 + 2 * Math.PI));
            Assert.AreEqual(test1.Subtract(test2.A), new Angle(-3.44 + 2 * Math.PI));
            Assert.AreEqual(test1.Subtract(3), new Angle(-3));
            Assert.AreEqual(test1.Subtract(5 * Math.PI),new Angle( Math.PI));
            Assert.AreEqual(test1.Subtract(-5 * Math.PI),new Angle( Math.PI));
            Assert.AreEqual(test1.Subtract(-3 * Math.PI / 4),new Angle (3 * Math.PI / 4));
        }
        [TestMethod]
        public void TestMethodAngleNull()
        {
            Angle test3 = new Angle(0);
            Assert.AreEqual(test3.A, 0);
            Angle test4 = new Angle(0.0004);
            Assert.AreEqual(test4.A, 0.0004);
        }
        [TestMethod]
        public void TestMethodAngleBig()
        {
            Angle test5 = new Angle(10 * Math.PI);
            Assert.AreEqual(test5.A, 0);
            Angle test6 = new Angle(20 * Math.PI);
            Assert.AreEqual(test6.A, 0);
            Angle test7 = new Angle(-20 * Math.PI);
            Assert.AreEqual(test7.A, 0);
            Angle test8 = new Angle(200 * Math.PI);
            Assert.AreEqual(test8.A, 0);
            Angle test1 = new Angle(200 * Math.PI/3);
            Assert.AreEqual(test1.A,  2*Math.PI/3,Epsilon.epsilon);
            Angle test9 = new Angle(138.634634);
            Assert.AreEqual(test9.A, 138.634634-(44 * Math.PI));
            Angle test = new Angle(300 * Math.PI / 400);
            Assert.AreEqual(test.A, 3 * Math.PI / 4);
        }
        [TestMethod]
        public void TestMethodAngleVector()
        {
            Angle test1 = new Angle(new Vector(2, 2));
            Assert.AreEqual(test1.A, Math.PI / 4, Epsilon.epsilon);
            Angle test2 = new Angle(new Vector(-2, -2));
            Assert.AreEqual(test2.A, -3 * Math.PI / 4, Epsilon.epsilon);
            Angle test3 = new Angle(new Vector(2, -2));
            Assert.AreEqual(test3.A, -Math.PI / 4, Epsilon.epsilon);
        }
        [TestMethod]
        public void TestMethodAngleHash()
        {
            Angle test5 = new Angle(10 * Math.PI);
            Assert.AreEqual(test5.GetHashCode(), (0).GetHashCode());
            Angle test6 = new Angle( Math.PI);
            Assert.AreEqual(test6.GetHashCode(), (Math.PI).GetHashCode());
            Angle test = new Angle(300 * Math.PI / 400);
            Assert.AreEqual(test.GetHashCode(), (3*Math.PI/4).GetHashCode());            
        }
        [TestMethod]
        public void TestMethodAngleEquals()
        {
            Angle test1 = new Angle( Math.PI);
            Angle test2 = new Angle( Math.PI);
            Angle test3 = new Angle(3* Math.PI);
            Angle test4 = new Angle(0);
            Assert.AreEqual(test1.Equals(test2), true);
            Assert.AreEqual(test1.Equals(test3), true);
            Assert.AreEqual(test1.Equals(test4), false);
        }
    }
}
