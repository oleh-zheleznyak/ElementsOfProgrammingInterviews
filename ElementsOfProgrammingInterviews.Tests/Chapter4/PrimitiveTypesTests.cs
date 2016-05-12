using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElementsOfProgrammingInterviews.Chapter4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElementsOfProgrammingInterviews.Tests;

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

        [TestMethod]
        public void IsPowerOfTwoTest_ReturnsTrue_GivenPowerOfTwo()
        {
            var data = TestDataProvider.GeneratePowersOfTwo(0, 10).ToList();

            data.ForEach(x => Assert.IsTrue(sut.IsPowerOfTwo(x)));
        }

        [TestMethod]
        public void IsPowerOfTwoTest_ReturnsFalse_GivenOddNumber()
        {
            var data = Odd(1, 10).ToList();

            data.ForEach(x => Assert.IsFalse(sut.IsPowerOfTwo(x)));
        }

        [TestMethod]
        public void IsPowerOfTwoTest_ReturnsFalse_GivenEvenNuberThatIsNotPowerOfTwo()
        {
            var data = Even(0, 10).Except(TestDataProvider.GeneratePowersOfTwo(1, 5)).ToList();

            data.ForEach(x => Assert.IsFalse(sut.IsPowerOfTwo(x)));
        }

        [TestMethod]
        public void ModuloPowerOfTwo_ShouldReturnZero_ForPowerZero()
        {
            Enumerable.Range(1, 10).ToList().ForEach(x => Assert.AreEqual(0, sut.ModuloPowerOfTwo(x, 0)));
        }

        [TestMethod]
        public void ModuloPowerOfTwo_ShouldReturnCorrectValues_WhenDividedByTwo()
        {
            Odd(1, 10).ToList().ForEach(x => Assert.AreEqual(1, sut.ModuloPowerOfTwo(x, 1)));
            Even(1, 10).ToList().ForEach(x => Assert.AreEqual(0, sut.ModuloPowerOfTwo(x, 1)));
        }

        [TestMethod]
        public void ModuloPowerOfTwo_ShouldReturnCorrectValues_WhenDividedByFour()
        {
            AssertDivisionByPowerOfTwo(2);
        }

        [TestMethod]
        public void ModuloPowerOfTwo_ShouldReturnCorrectValues_WhenDividedByEight()
        {
            AssertDivisionByPowerOfTwo(3);
        }

        private void AssertDivisionByPowerOfTwo(byte powerOfTwo)
        {
            Enumerable.Range(1, (1 << powerOfTwo) * 10).ToList().ForEach(x => AssertRemainderOfDivisionBy(x, powerOfTwo));
        }

        private void AssertRemainderOfDivisionBy(int number, byte powerOfTwo)
        {
            var expected = number % (1 << powerOfTwo);
            var actual = sut.ModuloPowerOfTwo(number, powerOfTwo);

            Assert.AreEqual(expected, actual);
        }

        private static IEnumerable<int> Odd(int seedStart, int seedEnd)
        {
            return Enumerable.Range(seedStart, seedEnd).Select(x => 2 * x + 1);
        }

        private static IEnumerable<int> Even(int seedStart, int seedEnd)
        {
            return Enumerable.Range(seedStart, seedEnd).Select(x => 2 * x);
        }

        private void AssertBitPropagation(string inputString, string expectedString)
        {
            var input = Convert.ToInt32(inputString, 2);
            var expected = Convert.ToInt32(expectedString, 2);
            var actual = sut.RightPropagateRightmostBit(input);

            Assert.AreEqual(expected, actual);
        }

        private void AssertScenarioWithSumsOfPowersOfTwo(Func<int, byte> bitCounter)
        {
            var powersOfTwo = TestDataProvider.GeneratePowersOfTwo(1, 10);
            var nextPowersOfTwo = TestDataProvider.GeneratePowersOfTwo(2, 11);

            var sumOfPowerPairs = powersOfTwo.Zip(nextPowersOfTwo, (x, y) => x + y).ToList();

            sumOfPowerPairs.ForEach(x => Assert.AreEqual(2, bitCounter(x)));
        }

        private void AssertScenarioWithPowersOfTwo(Func<int, byte> bitCounter)
        {
            var testData = TestDataProvider.GeneratePowersOfTwo(1, 10).ToList();

            testData.ForEach(x => Assert.AreEqual(1, bitCounter(x)));
        }
    }
}