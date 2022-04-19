namespace Chapter17_DynamicProgramming;
using System;

// TODO: consider OO design
public class BinomialCoefficient
{
    public uint Compute(byte n, byte k)
    {
        if (k > n) throw new ArgumentException("k > n"); // nameof
        if (n == 0) return 0;

        var cache = new uint?[n + 1, k + 1];
        var result = Compute(n, k, cache);
        return result;
    }

    private uint Compute(byte n, byte k, uint?[,] cache)
    {
        if (k == 1) return n;
        if (k > n) return 0;
        if (k == n) return 1;
        if (cache[n, k].HasValue) return cache[n, k].Value;

        var result = Compute((byte)(n - 1), k) + Compute((byte)(n - 1), (byte)(k - 1));
        cache[n, k] = result;
        return result;
    }
}
