using BenchmarkDotNet.Running;

namespace Problems.Benchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
            var summary = BenchmarkRunner.Run<GeneratePowerSetBenchmark>();

            // uncomment this to run VS Profiler session
            // RunManualJobForProfilingSession();
        }

        private static void RunManualJobForProfilingSession()
        {
            var manualBenchmark = new GeneratePermutationsBenchmark();
            manualBenchmark.Setup();
            manualBenchmark.PermutationsViaSetReduction();
        }
    }
}
