namespace Problems.Chapter17_DynamicProgramming;

using System;

public class LongestNonDecreasingSubSequence
{
    public int Length(int[] array)
    {
        if (array is null) throw new ArgumentNullException(nameof(array));
        if (array.Length == 0) return 0;

        // brute force -try every combination - stop once non-decreasing
        // can we cache anything?
        // note : cannot use loop over 2^n since array.Length is int - and we need 2^int combinations - too much
        var result = Length(array, 0, array[0], 0);
        return result;
    }

    private int Length(int[] array, int offset, int prevValue, int length)
    {
        if (offset == array.Length) return length;

        var currValue = array[offset];

        var withoutThisValue = Length(array, offset + 1, prevValue, length);
        var withThisValue = prevValue > currValue ?
           Length(array, offset + 1, currValue, 1) : Length(array, offset + 1, currValue, length + 1);
        
        var maxLength = Math.Max(withoutThisValue, withThisValue);
        return maxLength;
    }
}