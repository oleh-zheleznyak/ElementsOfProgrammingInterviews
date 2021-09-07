using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Chapter12_Searching
{
    /// <summary>
    /// 12.4 Compute the integer square root
    /// </summary>
    public class IntegerSquareRoot
    {
        public int Sqrt(int value)
        {
            if (value < 0) throw new ArgumentException("negative values not supported"); // TODO: use unsigned integer?
            if (value == 0) return 0;
            if (value == 1) return 1;

            var hi = value / 2;
            var lo = 1;
            var mid = lo + (hi - lo) / 2;
            while (lo <= hi)
            {
                mid = lo + (hi - lo) / 2;
                var sq = mid * mid;
                if (sq == value) return mid;
                else if (sq > value) hi = mid - 1;
                else lo = mid + 1;
            }
            return lo * lo < value ? lo : hi;
        }
    }
}
