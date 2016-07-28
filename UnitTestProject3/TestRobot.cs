using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication2;

namespace UnitTestProject3
{
    [TestClass]
    public class TestMethodRobot
    {
        [TestMethod]
        public void TestRobot()
        {
            Robot robot = new Robot(new Vector(0, -2), new Angle(0), Math.PI, Math.PI);
            RobotCommand command = new RobotCommand(1, Math.PI, Math.PI / 2);
            robot = robot.Move(command);
            Assert.AreEqual(robot, new Robot(new Vector(2, 0), new Angle(Math.PI/2), Math.PI, Math.PI));
            command = new RobotCommand(1, Math.PI, Math.PI / 2);
            robot = robot.Move(command);
            Assert.AreEqual(robot, new Robot(new Vector(0, 2), new Angle(Math.PI), Math.PI, Math.PI));
            command = new RobotCommand(1, Math.PI, Math.PI / 2);
            robot = robot.Move(command);
            Assert.AreEqual(robot, new Robot(new Vector(-2, 0), new Angle(-Math.PI/2), Math.PI, Math.PI));
            command = new RobotCommand(1, Math.PI, Math.PI / 2);
            robot = robot.Move(command);
            Assert.AreEqual(robot, new Robot(new Vector(0, -2), new Angle(0), Math.PI, Math.PI));
            command = new RobotCommand(1, Math.PI/2, Math.PI / 4);
            robot = robot.Move(command);
            Assert.AreEqual(robot, new Robot(new Vector(Math.Sqrt(2), -Math.Sqrt(2)), new Angle(Math.PI / 4), Math.PI, Math.PI));
            command = new RobotCommand(1, Math.PI/4, Math.PI / 8);
            robot = robot.Move(command);
            Assert.AreEqual(robot, new Robot(new Vector(Math.Cos(-Math.PI / 8) * 2, Math.Sin(-Math.PI / 8) * 2), new Angle(3 * Math.PI / 8), Math.PI, Math.PI));
        }
        [TestMethod]
        public void TestRobot1()
        {
            Robot robot = new Robot(new Vector(2-Math.Sqrt(2),2+ Math.Sqrt(2)), new Angle(-3*Math.PI/4), Math.PI, Math.PI);
            RobotCommand command = new RobotCommand(1, Math.PI/4, Math.PI / 8);
            robot = robot.Move(command);
            Assert.AreEqual(robot, new Robot(new Vector(2+Math.Cos(7*Math.PI / 8) * 2, 2+Math.Sin(7*Math.PI / 8) * 2), new Angle(-5*Math.PI/8), Math.PI, Math.PI));
            command = new RobotCommand(1, Math.PI/4, Math.PI / 8);
            robot = robot.Move(command);
            Assert.AreEqual(robot, new Robot(new Vector(0, 2), new Angle(-Math.PI/2), Math.PI, Math.PI));
            command = new RobotCommand(1, Math.PI, Math.PI / 2);
            robot = robot.Move(command);
            Assert.AreEqual(robot, new Robot(new Vector(2, 0), new Angle(0), Math.PI, Math.PI));           
        }
        [TestMethod]
        public void TestRobot3()
        {
            Robot robot = new Robot(new Vector(0, -2), new Angle(0), Math.PI, Math.PI);
            RobotCommand command = new RobotCommand(2, Math.PI, Math.PI / 2);
            robot = robot.Move(command);
            Assert.AreEqual(robot, new Robot(new Vector(0, 2), new Angle(Math.PI), Math.PI, Math.PI));
            command = new RobotCommand(3, Math.PI, Math.PI / 2);
            robot = robot.Move(command);
            Assert.AreEqual(robot, new Robot(new Vector(2, 0), new Angle(Math.PI/2), Math.PI, Math.PI));
            Robot robot1 = new Robot(new Vector(2 - Math.Sqrt(2), 2 + Math.Sqrt(2)), new Angle(-3 * Math.PI / 4), Math.PI, Math.PI);
            RobotCommand command1 = new RobotCommand(2, Math.PI / 4, Math.PI / 8);
            robot1 = robot1.Move(command1);
            Assert.AreEqual(robot1, new Robot(new Vector(0,2), new Angle( -Math.PI / 2), Math.PI, Math.PI));
        }
        [TestMethod]
        public void TestRobotLinear()
        {
            Robot robot = new Robot(new Vector(0, 0), new Angle(0), Math.PI, Math.PI);
            RobotCommand command = new RobotCommand(1, Math.PI / 2, 0);
            robot = robot.Move(command);
            Assert.AreEqual(robot, new Robot(new Vector(Math.PI/2, 0), new Angle(0), Math.PI, Math.PI));
            command = new RobotCommand(4, Math.PI / 2, 0);
            robot = robot.Move(command);
            Assert.AreEqual(robot, new Robot(new Vector(5*Math.PI / 2, 0), new Angle(0), Math.PI, Math.PI));
            Robot robot1 = new Robot(new Vector(0, 0), new Angle(Math.PI/4), Math.PI, Math.PI);
            RobotCommand command1 = new RobotCommand(4, Math.PI / 2, 0);
            robot1 = robot1.Move(command1);
            Assert.AreEqual(robot1, new Robot(new Vector(2 * Math.PI * Math.Cos(Math.PI / 4), 2 * Math.PI * Math.Sin(Math.PI / 4)), new Angle(Math.PI/4), Math.PI, Math.PI));
        }
        [TestMethod]
        public void TestRobotAngular()
        {
            Robot robot = new Robot(new Vector(0, 0), new Angle(0), Math.PI, Math.PI);
            RobotCommand command = new RobotCommand(1, 0, Math.PI/8);
            robot = robot.Move(command);
            Assert.AreEqual(robot, new Robot(new Vector(0, 0), new Angle(Math.PI / 8), Math.PI, Math.PI));
            command = new RobotCommand(4, 0, Math.PI / 8);
            robot = robot.Move(command);
            Assert.AreEqual(robot, new Robot(new Vector(0, 0), new Angle(5*Math.PI/8), Math.PI, Math.PI));           
        }
        [TestMethod]
        public void TestRobotNull()
        {
            Robot robot = new Robot(new Vector(0, 0), new Angle(0), Math.PI, Math.PI);
            RobotCommand command = new RobotCommand(1, 0, 0);
            robot = robot.Move(command);
            Assert.AreEqual(robot, new Robot(new Vector(0, 0), new Angle(0), Math.PI, Math.PI));
            command = new RobotCommand(4, 0, 0);
            robot = robot.Move(command);
            Assert.AreEqual(robot, new Robot(new Vector(0, 0), new Angle(0), Math.PI, Math.PI));
            command = new RobotCommand(0, 0, 0);
            robot = robot.Move(command);
            Assert.AreEqual(robot, new Robot(new Vector(0, 0), new Angle(0), Math.PI, Math.PI));
            command = new RobotCommand(0, 3, 3);
            robot = robot.Move(command);
            Assert.AreEqual(robot, new Robot(new Vector(0, 0), new Angle(0), Math.PI, Math.PI));
        }
        [TestMethod]
        public void TestRobotMaxLimit()
        {
            Robot robot = new Robot(new Vector(0, 0), new Angle(0), Math.PI, Math.PI);
            RobotCommand command = new RobotCommand(1, 2*Math.PI, 0);
            robot = robot.Move(command);
            Assert.AreEqual(robot, new Robot(new Vector(0, 0), new Angle(0), Math.PI, Math.PI));
            command = new RobotCommand(4, 0, 2*Math.PI);
            robot = robot.Move(command);
            Assert.AreEqual(robot, new Robot(new Vector(0, 0), new Angle(0), Math.PI, Math.PI));
            command = new RobotCommand(2, 2 * Math.PI, 2 * Math.PI);
            robot = robot.Move(command);
            Assert.AreEqual(robot, new Robot(new Vector(0, 0), new Angle(0), Math.PI, Math.PI));           
        }
    }
}
