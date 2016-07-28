using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class Robot
    {
        public Vector Map { get;  set; }
        public Angle Direction { get; set; }
        public double MaxLinearVelocity;
        public double MaxAngleVelocity;
        public Robot(Vector map, Angle direction, double maxLinearVelocity, double maxAngleVelocity)
        {
            Map = map;
            Direction = direction;
            MaxLinearVelocity = maxLinearVelocity;
            MaxAngleVelocity = maxAngleVelocity;
        }
        public override string ToString()
        {
            return Map.ToString() + Direction.ToString(); 
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Robot))
                return false;
            Robot robot = (Robot)obj;
            if (Math.Abs(robot.Map.X - Map.X) <= Epsilon.epsilon && Math.Abs(robot.Map.Y - Map.Y) <= Epsilon.epsilon 
                && Math.Abs(robot.Direction.A-Direction.A)<=Epsilon.epsilon
                && robot.MaxLinearVelocity == MaxLinearVelocity && robot.MaxAngleVelocity == MaxAngleVelocity)
                return true;
            return false;
        }
        public double Dt = 0.1;
        public Robot Move(RobotCommand command, INoise noise)
        {
            int cycle = (int)(command.Duration / Dt);
            if (command.Duration % Dt != 0)
                cycle += 1;
            double velocity = 0, angularVelocity = 0, duration = 0;
            for (int i = 0; i < cycle; i++)
            {
                velocity = command.Velocity + noise.NoiseVelocity(command.Velocity);
                angularVelocity = command.AngularVelocity + noise.NoiseVelocity(command.AngularVelocity);
                if (cycle - i > 1)
                    duration = Dt;
                else
                    duration = command.Duration - Dt * i;
                double alpha = Direction.A + angularVelocity * duration;
                if (angularVelocity == 0)
                {
                    double speedX = duration * velocity * Math.Cos(alpha);
                    double speedY = duration * velocity * Math.Sin(alpha);
                    Map = Map.Add(new Vector(speedX, speedY));
                }
                else if (velocity == 0)
                    Direction = Direction.Add(duration * angularVelocity);
                //if (command.Velocity != 0 && command.AngularVelocity != 0)
                else
                {
                    double radius = velocity / angularVelocity;
                    Vector centre = new Vector(Map.X + radius * Math.Cos(Direction.A + Math.PI / 2), Map.Y + radius * Math.Sin(Direction.A + Math.PI / 2));
                    Vector x1 = new Vector(Map.X - centre.X, Map.Y - centre.Y);
                    Angle ang = new Angle((x1.X) / (x1.Len()));
                    double betta = Math.Acos(ang.A);
                    if (centre.Y > Map.Y)
                        betta *= -1;
                    Map = new Vector(centre.X + radius * Math.Cos(betta + angularVelocity * duration),
                        centre.Y + radius * Math.Sin(betta + angularVelocity * duration));
                    Direction = new Angle(alpha);
                }
            }
            return new Robot(Map, Direction, MaxLinearVelocity, MaxAngleVelocity);
        }
    }
    public class RobotCommand
    {
        public double Duration; // продолжительность команды в секундах
        public double Velocity; // линейная скорость
        public double AngularVelocity; // угловая скорость
        public RobotCommand(double a,double b,double c)
        {
            Duration = a;
            Velocity = b;
            AngularVelocity = c;
        }        
    }
}
