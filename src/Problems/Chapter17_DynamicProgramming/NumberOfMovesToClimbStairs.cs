namespace Problems.Chapter17_DynamicProgramming;
using System;

public class WaysToClimbStairs
{
    public uint NumberOfWaysToGetToFloor(uint floor, uint maxSteps)
    {
        if (floor == 0 || maxSteps == 0) return 0;  // throw new ArgumentException();

        var cache = new uint?[floor + 1, maxSteps + 1];
        var result = NumberOfWays(floor, maxSteps, cache);
        return result;
    }

    private int NumberOfWays(uint floor, uint maxSteps, uint?[] cache)
    {
        if (floor <= 0) return 0;
        if (floor == 1) return 1;
        var cacheEntry = cache[floor, maxSteps];
        if (cacheEntry.HasValue) return cacheEntry.Value;

        uint sum = 0;
        for (var i = 1; i <= maxSteps; i++)
        {
            var usingIsteps = floor >= i ? NumberOfWays((uint)(floor - i), i, cache) : 0; // double billing
            sum += usingIsteps; // possible overflow
        }
        cache[floor, maxSteps] = sum;
        return sum;
    }

}
