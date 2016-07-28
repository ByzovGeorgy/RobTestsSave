using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApplication2
{
    public class ScenariosRobotNavigator
    {
        public void scenario()
        {
            List<Robot> robots = new List<Robot>();
            robots.Add(new Robot(new Vector(0, 0), new Angle(0), 1, 0.05));
            robots.Add(new Robot(new Vector(0, 0), new Angle(0), 1, 0.05));
            robots.Add(new Robot(new Vector(0, 0), new Angle(0), 1, 0.05));
            robots.Add(new Robot(new Vector(10, 20), new Angle(0), 1, 0.05));
            robots.Add(new Robot(new Vector(10, 20), new Angle(3), 1, 0.05));
            robots.Add(new Robot(new Vector(0, -10), new Angle(-1), 1, 0.05));
            List<Vector> vectors = new List<Vector>();
            vectors.Add(new Vector(10, 0));
            vectors.Add(new Vector(-10, 0));
            vectors.Add(new Vector(0, 100));
            vectors.Add(new Vector(10.1, 20.1));
            vectors.Add(new Vector(-100, -20));
            vectors.Add(new Vector(10, 100));
            var navigator = new List<IRobotNavigator>();
            var noise = new List<INoise> { new NullNoise(), new UniformNoise(0.1), new YourNoise(0.1) };
            double[] time = new double[6];
            Console.WriteLine("\t\t******Testing SimpleNavigator and ImprovedSmartNavigator*******");
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t NullNoise \t UniformNoise \t MyNoise");
            for (int i = 0; i < robots.Count; i++)
            {
                navigator.Add(new SimpleNavigator(vectors[i]));
                navigator.Add(new ImprovedSmartNavigator(vectors[i]));
                Console.Write("({0,0:00.00}, {1,0:00.00})     {2}\t({3},{4})    ", robots[i].Map.X, robots[i].Map.Y, robots[i].Direction.A, vectors[i].X, vectors[i].Y);
                for (int j = 0; j < 3; j++)
                {
                    Test(robots[i], navigator[2 * i], vectors[i], noise[j]);
                    time[2 * j] += timer;
                    timer = 0;
                    Test(robots[i], navigator[2 * i + 1], vectors[i], noise[j]);
                    time[2 * j + 1] += timer;
                    timer = 0;
                }
                Console.WriteLine();
            }
            Console.WriteLine("{0,0:.0}{1,8:.0}{2,8:.0}{3,8:.0}{4,8:.0}{5,8:.0}", time[0], time[1], time[2], time[3], time[4], time[5]);
            var testSmartNavigators = new List<IRobotNavigator>();
            Console.WriteLine();
            Console.WriteLine("Testing SmartNavigator");
            foreach (var i in noise)
            {
                double timerSmartNavigator = 0, timerImprovedSmartNavigator = 0;
                Console.WriteLine(i.GetType().Name);
                for (int k = 0; k < 50; k++)
                {
                    for (int c = 0; c < robots.Count; c++)
                    {
                        testSmartNavigators.Add(new SmartNavigator(vectors[c]));
                        TestSmartNavigator(robots[c], testSmartNavigators[2 * c], vectors[c], i);
                        timerSmartNavigator += timer;
                        timer = 0;
                        testSmartNavigators.Add(new ImprovedSmartNavigator(vectors[c]));
                        TestSmartNavigator(robots[c], testSmartNavigators[2 * c + 1], vectors[c], i);
                        timerImprovedSmartNavigator += timer;
                        timer = 0;
                    }
                }
                Console.WriteLine(timerSmartNavigator / 50);
                Console.WriteLine(timerImprovedSmartNavigator / 50);
            }
        }
        public void Test(Robot robot, IRobotNavigator navigator, Vector vector, INoise noise)
        {
            Robot robot1 = new Robot(robot.Map, robot.Direction, robot.MaxLinearVelocity, robot.MaxAngleVelocity);
            double time = 0;
            while (robot1.Map.LenTwoVectors(vector) >= 1e-6)
            {
                RobotCommand rc=navigator.GetNextCommand(robot1);
                Program.logger.Info("{0}\r\nTarget point=({1,0:0.00}, {2,0:0.00})\r\nDistance to the point=({3,0:0.00})\r\nRobot before Move: Position=({4,0:0.00}, {5,0:0.00}) Direction=({6,0:0.00})",
                    navigator.GetType().Name, vector.X, vector.Y, robot1.Map.LenTwoVectors(vector), robot1.Map.X, robot1.Map.Y, robot1.Direction.A);
                robot1 = robot1.Move(rc,noise);
                time += rc.Duration;
                Program.logger.Info("RobotComman({0,0:0.000}, {1,0:0.00}, {2,0:0.00})", rc.Duration, rc.Velocity, rc.AngularVelocity);
                Program.logger.Info("Robot after Move: Position=({0,0:0.00}, {1,0:0.00}) Direction=({2,0:0.00})\r\nDistance to the point=({3,0:0.00})\r\nThe total time of moving the robot=({4,0:0.00})\r\n", robot1.Map.X, robot1.Map.Y, robot1.Direction.A, robot1.Map.LenTwoVectors(vector), time);
            }           
            timer += time;
            Console.Write("\t{0,0:.0}", time);            
        }
        public void TestSmartNavigator(Robot robot, IRobotNavigator navigator, Vector vector, INoise noise)
        {
            Robot robot1 = new Robot(robot.Map, robot.Direction, robot.MaxLinearVelocity, robot.MaxAngleVelocity);
            while (robot1.Map.LenTwoVectors(vector) >= 1e-6)
            {
                RobotCommand rc = navigator.GetNextCommand(robot1);
                robot1 = robot1.Move(rc, noise);
                timer += rc.Duration;
            }
        }
        public static double timer = 0;
    }
}
