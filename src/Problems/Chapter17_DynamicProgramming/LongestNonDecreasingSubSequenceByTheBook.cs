namespace Problems.Chapter17_DynamicProgramming;

using System;

public class LongestNonDecreasingSubSequenceByTheBook : ILongestNonDecreasingSubSequence
{
    public int Length(int[] array)
    {
        if (array is null) throw new ArgumentNullException(nameof(array));
        if (array.Length == 0) return 0;

        var cache = new int[array.Length];
        var result = Length(array, cache);
        return result;
    }

    private int Length(int[] array, int[] cache)
    {
        // L[i] = 1 + max{ L[j]: j<i && A[j]<=A[i]}, or 1 otherwise
        for (var i=0; i<array.Length; i++)
        {
            var max = 0;
            for (var j=0; j<i; j++)
            {
                if (array[j]<=array[i])
                    max = Math.Max(max, cache[j]);
            }
            cache[i] = 1 + max;
        }
        return cache[cache.Length-1];
    }
}