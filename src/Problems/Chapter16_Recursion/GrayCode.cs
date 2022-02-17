using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Chapter16_Recursion
{

    public class GrayCode
    {
        private static int[] zero = new int[] { 0 };
        private const int IntBitness = 32;

        // TODO: perm is 0...2^n-1, byte.MaxValue = 255, int.MaxValue = 2^32-1 - potential overflow
        // repl int with long, does not help, need to use BigNumber of limit numberOfBits 
        public int[]? Compute(byte numberOfBits)
        {
            if (numberOfBits == 0) return zero;
            if (numberOfBits > IntBitness) throw new ArgumentOutOfRangeException($"{nameof(numberOfBits)} cannot be bigger than {IntBitness}");

            // Brute force
            // Compute every permutation
            // Check that it meets the condition
            var results = new List<int[]>();
            var size = (int)Math.Pow(2, numberOfBits);
            var permutation = new int[size];
            var initial = Enumerable.Range(0, size - 1).ToArray();

            ComputePermutations(initial, 0, permutation, results);

            // TODO: refine		
            return results.FirstOrDefault();
        }

        private void ComputePermutations(int[] initial, int index, int[] permutation, ICollection<int[]> results)
        {
            if (index == initial.Length)
            {
                if (IsAGrayCodeAtIndex(permutation, index))
                    results.Add(permutation.ToArray()); // copy
                return;
            }

            for (var i = index; i < initial.Length; i++)
            {
                permutation.Swap(i, index);
                if (IsAGrayCodeAtIndex(permutation, index))
                    ComputePermutations(initial, index + 1, permutation, results);
                permutation.Swap(i, index);
            }
        }

        private bool IsAGrayCodeAtIndex(int[] permutation, int index)
        {
            // TODO: we only need to check the last value incrementally
            if (index == 0) return true;
            if (index == permutation.Length) return BinaryDiffersInOnePosition(permutation[0], permutation[index - 1]);
            return BinaryDiffersInOnePosition(permutation[index], permutation[index - 1]);
        }

        private bool BinaryDiffersInOnePosition(int first, int second)
        {
            // isolate lowest bit for both
            // if differs increase counter
            // if counter > 1 return false
            // loop

            var bitmask = 1;
            var counter = 0;

            while (first > 0 && second > 0)
            {
                var firstLowest = first & bitmask;
                var secondLowest = first & bitmask;
                if (firstLowest != secondLowest) counter++;
                if (counter > 1) return false;
                first = first >> 1;
                second = second >> 1;
            }

            return counter == 1;
        }

    }
}
