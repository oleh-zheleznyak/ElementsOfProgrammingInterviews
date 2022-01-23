using System.Collections.Generic;

namespace Problems.Chapter16_Recursion
{
    public class SubsetsOfFixedSize
    {
        public IReadOnlyCollection<int[]> AllSubsetsOfSize(int setSize, int subSetsize)
        {
            var result = new List<int[]>();
            AllSubsetsOfSize(setSize, subSetsize, 1, new List<int>(), result);
            return result;
        }

        private void AllSubsetsOfSize(int setSize, int subSetsize, int offset, List<int> partialCombination,
            ICollection<int[]> results)
        {
            if (partialCombination.Count == subSetsize)
            {
                results.Add(partialCombination.ToArray());
                return;
            }

            var numRemaining = subSetsize - partialCombination.Count;
            //for (var i = offset; i <= setSize && i <= setSize - numRemaining + 1; i++) 
            for (var i = offset; i <= setSize; i++)
            {
                partialCombination.Add(i);
                AllSubsetsOfSize(setSize, subSetsize, i + 1, partialCombination, results);
                partialCombination.RemoveAt(partialCombination.Count - 1);
            }
        }
    }
}