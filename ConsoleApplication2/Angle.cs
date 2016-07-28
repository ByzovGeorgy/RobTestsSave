using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class Angle
    {
        public double A { get; private set; }
        public Angle(double a)
        {
            A = (double)Radians(a);
        }
        public Angle Add(double a)
        {
            return new Angle(Radians(A + a));
        }
        public Angle Subtract(double a)
        {
            return new Angle(Radians(A - a));
        }
        public double Radians(double a)
        {
            int c = (int)(a / (2* Math.PI));
            a -= c *2* Math.PI;
            if (a > Math.PI) a -= 2 * Math.PI;
            if ((a <= -Math.PI) && (a > -2 * Math.PI))
                a += 2*Math.PI;
            return a;
        }

        public Angle(Vector v)
        {
            double len = Math.Sqrt(v.X * v.X + v.Y * v.Y);
            if (Math.Asin(v.Y / len) < 0)
                A = (double)-Math.Acos(v.X / len);
            else
                A = (double)Math.Acos(v.X / len);
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Angle))
                return false;
            Angle a = (Angle)obj;
            return A == a.A;
        }
        public override string ToString()
        {
            return "Angle is " + A + " radians";
        }
        public override int GetHashCode()
        {
            return A.GetHashCode();
        }
    }
}
