namespace Chapter17_DynamicProgramming;
using System;
using System.Linq;

public class LevensteinDistance
{
    public int ComputeDistance(string first, string second)
    {
        EnsureArgumentsNotNull(first, second);

        if (first == second) return 0;
        if (first.Length == 0) return second.Length;
        if (second.Length == 0) return first.Length;

        var (firstSuffix, secondSuffix) = RemoveEqualChars(first, second);
        if (firstSuffix.Length == 0) return secondSuffix.Length;
        if (secondSuffix.Length == 0) return firstSuffix.Length;

        var editDistance = 1 + ComputeDistance(firstSuffix.Remove(0, 1), secondSuffix.Remove(0,1));
        var deleteDistance = 1 + ComputeDistance(firstSuffix.Remove(0, 1), secondSuffix);
        var addDistance = 1 + ComputeDistance(firstSuffix, secondSuffix.Remove(0, 1));

        return new int[] { editDistance, deleteDistance, addDistance }.Min();
    }

    private void EnsureArgumentsNotNull(string first, string second)
    {
        if (first is null) throw new ArgumentNullException(nameof(first));
        if (second is null) throw new ArgumentNullException(nameof(second));
    }

    private (string first, string second) RemoveEqualChars(string first, string second)
    {
        var index = 0;
        while (index < first.Length && index<second.Length && first[index] == second[index]) index++;
        if (index > 0)
        {
            first = first.Remove(0, index);
            second = second.Remove(0, index);
        }
        return (first, second);
    }
}