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
        public void ComputeNumberOfBitsSetTo1_ShouldReturnOne_ForPowersOfTwoTest()
        {
            var testData = GeneratePowersOfTwo(1, 10).ToList();

            testData.ForEach(x => Assert.AreEqual(1, sut.ComputeNumberOfBitsSetTo1(x)));
        }

        [TestMethod]
        public void ComputeNumberOfBitsSetTo1_ShouldReturnTwo_ForTuplesOfPowersOfTwoTest()
        {
            var powersOfTwo = GeneratePowersOfTwo(1, 10);
            var nextPowersOfTwo = GeneratePowersOfTwo(2, 11);

            var sumOfPowerPairs = powersOfTwo.Zip(nextPowersOfTwo, (x, y) => x + y).ToList();

            sumOfPowerPairs.ForEach(x => Assert.AreEqual(2, sut.ComputeNumberOfBitsSetTo1(x)));
        }

        private IEnumerable<int> GeneratePowersOfTwo(int start, int end)
        {
            return Enumerable.Range(start, end).Select(x => (1 << x));
        }
    }
}