﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

#if BENCHMARK

using BenchmarkDotNet.Analysers;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;

#endif

using Microsoft.Extensions.CommandLineUtils;

namespace PSRule.Benchmark
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var app = new CommandLineApplication
            {
                Name = "PSRule Benchmark",
                Description = "A runner for testing PSRule performance"
            };

#if !BENCHMARK
            // Do profiling
            DebugProfile();
#endif

#if BENCHMARK
            RunProfile(app);
            app.Execute(args);
#endif
        }

#if BENCHMARK

        private static void RunProfile(CommandLineApplication app)
        {
            var config = ManualConfig.CreateEmpty()
                .With(ConsoleLogger.Default)
                .With(DefaultColumnProviders.Instance)
                .With(EnvironmentAnalyser.Default)
                .With(OutliersAnalyser.Default)
                .With(MinIterationTimeAnalyser.Default)
                .With(MultimodalDistributionAnalyzer.Default)
                .With(RuntimeErrorAnalyser.Default)
                .With(ZeroMeasurementAnalyser.Default);

            app.Command("benchmark", cmd =>
            {
                var output = cmd.Option("-o | --output", "The path to store report output.", CommandOptionType.SingleValue);
                cmd.OnExecute(() =>
                {
                    if (output.HasValue())
                    {
                        config.WithArtifactsPath(output.Value());
                    }

                    // Do benchmarks
                    BenchmarkRunner.Run<PSRule>(config);
                    return 0;
                });
                cmd.HelpOption("-? | -h | --help");
            });
            app.HelpOption("-? | -h | --help");
        }

#endif

        private static void DebugProfile()
        {
            var profile = new PSRule();
            profile.Prepare();

            for (var i = 0; i < 100; i++)
                profile.Invoke();

            for (var i = 0; i < 100; i++)
                profile.InvokeIf();

            for (var i = 0; i < 100; i++)
                profile.InvokeType();

            for (var i = 0; i < 100; i++)
                profile.InvokeSummary();

            for (var i = 0; i < 100; i++)
                profile.Get();

            for (var i = 0; i < 100; i++)
                profile.DefaultTargetNameBinding();

            for (var i = 0; i < 100; i++)
                profile.CustomTargetNameBinding();

            for (var i = 0; i < 100; i++)
                profile.NestedTargetNameBinding();
        }
    }
}
