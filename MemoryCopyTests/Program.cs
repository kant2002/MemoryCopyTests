using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryCopyTests
{
    //[ClrJob, CoreJob]
    public class FindSections
    {
        [ParamsSource(nameof(ValuesForA))]
        public string A { get; set; }

        // public property
        public IEnumerable<string> ValuesForA => new[]
        {
            "small non html string",
            "",
            @"<footer style='display: none;'>
        <div class='grad-bottom'></div>
        <div class='footer'>
          <div class='container'>
            <span class='pull-right'>
              <a href='#top'>Back to top</a>
            </span>
            Copyright © 2013–2019 .NET Foundation and contributors
            
          </div>
        </div>
      </footer>",
            @"<div class='sidetoc'>
      <div class='toc' id='toc'>
          
          <ul class='nav level1'>
                <li>
                    <a href='../overview.html' name='' title='Overview'>Overview</a>
                </li>
                <li>
                    <span class='expand-stub'></span>
                    <a>Guides</a>
                    
                    <ul class='nav level2'>
                          <li>
                              <a href='../guides/getting-started.html' name='' title='Getting Started'>Getting Started</a>
                          </li>
                          <li>
                              <a href='../guides/how-to-run.html' name='' title='How to run your benchmarks'>How to run your benchmarks</a>
                          </li>
                          <li>
                              <a href='../guides/good-practices.html' name='' title='Good Practices'>Good Practices</a>
                          </li>
                          <li>
                              <a href='../guides/nuget.html' name='' title='Installing NuGet packages'>Installing Nu<wbr>Get packages</a>
                          </li>
                          <li>
                              <a href='../guides/choosing-run-strategy.html' name='' title='Choosing RunStrategy'>Choosing Run<wbr>Strategy</a>
                          </li>
                          <li>
                              <a href='../guides/customizing-runtime.html' name='' title='Customizing runtime'>Customizing runtime</a>
                          </li>
                          <li>
                              <a href='../guides/how-it-works.html' name='' title='How it works'>How it works</a>
                          </li>
                          <li>
                              <a href='../guides/console-args.html' name='' title='Console Arguments'>Console Arguments</a>
                          </li>
                          <li>
                              <a href='../guides/troubleshooting.html' name='' title='Troubleshooting'>Troubleshooting</a>
                          </li>
                          <li>
                              <a href='../guides/global-dotnet-tool.html' name='' title='The global BenchmarkDotNet tool'>The global Benchmark<wbr>Dot<wbr>Net tool</a>
                          </li>
                    </ul>
                </li>
                <li>
                    <span class='expand-stub'></span>
                    <a>Features</a>
                    
                    <ul class='nav level2'>
                          <li>
                              <a href='../features/parameterization.html' name='' title='Parameterization'>Parameterization</a>
                          </li>
                          <li>
                              <a href='../features/baselines.html' name='' title='Baselines'>Baselines</a>
                          </li>
                          <li>
                              <a href='../features/setup-and-cleanup.html' name='' title='Setup And Cleanup'>Setup And Cleanup</a>
                          </li>
                          <li>
                              <a href='../features/statistics.html' name='' title='Statistics'>Statistics</a>
                          </li>
                          <li>
                              <a href='../features/disassembler.html' name='' title='Disassembler'>Disassembler</a>
                          </li>
                          <li>
                              <a href='../features/etwprofiler.html' name='' title='EtwProfiler'>Etw<wbr>Profiler</a>
                          </li>
                    </ul>
                </li>
                <li class='active in'>
                    <span class='expand-stub'></span>
                    <a class='active'>Configs</a>
                    
                    <ul class='nav level2'>
                          <li>
                              <a href='../configs/configs.html' name='' title='Configs'>Configs</a>
                          </li>
                          <li>
                              <a href='../configs/jobs.html' name='' title='Jobs'>Jobs</a>
                          </li>
                          <li>
                              <a href='../configs/columns.html' name='' title='Columns'>Columns</a>
                          </li>
                          <li>
                              <a href='../configs/exporters.html' name='' title='Exporters'>Exporters</a>
                          </li>
                          <li>
                              <a href='../configs/loggers.html' name='' title='Loggers'>Loggers</a>
                          </li>
                          <li>
                              <a href='../configs/diagnosers.html' name='' title='Diagnosers'>Diagnosers</a>
                          </li>
                          <li class='active in'>
                              <a href='../configs/toolchains.html' name='' title='Toolchains' class='active'>Toolchains</a>
                          </li>
                          <li>
                              <a href='../configs/analysers.html' name='' title='Analysers'>Analysers</a>
                          </li>
                          <li>
                              <a href='../configs/validators.html' name='' title='Validators'>Validators</a>
                          </li>
                          <li>
                              <a href='../configs/filters.html' name='' title='Filters'>Filters</a>
                          </li>
                          <li>
                              <a href='../configs/orderers.html' name='' title='Orderers'>Orderers</a>
                          </li>
                          <li>
                              <a href='../configs/encoding.html' name='' title='Encoding'>Encoding</a>
                          </li>
                    </ul>
                </li>
                <li>
                    <span class='expand-stub'></span>
                    <a>Samples</a>
                    
                    <ul class='nav level2'>
                          <li>
                              <a href='../samples/IntroBasic.html' name='' title='IntroBasic'>Intro<wbr>Basic</a>
                          </li>
                          <li>
                              <a href='../samples/IntroParams.html' name='' title='IntroParams'>Intro<wbr>Params</a>
                          </li>
                          <li>
                              <a href='../samples/IntroParamsSource.html' name='' title='IntroParamsSource'>Intro<wbr>Params<wbr>Source</a>
                          </li>
                          <li>
                              <a href='../samples/IntroArguments.html' name='' title='IntroArguments'>Intro<wbr>Arguments</a>
                          </li>
                          <li>
                              <a href='../samples/IntroArgumentsSource.html' name='' title='IntroArgumentsSource'>Intro<wbr>Arguments<wbr>Source</a>
                          </li>
                          <li>
                              <a href='../samples/IntroArrayParam.html' name='' title='IntroArrayParam'>Intro<wbr>Array<wbr>Param</a>
                          </li>
                          <li>
                              <a href='../samples/IntroParamsAllValues.html' name='' title='IntroParamsAllValues'>Intro<wbr>Params<wbr>All<wbr>Values</a>
                          </li>
                          <li>
                              <a href='../samples/IntroBenchmarkBaseline.html' name='' title='IntroBenchmarkBaseline'>Intro<wbr>Benchmark<wbr>Baseline</a>
                          </li>
                          <li>
                              <a href='../samples/IntroRatioSD.html' name='' title='IntroRatioSD'>Intro<wbr>Ratio<wbr>SD</a>
                          </li>
                          <li>
                              <a href='../samples/IntroCategoryBaseline.html' name='' title='IntroCategoryBaseline'>Intro<wbr>Category<wbr>Baseline</a>
                          </li>
                          <li>
                              <a href='../samples/IntroJobBaseline.html' name='' title='IntroJobBaseline'>Intro<wbr>Job<wbr>Baseline</a>
                          </li>
                          <li>
                              <a href='../samples/IntroEnvVars.html' name='' title='IntroEnvVars'>Intro<wbr>Env<wbr>Vars</a>
                          </li>
                          <li>
                              <a href='../samples/IntroStaThread.html' name='' title='IntroStaThread'>Intro<wbr>Sta<wbr>Thread</a>
                          </li>
                          <li>
                              <a href='../samples/IntroSetupCleanupGlobal.html' name='' title='IntroSetupCleanupGlobal'>Intro<wbr>Setup<wbr>Cleanup<wbr>Global</a>
                          </li>
                          <li>
                              <a href='../samples/IntroSetupCleanupIteration.html' name='' title='IntroSetupCleanupIteration'>Intro<wbr>Setup<wbr>Cleanup<wbr>Iteration</a>
                          </li>
                          <li>
                              <a href='../samples/IntroSetupCleanupTarget.html' name='' title='IntroSetupCleanupTarget'>Intro<wbr>Setup<wbr>Cleanup<wbr>Target</a>
                          </li>
                          <li>
                              <a href='../samples/IntroCustomMono.html' name='' title='IntroCustomMono'>Intro<wbr>Custom<wbr>Mono</a>
                          </li>
                          <li>
                              <a href='../samples/IntroCustomMonoArguments.html' name='' title='IntroCustomMonoArguments'>Intro<wbr>Custom<wbr>Mono<wbr>Arguments</a>
                          </li>
                          <li>
                              <a href='../samples/IntroCategories.html' name='' title='IntroCategories'>Intro<wbr>Categories</a>
                          </li>
                          <li>
                              <a href='../samples/IntroFilters.html' name='' title='IntroFilters'>Intro<wbr>Filters</a>
                          </li>
                          <li>
                              <a href='../samples/IntroJoin.html' name='' title='IntroJoin'>Intro<wbr>Join</a>
                          </li>
                          <li>
                              <a href='../samples/IntroStatisticsColumns.html' name='' title='IntroStatisticsColumns'>Intro<wbr>Statistics<wbr>Columns</a>
                          </li>
                          <li>
                              <a href='../samples/IntroPercentiles.html' name='' title='IntroPercentiles'>Intro<wbr>Percentiles</a>
                          </li>
                          <li>
                              <a href='../samples/IntroRankColumn.html' name='' title='IntroRankColumn'>Intro<wbr>Rank<wbr>Column</a>
                          </li>
                          <li>
                              <a href='../samples/IntroStatisticalTesting.html' name='' title='IntroStatisticalTesting'>Intro<wbr>Statistical<wbr>Testing</a>
                          </li>
                          <li>
                              <a href='../samples/IntroMultimodal.html' name='' title='IntroMultimodal'>Intro<wbr>Multimodal</a>
                          </li>
                          <li>
                              <a href='../samples/IntroOutliers.html' name='' title='IntroOutliers'>Intro<wbr>Outliers</a>
                          </li>
                          <li>
                              <a href='../samples/IntroHardwareCounters.html' name='' title='IntroHardwareCounters'>Intro<wbr>Hardware<wbr>Counters</a>
                          </li>
                          <li>
                              <a href='../samples/IntroDisassembly.html' name='' title='IntroDisassembly'>Intro<wbr>Disassembly</a>
                          </li>
                          <li>
                              <a href='../samples/IntroDisassemblyRyuJit.html' name='' title='IntroDisassemblyRyuJit'>Intro<wbr>Disassembly<wbr>Ryu<wbr>Jit</a>
                          </li>
                          <li>
                              <a href='../samples/IntroDisassemblyAllJits.html' name='' title='IntroDisassemblyAllJits'>Intro<wbr>Disassembly<wbr>All<wbr>Jits</a>
                          </li>
                          <li>
                              <a href='../samples/IntroDisassemblyDry.html' name='' title='IntroDisassemblyDry'>Intro<wbr>Disassembly<wbr>Dry</a>
                          </li>
                          <li>
                              <a href='../samples/IntroTailcall.html' name='' title='IntroTailcall'>Intro<wbr>Tailcall</a>
                          </li>
                          <li>
                              <a href='../samples/IntroColdStart.html' name='' title='IntroColdStart'>Intro<wbr>Cold<wbr>Start</a>
                          </li>
                          <li>
                              <a href='../samples/IntroMonitoring.html' name='' title='IntroMonitoring'>Intro<wbr>Monitoring</a>
                          </li>
                          <li>
                              <a href='../samples/IntroExport.html' name='' title='IntroExport'>Intro<wbr>Export</a>
                          </li>
                          <li>
                              <a href='../samples/IntroExportJson.html' name='' title='IntroExportJson'>Intro<wbr>Export<wbr>Json</a>
                          </li>
                          <li>
                              <a href='../samples/IntroExportXml.html' name='' title='IntroExportXml'>Intro<wbr>Export<wbr>Xml</a>
                          </li>
                          <li>
                              <a href='../samples/IntroTagColumn.html' name='' title='IntroTagColumn'>Intro<wbr>Tag<wbr>Column</a>
                          </li>
                          <li>
                              <a href='../samples/IntroConfigSource.html' name='' title='IntroConfigSource'>Intro<wbr>Config<wbr>Source</a>
                          </li>
                          <li>
                              <a href='../samples/IntroConfigUnion.html' name='' title='IntroConfigUnion'>Intro<wbr>Config<wbr>Union</a>
                          </li>
                          <li>
                              <a href='../samples/IntroFluentConfigBuilder.html' name='' title='IntroFluentConfigBuilder'>Intro<wbr>Fluent<wbr>Config<wbr>Builder</a>
                          </li>
                          <li>
                              <a href='../samples/IntroInProcess.html' name='' title='IntroInProcess'>Intro<wbr>In<wbr>Process</a>
                          </li>
                          <li>
                              <a href='../samples/IntroInProcessWrongEnv.html' name='' title='IntroInProcessWrongEnv'>Intro<wbr>In<wbr>Process<wbr>Wrong<wbr>Env</a>
                          </li>
                          <li>
                              <a href='../samples/IntroOrderAttr.html' name='' title='IntroOrderAttr'>Intro<wbr>Order<wbr>Attr</a>
                          </li>
                          <li>
                              <a href='../samples/IntroOrderManual.html' name='' title='IntroOrderManual'>Intro<wbr>Order<wbr>Manual</a>
                          </li>
                          <li>
                              <a href='../samples/IntroGenericTypeArguments.html' name='' title='IntroGenericTypeArguments'>Intro<wbr>Generic<wbr>Type<wbr>Arguments</a>
                          </li>
                          <li>
                              <a href='../samples/IntroDeferredExecution.html' name='' title='IntroDeferredExecution'>Intro<wbr>Deferred<wbr>Execution</a>
                          </li>
                          <li>
                              <a href='../samples/IntroNuGet.html' name='' title='IntroNuGet'>Intro<wbr>Nu<wbr>Get</a>
                          </li>
                          <li>
                              <a href='../samples/IntroStopOnFirstError.html' name='' title='IntroStopOnFirstError'>Intro<wbr>Stop<wbr>On<wbr>First<wbr>Error</a>
                          </li>
                    </ul>
                </li>
                <li>
                    <span class='expand-stub'></span>
                    <a>Contributing</a>
                    
                    <ul class='nav level2'>
                          <li>
                              <a href='../contributing/building.html' name='' title='Building'>Building</a>
                          </li>
                          <li>
                              <a href='../contributing/debugging.html' name='' title='Debugging'>Debugging</a>
                          </li>
                          <li>
                              <a href='../contributing/running-tests.html' name='' title='Running tests'>Running tests</a>
                          </li>
                          <li>
                              <a href='../contributing/development.html' name='' title='Development'>Development</a>
                          </li>
                          <li>
                              <a href='../contributing/miscellaneous.html' name='' title='Miscellaneous topics'>Miscellaneous topics</a>
                          </li>
                          <li>
                              <a href='../contributing/disassembler.html' name='' title='Disassembler'>Disassembler</a>
                          </li>
                          <li>
                              <a href='../contributing/documentation.html' name='' title='Documentation'>Documentation</a>
                          </li>
                    </ul>
                </li>
                <li>
                    <a href='../faq.html' name='' title='FAQ'>FAQ</a>
                </li>
                <li>
                    <a href='../team.html' name='' title='Team'>Team</a>
                </li>
                <li>
                    <a href='../license.html' name='' title='Licence'>Licence</a>
                </li>
          </ul>
      </div>
    </div>"
        };

        [Benchmark]
        public string CharArray() => HtmlToPlain.CharArray(this.A);

        [Benchmark]
        public string CharArrayPointer() => HtmlToPlain.CharArrayPointer(this.A);

        [Benchmark]
        public string CharArrayPointerBuffer() => HtmlToPlain.CharArrayPointerBuffer(this.A);

        [Benchmark]
        public string CharArrayPointerBufferWithStackAllock() => HtmlToPlain.CharArrayPointerBufferWithStackAllock(this.A);

        [Benchmark]
        public string CharArrayStringIndexOf() => HtmlToPlain.CharArrayStringIndexOf(this.A);

        [Benchmark]
        public string StringBuilder() => HtmlToPlain.StringBuilder(this.A);

        [Benchmark]
        public string StringBuilderRemoveStringIndexOf() => HtmlToPlain.StringBuilderRemoveStringIndexOf(this.A);

        [Benchmark]
        public string StringBuilderStringIndexOf() => HtmlToPlain.StringBuilderStringIndexOf(this.A);

        [Benchmark]
        public string StringJoinStringIndexOf() => HtmlToPlain.StringJoinStringIndexOf(this.A);

    class Program
    {
        public static void Main(string[] args)
            => BenchmarkSwitcher
                .FromAssembly(typeof(Program).Assembly)
                .Run(args);
    }
}
