using System.Collections.Generic;
using Problems.Chapter_10_BinaryTree;
using Problems.Chapter15_BinarySearchTrees;
using Xunit;

namespace Problems.Tests.Chapter15_BinarySearchTrees
{
    public class FindKLargestElementsInBSTTests
    {
        private FindKLargestElementsInBST<int> finder = new();

        [Theory]
        [MemberData(nameof(TestData))]
        public void FindLargestElementsTest(BinaryTree<int> bst, ushort numberOfElementsToFind, int[] expectedFoundElements)
        {
            var largestElements = finder.FindLargestElements(bst, numberOfElementsToFind);
            Assert.Equal(expectedFoundElements, largestElements);
        }
        
        public static IEnumerable<object[]> TestData()
        {
            var tree =TestDataHelper.CreateBinarySearchTreeFromImage15_1();
            
            yield return new object[] { tree, 3, new int [] {53,47,43} };
        }
    }
}