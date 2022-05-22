using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Chapter18_GreedyAlgorithms
{
    public class The3SumProblem
    {
        public (int,int,int)? FindThreeEntriesThatSumUpTo(int sum, int[] array)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
            if (array.Length == 0) return null;

            var sorted = array.OrderBy(x => x).ToArray();
            return FindThreeEntitiesThatSumUpToSorted(sum, sorted);
        }

        private static (int, int, int)? FindThreeEntitiesThatSumUpToSorted(int sum, int[] array)
        {
            for (int k = 0; k < array.Length; k++)
            {
                var remainder = sum - array[k];
                var i = 0;
                var j = array.Length - 1;
                while (i <= j)
                {
                    var total = array[i] + array[j];
                    if (total == remainder) return (array[k], array[i], array[j]);
                    else if (total < remainder) i++;
                    else j--;
                }
            }
            return null;
        }
    }
}
