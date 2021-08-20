using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.Chapter05_PrimitiveTypes
{
    /// <summary>
    /// 5.7 Compute x to power of y
    /// </summary>
    /// <remarks>
    /// Regarding naming, it's best to put this in a Math class, Pow method, to use via static helper like Math.Pow
    /// </remarks>
    public class Power
    {
        public double Compute(double x, int y)
        {
            // TODO: Input sanitization: NaN, Infinities
            if (x < 0 && y < 0) throw new ArgumentException($"Invalid argument combination, both {nameof(x)} and {nameof(y)} are negative");
            if (y == 0) return 1;
            if (y<0)
            {
                y = - y;
                x = 1.0D / x;
            }
            var power = y;
            var result = 1D;

            while (power > 0)
            {
                if ((power & 1) == 1)
                {
                    result *= x;
                }
                x *= x;
                power >>= 1;
            }

            return result; 
        }
    }
}
