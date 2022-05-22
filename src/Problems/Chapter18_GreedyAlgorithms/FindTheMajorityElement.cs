using System;

namespace Problems.Chapter18_GreedyAlgorithms;

public class FindTheMajorityElement
{
    public string FindInArray(string[] array)
    {
        if (array is null) throw new ArgumentNullException(nameof(array));
        if (array.Length == 0) throw new ArgumentException("Array is empty", nameof(array));
        if (array.Length == 1) return array[0];

        // option 1 - dictionary, O(n) time, O(n) space
        // more than half are - majority
        // option 2 - sort, loop, count (more than half) - O(nlgn) time, O(1) space if sort is in-place
        Array.Sort(array);
        var counter = 1;
        var prev = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            var current = array[i];
            if (current == prev) counter++;
            else counter = 0;
            
            if (counter * 2 > array.Length) return current;
            prev = current;
        }
        return null; // perhaps throw - pre-condition is broken
    }
}
