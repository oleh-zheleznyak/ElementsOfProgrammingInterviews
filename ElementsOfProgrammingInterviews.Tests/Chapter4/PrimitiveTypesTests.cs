using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElementsOfProgrammingInterviews.Chapter4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsOfProgrammingInterviews.Chapter4.Tests
{
    [TestClass]
    public class PrimitiveTypesTests
    {
        private PrimitiveTypes sut;

        [TestInitialize]
        public void TestInitialize()
        {
            sut = new PrimitiveTypes();
        }

        [TestMethod]
        public void ComputeNumberOfBitsSetTo1_Inefficient_ShouldReturnOne_ForPowersOfTwoTest()
        {
            AssertScenarioWithPowersOfTwo(x => sut.ComputeNumberOfBitsSetTo1_Inefficient(x));
        }

        [TestMethod]
        public void ComputeNumberOfBitsSetTo1_ShouldReturnOne_ForPowersOfTwoTest()
        {
            AssertScenarioWithPowersOfTwo(x => sut.ComputeNumberOfBitsSetTo1(x));
        }

        private void AssertScenarioWithPowersOfTwo(Func<int, byte> bitCounter)
        {
            var testData = GeneratePowersOfTwo(1, 10).ToList();

            testData.ForEach(x => Assert.AreEqual(1, bitCounter(x)));
        }

        [TestMethod]
        public void ComputeNumberOfBitsSetTo1_ShouldReturnTwo_ForTuplesOfPowersOfTwoTest()
        {
            AssertScenarioWithSumsOfPowersOfTwo(x=>sut.ComputeNumberOfBitsSetTo1(x));
        }

        [TestMethod]
        public void ComputeNumberOfBitsSetTo1_Inefficient_ShouldReturnTwo_ForTuplesOfPowersOfTwoTest()
        {
            AssertScenarioWithSumsOfPowersOfTwo(x=>sut.ComputeNumberOfBitsSetTo1_Inefficient(x));
        }

        private void AssertScenarioWithSumsOfPowersOfTwo(Func<int, byte> bitCounter)
        {
            var powersOfTwo = GeneratePowersOfTwo(1, 10);
            var nextPowersOfTwo = GeneratePowersOfTwo(2, 11);

            var sumOfPowerPairs = powersOfTwo.Zip(nextPowersOfTwo, (x, y) => x + y).ToList();

            sumOfPowerPairs.ForEach(x => Assert.AreEqual(2, bitCounter(x)));
        }

        private IEnumerable<int> GeneratePowersOfTwo(int start, int end)
        {
            return Enumerable.Range(start, end).Select(x => (1 << x));
        }
    }
}