using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication117;

namespace ConsoleAplication117
{
    public class Vector
    {
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; private set; }
        public double Y { get; private set; }

        public Vector Subtract(Vector v)
        {
            return new Vector(X - v.X, Y - v.Y);
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
        public override bool Equals( object v)
        {
            Vector vector = (Vector)v;
            if (v == null)
                return false;
           return X == vector.X && Y == vector.Y;
        }
        public override string ToString()
        {
            return "Vector:" + " X=" + X + ", Y=" + Y;
        }
        public override int GetHashCode()
        {
            return Tuple.Create(X, Y).GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Angle ang = new Angle( Math.PI);
            Console.WriteLine(ang.Add(Math.PI));

            Angle ang1 = new Angle(new Vector(2,2));
            if (ang1.A == Math.PI / 4)
                Console.WriteLine("fwe");
            Console.WriteLine(ang1.A);
            Console.WriteLine(Math.PI / 4);
            Console.ReadLine();
        }
    }
}