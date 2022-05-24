using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Chapter18_GreedyAlgorithms
{
    public class MaxWaterTrappedByVerticalLines
    {
        public (int,int) FindPairThatTrapsMaxWater(int[] array)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
            if (array.Length<2) throw new ArgumentException("not enough elements", nameof(array));

            // brute force - nested for loops, take every pair, compute volume - O(n^2) time, O(1) space
            // sort - no O(nlgn)
            // O(n)

            var max = int.MinValue;
            var pair = (max, max);
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i+1; j < array.Length; j++)
                {
                    var width = j - i;
                    var height = Math.Min(array[i], array[j]);
                    var volume = width * height;
                    if (volume>max)
                    {
                        max = volume;
                        pair = (i,j);
                    }
                }
            }
            return pair;
        }
    }
}
