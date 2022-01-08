using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Problems.Chapter16_Recursion;
using System;
using System.Collections.Generic;

namespace Problems.Benchmarks
{
    public class GenerateThePowerSetBenchmark
    {
        private GenerateThePowerSet<byte> generateThePowerSet = new();
        private GenerateThePowerSetArrayCopy<byte> generateThePowerSetArrayCopy = new();
        private ISet<byte> data;

        [GlobalSetup]
        public void Setup()
        {
            var random = new Random();
            var bytes = new byte[16];
            random.NextBytes(bytes);
            data = new HashSet<byte>(bytes);
        }

        [Params(1000)]
        public int N;

        [Benchmark]
        public IReadOnlyCollection<ISet<byte>> PowerSetUsingArrayCopy() => generateThePowerSetArrayCopy.PowerSetOf(data);

        [Benchmark]
        public IReadOnlyCollection<ISet<byte>> PowerSet() => generateThePowerSet.PowerSetOf(data);
    }
}
