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
            AssertScenarioWithSumsOfPowersOfTwo(x => sut.ComputeNumberOfBitsSetTo1(x));
        }

        [TestMethod]
        public void ComputeNumberOfBitsSetTo1_Inefficient_ShouldReturnTwo_ForTuplesOfPowersOfTwoTest()
        {
            AssertScenarioWithSumsOfPowersOfTwo(x => sut.ComputeNumberOfBitsSetTo1_Inefficient(x));
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

        [TestMethod]
        public void RightPropagateRightmostBit_ShouldReturnZero_GivenZero()
        {
            Assert.AreEqual(0, sut.RightPropagateRightmostBit(0));
        }

        [TestMethod]
        public void RightPropagateRightmostBit_ShouldPropageteRightmostBit()
        {
            AssertBitPropagation("0001", "0001");
            AssertBitPropagation("0010", "0011");
            AssertBitPropagation("0100", "0111");
            AssertBitPropagation("1000", "1111");
        }

        private void AssertBitPropagation(string inputString, string expectedString)
        {
            var input = Convert.ToInt32(inputString, 2);
            var expected = Convert.ToInt32(expectedString, 2);
            var actual = sut.RightPropagateRightmostBit(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsPowerOfTwoTest_ReturnsTrue_GivenPowerOfTwo()
        {
            var data = GeneratePowersOfTwo(0, 10).ToList();

            data.ForEach(x => Assert.IsTrue(sut.IsPowerOfTwo(x)));
        }

        [TestMethod]
        public void IsPowerOfTwoTest_ReturnsFalse_GivenOddNumber()
        {
            var data = Enumerable.Range(1, 10).Select(x => 2 * x + 1).ToList();

            data.ForEach(x => Assert.IsFalse(sut.IsPowerOfTwo(x)));
        }

        [TestMethod]
        public void IsPowerOfTwoTest_ReturnsFalse_GivenEvenNuberThatIsNotPowerOfTwo()
        {
            var data = Enumerable.Range(0, 10).Select(x => 2 * x).Except(GeneratePowersOfTwo(1, 5)).ToList();

            data.ForEach(x => Assert.IsFalse(sut.IsPowerOfTwo(x)));
        }
    }
}