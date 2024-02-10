using BenchmarkDotNet.Running;
using Undersoft.SDK.Benchmarks.Instant.Math;
using Undersoft.SDK.Benchmarks.Series;

namespace Undersoft.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<InstantMathBenchmark>();

            var regBench = new RegistryBenchmark();
            regBench.Dictionary_Add_Test();

            BenchmarkRunner.Run<RegistryBenchmark>();
        }
    }
}
