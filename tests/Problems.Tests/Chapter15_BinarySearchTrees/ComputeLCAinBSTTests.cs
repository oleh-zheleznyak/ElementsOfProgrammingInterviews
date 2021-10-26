using Problems.Chapter_10_BinaryTree;
using Problems.Chapter15_BinarySearchTrees;
using System.Collections.Generic;
using Xunit;

namespace Problems.Tests.Chapter15_BinarySearchTrees
{
    public class ComputeLCAinBSTTests
    {
        private readonly ComputeLCAinBST<int> finder = new();

        [Theory]
        [MemberData(nameof(TestData))]
        public void FindFirstGreaterThanTest(BinaryTree<int> tree, int firstValue, int secondValue, int expectedResult)
        {
            var actualResult = finder.LowestCommonAncestor(tree, firstValue, secondValue);
            Assert.NotNull(actualResult);
            Assert.Equal(expectedResult, actualResult.Value);
        }

        public static IEnumerable<object[]> TestData()
        {
            var tree = TestDataHelper.CreateBinarySearchTreeFromImage15_1();

            yield return new object[] { tree, 3, 17, 7 };
            yield return new object[] { tree, 5, 13, 7 };
            yield return new object[] { tree, 7, 43, 19 };
            yield return new object[] { tree, 7, 17, 7 };
        }
    }
}
