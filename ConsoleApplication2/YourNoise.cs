using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class YourNoise:INoise
    {
        public double W { get; set; }
        public YourNoise(double w)
        {
            W = w;
        }            
        public double NoiseVelocity(double velocity)
        {
            Random r = new Random();            
            return  r.NextDouble() * W*velocity;            
        }
    }
}
