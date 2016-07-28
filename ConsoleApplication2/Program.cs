using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Targets;
using NLog.Config;

namespace ConsoleApplication2
{
    public static class Epsilon
    {
        public static double epsilon = 1e-6;
    }
    public class Vector
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }
        
        public Vector Subtract(Vector v)
        {
            return new Vector((X - v.X), Y - v.Y);
        }
        public Vector Add(Vector v)
        {
            return new Vector(X + v.X, Y + v.Y);
        }
        public Vector Multiply(double a)
        {
            return new Vector(X * a, Y * a);
        }
        public double Len()
        {
            return Math.Sqrt(X * X + Y * Y);
        }
        public double LenTwoVectors(Vector vector)
        {
            return Math.Sqrt(Math.Pow(X - vector.X, 2) + Math.Pow(Y - vector.Y, 2));
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Vector))
                return false;
            Vector vector = (Vector)obj;
            return X == vector.X && Y == vector.Y;            
        }
        public override string ToString()
        {
            return " X=" + X + ", Y=" + Y;
        }
        public override int GetHashCode()
        {
            return Tuple.Create(X, Y).GetHashCode();
        }
    }
    
    static class Program
    {
        public static Logger logger;
        static void Main(string[] args)
         {
             var config = new LoggingConfiguration();
             var fileTarget = new FileTarget();
             config.AddTarget("file", fileTarget);
             fileTarget.FileName = "${basedir}/file.txt";
             fileTarget.Layout = "${message}";             
             var rule = new LoggingRule("*", LogLevel.Debug, fileTarget);
             config.LoggingRules.Add(rule);
             LogManager.Configuration = config;
             logger = LogManager.GetCurrentClassLogger();
             
             ScenariosRobotNavigator scenario = new ScenariosRobotNavigator();
             scenario.scenario();
            Console.ReadLine();
        }
    }
}
