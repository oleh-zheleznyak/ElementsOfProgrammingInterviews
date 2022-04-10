namespace Chapter17_DynamicProgramming;
using System;
using System.Linq;

public class LevensteinDistanceByTheBook : ILevensteinDistance
{
    public int ComputeDistance(string a, string b)
    {
        if (a is null) throw new ArgumentNullException(nameof(a));
        if (b is null) throw new ArgumentNullException(nameof(b));

        var cache = new int?[a.Length, b.Length];

        return ComputeDistance(a, a.Length - 1, b, b.Length - 1, cache);
    }

    private int ComputeDistance(string a, int indexA, string b, int indexB, int?[,] cache)
    {
        if (indexA < 0) return indexB + 1;
        else if (indexB < 0) return indexA + 1;

        if (cache[indexA, indexB].HasValue) return cache[indexA, indexB].Value;

        if (a[indexA] == b[indexB]) return ComputeDistance(a, indexA - 1, b, indexB - 1, cache);

        var edit = ComputeDistance(a, indexA - 1, b, indexB - 1, cache);
        var add = ComputeDistance(a, indexA, b, indexB - 1, cache);
        var delete = ComputeDistance(a, indexA - 1, b, indexB, cache);

        var distance = 1 + new int[] { edit, add, delete }.Min();
        cache[indexA, indexB] = distance;

        return distance;
    }
}