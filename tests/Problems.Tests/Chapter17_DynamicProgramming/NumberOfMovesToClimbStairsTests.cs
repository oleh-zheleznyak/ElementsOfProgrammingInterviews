using Problems.Chapter17_DynamicProgramming;
using System.Collections.Generic;
using Xunit;

namespace Problems.Tests.Chapter17_DynamicProgramming
{
    public class NumberOfMovesToClimbStairsTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void NumberOfWaysToGetToFloorTest(uint floor, uint maxSteps, uint expected)
        {
            var sut = new NumberOfMovesToClimbStairs();
            var actual = sut.NumberOfWaysToGetToFloor(floor, maxSteps);
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return BookExample();
            yield return SingleStep();
            yield return ThirdFloorWithThreeMaxSteps();
        }
        public static object[] BookExample() => new object[]
        {
          4,2,5
        };

        public static object[] SingleStep() => new object[]
        {
          3,1,1
        };

        public static object[] ThirdFloorWithThreeMaxSteps() => new object[]
        {
          3,3,4
        };
    }
}