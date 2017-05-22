using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Text;

namespace StringInterpolationPerformanceB
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<StringFormatVsStringInterpolation>();
            
            summary = BenchmarkRunner.Run<StringConcatVsStringInterpolation>();
            
            summary = BenchmarkRunner.Run<StringBuilderVsStringInterpolation>();
        }
    }

    public class StringFormatVsStringInterpolation
    {
        private string data1;
        private string data2;
        private string data3;

        public StringFormatVsStringInterpolation()
        {
            data1 = Guid.NewGuid().ToString();
            data2 = Guid.NewGuid().ToString();
            data3 = Guid.NewGuid().ToString();
        }

        [Benchmark]
        public string StringFormat() => string.Format("test format{0}, {1}, {2}", data1, data2, data3); 

        [Benchmark]
        public string StringInterpolation() => ($"test format{data1}, {data2}, {data3}");

    }

    public class StringConcatVsStringInterpolation
    {
        private string data1;
        private string data2;
        private string data3;
        
        public StringConcatVsStringInterpolation()
        {
            data1 = Guid.NewGuid().ToString();
            data2 = Guid.NewGuid().ToString();
            data3 = Guid.NewGuid().ToString();
        }

        [Benchmark]
        public string StringConcat() => "test format" + data1 + data2 + data3;

        [Benchmark]
        public string StringInterpolation() => ($"test format{data1}, {data2}, {data3}");

    }

    public class StringBuilderVsStringInterpolation
    {
        private string data1;
        private string data2;
        private string data3;

        public StringBuilderVsStringInterpolation()
        {
            data1 = Guid.NewGuid().ToString();
            data2 = Guid.NewGuid().ToString();
            data3 = Guid.NewGuid().ToString();
        }

        [Benchmark]
        public string StringBuilder() => (new StringBuilder()).Append("test format").Append(data1).Append(data2).Append(data3).ToString();

        [Benchmark]
        public string StringInterpolation() => ($"test format{data1}, {data2}, {data3}");

    }

}
