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

            return FindMax(array);
        }

        private (int, int) FindMax(int[] array)
        {
            var max = int.MinValue;
            var pair = (max, max);
            int start = 0, end = array.Length-1;
            while (start<end)
            {
                var volume = ComputeVolume(array, end, start);
                if (volume > max)
                {
                    max = volume;
                    pair = (start, end);
                }

                if (array[start] > array[end]) end--;
                else start++;
            }
            return pair;
        }

        private static int ComputeVolume(int[] array, int end, int start)
        {
            var width = end - start;
            var height = Math.Min(array[start], array[end]);
            var volume = width * height;
            return volume;
        }
    }
}
