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
            // brute force - 3 nested loops
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    for (int k = 0; k < array.Length; k++)
                    {
                        if (array[i]+array[j]+array[k]==sum) return (array[i] , array[j] , array[k]);
                    }
                }
            }
            return null;
        } 
    }
}
