using BenchmarkDotNet.Attributes;
using Problems.Chapter16_Recursion;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Benchmarks
{
    public class GeneratePermutationsBenchmark
    {
        private GeneratePermutationsViaAllocatedPositions<char> generatePermutationsViaAllocatedPositions = new();
        private GeneratePermutationsViaSetReduction<char> generatePermutationsViaSetReduction = new();

        private char[] data;

        [GlobalSetup]
        public void Setup()
        {
            const int countOfLetters = 25;
            data = Enumerable.Range(0, 10).Select(i => (char)('a' + i)).ToArray();
        }

        [Params(1000,5000)]
        public int N;

        [Benchmark]
        public IReadOnlyCollection<char[]> PermutationsViaAllocatedPositions() => generatePermutationsViaAllocatedPositions.AllPermutationsOf(data).ToList();

        [Benchmark]
        public IReadOnlyCollection<char[]> PermutationsViaSetReduction() => generatePermutationsViaSetReduction.AllPermutationsOf(data).ToList();
    }
}
