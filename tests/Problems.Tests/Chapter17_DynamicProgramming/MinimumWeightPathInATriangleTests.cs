using Problems.Chapter17_DynamicProgramming;
using System.Collections.Generic;
using Xunit;

namespace Problems.Tests.Chapter17_DynamicProgramming
{
    public class MinimumWeightPathInATriangleTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void FindMinimumWeightPathTest(int[][] triangle, int expectedMinWeight)
        {
            var sut = new MinimumWeightPathInATriangle();
            var actual = sut.FindMinimumWeightPath(triangle);
            Assert.Equal(expectedMinWeight, actual);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return BookExample();
            yield return BiggerExample();
        }
        public static object[] BookExample() => new object[]
        {
           new int[][]
           {
               new[] { 2 },
               new[] { 4,4 },
               new[] { 8,5,6 },
               new[] { 4,2,6,2 },
               new[] { 1,5,2,3,4 },
           },
           15
        };

        public static object[] BiggerExample() => new object[]
        {
           new int[][]
           {
               new[] { 1 },
               new[] { 1,2 },
               new[] { 1,2,3 },
               new[] { 1,2,3,4 },
               new[] { 1,2,3,4,5 },
               new[] { 1,2,3,4,5,6 },
               new[] { 1,2,3,4,5,6,7 },
               new[] { 1,2,3,4,5,6,7,8 },
               new[] { 1,2,3,4,5,6,7,8,9 },
               new[] { 1,2,3,4,5,6,7,8,9,10 },
           },
           10
        };
    }
}