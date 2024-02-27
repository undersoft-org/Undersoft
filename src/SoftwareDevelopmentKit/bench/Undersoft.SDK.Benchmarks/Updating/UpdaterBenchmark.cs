namespace Undersoft.SDK.Benchmarks.Instant.Math
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Engines;
    using System.Linq;
    using Undersoft.SDK.Benchmarks.Updating.Models;
    using Undersoft.SDK.Instant;
    using Undersoft.SDK.Instant.Series;
    using Undersoft.SDK.Updating;

    [MemoryDiagnoser]
    [RankColumn]
    [RPlotExporter]
    [SimpleJob(RunStrategy.ColdStart, targetCount: 5)]
    public class UpdaterMathBenchmark
    {
        private InstantCreator figure;
        private InstantSeriesCreator factory;
        private IInstantSeries InstantSeries;
        private IInstantSeries InstantSeriesEmpty;

        public UpdaterMathBenchmark()
        {
            factory = new InstantSeriesCreator<User>(
                "InstantSeriesCreator_InstantSeriesMath_Test", InstantType.Reference, false
            );

            InstantSeries = factory.Create();
            InstantSeriesEmpty = factory.Create();

            User fom = new User();

            for (int i = 0; i < 1000 * 1000; i++)
            {
                IInstant f = InstantSeries.NewInstant();
                fom.PatchTo(f);
                InstantSeries.Add(i, f);
                InstantSeriesEmpty.Add(i, InstantSeriesEmpty.NewInstant());
            }
        }

        [Benchmark]
        public void Instant_Updater_Undersoft_SDK_Object_Delta_Patch_New()
        {
            InstantSeries.ForEach(m => m.PatchTo<User>()).Commit();
        }

        [Benchmark]
        public void Instant_Updater_Undersoft_SDK_Object_Full_Put_New()
        {
            InstantSeries.ForEach(m => m.PutTo<User>()).Commit();
        }

        [Benchmark]
        public void Instant_Updater_Undersoft_SDK_Object_Delta_Patch_By_Id()
        {
            InstantSeries.ForEach(m => m.PatchTo(InstantSeriesEmpty[m.Id])).Commit();
        }

        [Benchmark]
        public void Instant_Updater_Undersoft_SDK_Object_Full_Put_By_Id()
        {
            InstantSeries.ForEach(m => m.PutTo(InstantSeriesEmpty[m.Id])).Commit();
        }
    }
}
