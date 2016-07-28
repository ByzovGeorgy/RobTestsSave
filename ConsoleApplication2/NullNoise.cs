using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class NullNoise:INoise
    {
        public NullNoise() { }

        public double NoiseVelocity(double velocity)
        {
            return 0;
        }
    }
}
