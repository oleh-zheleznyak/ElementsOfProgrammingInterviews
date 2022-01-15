using BenchmarkDotNet.Attributes;
using Problems.Chapter16_Recursion;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Benchmarks
{
    public class GeneratePowerSetBenchmark
    {
        private GenerateThePowerSet<char> generateThePowerSet = new();
        private GenerateThePowerSetNonRecursive<char> generateThePowerSetNonRecursive = new();

        private ISet<char> data;

        [GlobalSetup]
        public void Setup()
        {
            data = Enumerable.Range(0, 10).Select(i => (char)('a' + i)).ToHashSet();
        }

        [Params(1000)]
        public int N;

        [Benchmark]
        public IReadOnlyCollection<ISet<char>> GeneratePowerSet() => generateThePowerSet.PowerSetOf(data);

        [Benchmark]
        public IReadOnlyCollection<char[]> GeneratePowerSetNonRecursive() => generateThePowerSetNonRecursive.PowerSetOf(data);
    }
}
