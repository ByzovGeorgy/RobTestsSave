using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class ImprovedSmartNavigator:IRobotNavigator
    {
        private readonly Vector destination;

        public ImprovedSmartNavigator(Vector destination)
        {
            this.destination = destination;
        }
        public static double Dt = 0.3;
        public RobotCommand GetNextCommand(Robot robot)
        {
            Vector vector = new Vector(destination.X - robot.Map.X, destination.Y - robot.Map.Y);
            Vector vector1 = new Vector(Math.Cos(robot.Direction.A), Math.Sin(robot.Direction.A));
            Vector vector2 = new Vector(Math.Cos(robot.Direction.A + Math.PI), Math.Sin(robot.Direction.A + Math.PI));
            Angle s = new Angle(vector);
            Angle s1 = new Angle(vector1);
            Angle s2 = new Angle(vector2);
            double a = MinAngle(s.A, s1.A);
            double a1 = MinAngle(s.A, s2.A);
            if (Math.Abs(a1) < Math.Abs(a))
                a = a1;
            if (Math.Abs(a) >= 1e-6)
            {
                double time = Math.Abs(a / robot.MaxAngleVelocity);
                if (time > Dt)
                    time = Dt;
                if (a > 0)
                    return new RobotCommand(time, 0, robot.MaxAngleVelocity);
                return new RobotCommand(time, 0, -robot.MaxAngleVelocity);
            }
            double len = robot.Map.LenTwoVectors(destination);
            double time1 = len / robot.MaxLinearVelocity;
            if (time1 > Dt)
                time1 = Dt;
            if (a == a1)
                return new RobotCommand(time1, -robot.MaxLinearVelocity, 0);
            return new RobotCommand(time1, robot.MaxLinearVelocity, 0);
        }
        private double MinAngle(double angle1, double angle2)
        {      
            if (angle1 < 0)
                angle1 = 2 * Math.PI + angle1;
            if (angle2 < 0)
                angle2 = 2 * Math.PI + angle2;
            double a = angle1 - angle2;
            if (a > Math.PI)
                 a -= 2 * Math.PI;
            if (a < -Math.PI)
                 a += 2 * Math.PI;
            return a;
        }
    }
}
