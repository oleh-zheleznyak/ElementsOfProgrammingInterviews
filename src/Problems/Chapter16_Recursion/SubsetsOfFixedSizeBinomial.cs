using System.Collections.Generic;
using System.Linq;

namespace Problems.Chapter16_Recursion
{
    public class SubsetsOfFixedSizeBinomial<T>
    {
        public IReadOnlyCollection<T[]> AllSubsetsOfSize(ISet<T> set, int subSetsize)
        {
            var result = new List<T[]>();
            AllSubsetsOfSize(set.ToArray(), subSetsize, 0, new List<T>(), result);
            return result;
        }

        private void AllSubsetsOfSize(T[] set, int subSetsize, int offset, List<T> partialCombination,
            ICollection<T[]> results)
        {
            if (partialCombination.Count == subSetsize)
            {
                results.Add(partialCombination.ToArray());
                return;
            }

            var numRemaining = subSetsize - partialCombination.Count;
            //for (var i = offset; i <= setSize && i <= setSize - numRemaining + 1; i++) 
            for (var i = offset; i < set.Length; i++)
            {
                partialCombination.Add(set[i]);
                AllSubsetsOfSize(set, subSetsize, i + 1, partialCombination, results);
                partialCombination.RemoveAt(partialCombination.Count - 1);
            }
        }
    }
}