namespace Chapter17_DynamicProgramming;
using System;

public record struct Clock(int Value, int Weight);

public class Knapsack
{
    public int MaxValueWithinWeight(Clock[] clocks, int maxWeight)
    {
        if (clocks is null) throw new ArgumentNullException(nameof(clocks));
        if (clocks.Length ==0) return 0;
        // w >0
        // c.Len >0
        var cache = new int?[clocks.Length, maxWeight]; // Could be large!!
        var value = MaxValue(clocks, maxWeight, clocks.Length - 1, 0, cache); // TODO refactor - less args
        return value;
    }

    public int MaxValue(Clock[] clocks, int maxWeight, int offset, int value, int?[,] cache)
    {
        if (offset < 0) return value;
        if (maxWeight <= 0) return value;
        var item = cache[offset, maxWeight];
        if (item.HasValue) return item.Value;

        var valueWithoutClock = MaxValue(clocks, maxWeight, offset - 1, value, cache);
        var clock = clocks[offset];
        var valueWithClock =
            clock.Weight > maxWeight ?
            0 :
            MaxValue(clocks, maxWeight - clock.Weight, offset - 1, value + clock.Value, cache);

        var max = Math.Max(valueWithClock, valueWithoutClock);

        cache[offset, maxWeight] = max;
        return max;
    }
}