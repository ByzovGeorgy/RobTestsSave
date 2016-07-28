using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAplication117;

namespace ConsoleApplication117
{
    public class Angle
    {
        public double A { get; private set; }
        public Angle(double a)
        {
            A = Radians(a);
        }
        public double Add(double a)
        {
            return Radians(A + a);
        }
        public double Subtract(double a)
        {
            return Radians(A - a);
        }                          
        public double Radians(double a)
        {
            while (a > Math.PI)
                a -= 2 * Math.PI;
            while (a <= -Math.PI)
                a += 2 * Math.PI;
            if (a <1e-4 && a>-1e-4 ) return 0;
            return a;
        }
        
        public Angle(Vector v)
        {
            if( Math.Asin(v.Y / (Math.Sqrt(v.X * v.X + v.Y * v.Y)))<0)
                A =  -Math.Acos(v.X / (Math.Sqrt(v.X * v.X + v.Y * v.Y)));
            else
                A = Math.Acos(v.X / (Math.Sqrt(v.X * v.X + v.Y * v.Y)));
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            return A == (double)obj;
        }
        public override string ToString()
        {
            return "Angle is " + A + " radians";
        }
        public override int GetHashCode()
        {
            return Tuple.Create(A).GetHashCode();
        }
    }
}
