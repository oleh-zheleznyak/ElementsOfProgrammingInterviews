using System.Collections;
using System.Collections.Generic;
using Problems.Chapter_10_BinaryTree;
using Problems.Chapter15_BinarySearchTrees;
using Xunit;

namespace Problems.Tests.Chapter15_BinarySearchTrees
{
    public class FindFirstKeyGreaterThanValueTests
    {
        private FindFirstKeyGreaterThanValue<int> finder = new();

        [Theory]
        [MemberData(nameof(TestData))]
        public void FindFirstGreaterThanTest(BinaryTree<int> tree, int valueToFind, int expectedResult)
        {
            var actualResult = finder.FindMinGreaterThan(tree, valueToFind);
            Assert.Equal(expectedResult, actualResult);
        }

        public static IEnumerable<object[]> TestData()
        {
            var tree =TestDataHelper.CreateBinarySearchTreeFromImage15_1();
            
            yield return new object[] { tree, 23, 29 };
            yield return new object[] { tree, 4, 5 };
            yield return new object[] { tree, 11, 13 };
            yield return new object[] { tree, 12, 13 };
            yield return new object[] { tree, 18, 19 };
            yield return new object[] { tree, 40, 41 };
            yield return new object[] { tree, 47, 53 };
        }

        
    }
}