using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElementsOfProgrammingInterviews.Chapter5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElementsOfProgrammingInterviews.Tests;
using System.Diagnostics;

namespace ElementsOfProgrammingInterviews.Chapter5.Tests
{
    [TestClass]
    public class ComputeParityOfAWordTests
    {
        [TestMethod]
        public void ComputeParity_ReturnsFalse_ForPowersOfTwo()
        {
            var sut = new ComputeParityOfAWord(new Chapter4.PrimitiveTypes());

            var input = TestDataProvider.GeneratePowersOfTwo(1, 10).Select(x => (long)x).ToArray();

            var actual = sut.ComputeParity(input).ToList();

            actual.ForEach(Assert.IsFalse);
        }

        [TestMethod]
        public void ComputeParity_ReturnsTrue_ForPowersOfTwoPlusOne()
        {
            var sut = new ComputeParityOfAWord(new Chapter4.PrimitiveTypes());

            var input = TestDataProvider.GeneratePowersOfTwo(1, 10).Select(x => 1 + (long)x).ToArray();

            var actual = sut.ComputeParity(input).ToList();

            actual.ForEach(Assert.IsTrue);
        }

        [TestMethod]
        public void ComputeParity_PerformanceTest()
        {
            var sut = new ComputeParityOfAWord(new Chapter4.PrimitiveTypes());

            var random = new Random();
            var input = Enumerable.Repeat(1, 10*ushort.MaxValue).Select(x => (long)random.Next()).ToArray();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var actual = sut.ComputeParity(input).ToList();

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}