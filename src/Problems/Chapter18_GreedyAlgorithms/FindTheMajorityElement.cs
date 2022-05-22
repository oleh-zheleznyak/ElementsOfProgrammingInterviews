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
        // option 2 - sort, loop, count (more than half) - O(nlgn) time, O(1) space if sort is in-place
        // option 3 - as given in the book - O(n) time and O(1) space
        var counter = 1;
        var candidate = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            var current = array[i];
            if (current == candidate) counter++;
            else counter--;

            if (counter == 0)
            {
                candidate = current;
                counter = 1;
            }
        }
        return candidate;
    }
}
