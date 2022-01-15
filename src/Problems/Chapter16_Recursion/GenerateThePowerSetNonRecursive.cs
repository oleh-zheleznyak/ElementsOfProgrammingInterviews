using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Chapter16_Recursion
{
    /// <summary>
    /// 16.4 Generate the power set
    /// </summary>
    public class GenerateThePowerSetNonRecursive<T>
    {
        public IReadOnlyCollection<T[]> PowerSetOf(ISet<T> set)
        {
            if (set is null) throw new ArgumentNullException(nameof(set));

            var setSize = set.Count;
            var powerSetSize = Math.Pow(2, setSize);
            if (powerSetSize > int.MaxValue) throw new ArgumentException("Set too large, cannot compute more than int.MaxValue permutations");

            var result = PowerSetOf(set.ToArray(), (int)powerSetSize);

            return result;
        }

        private IReadOnlyCollection<T[]> PowerSetOf(T[] set, int powerSetSize)
        {
            var result = new List<T[]>(powerSetSize);

            var current = new List<T>();
            for (int i = 0; i < powerSetSize; i++)
            {
                var bits = i;
                while (bits > 0)
                {
                    // isolate the lowest bit
                    var lowestBit = bits & ~(bits - 1);
                    var index = (int)Math.Log2(lowestBit);
                    var element = set[index];
                    current.Add(element);

                    // drop the lowest bit
                    bits &= bits - 1; 
                }
                result.Add(current.ToArray());
                current.Clear();
            }

            return result;
        }
    }
}
