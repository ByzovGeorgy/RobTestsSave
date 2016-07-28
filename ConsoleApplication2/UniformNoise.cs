using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class UniformNoise:INoise
    {
        public double W { get; set; }
        public UniformNoise(double w)
        {
            W = w;
        }      
        public double NoiseVelocity(double velocity)
        {           
            Random r = new Random();            
            return  Math.Round((r.NextDouble() * 2 - 1) * W,3)*velocity;            
        }
    }
}
