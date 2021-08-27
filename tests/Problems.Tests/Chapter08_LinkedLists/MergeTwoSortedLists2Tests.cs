using Problems.Chapter08_LinkedLists;
using System.Collections.Generic;
using Xunit;

namespace Problems.Tests.Chapter08_LinkedLists
{
    public class MergeTwoSortedLists2Tests
    {
        MergeTwoSortedLists2 merger = new MergeTwoSortedLists2();

        [Theory]
        [MemberData(nameof(TestData))]
        public void MergeSorted_Test(Node<int> first, Node<int> second, Node<int> expectedMerged)
        {
            var actualMerged = merger.MergeSorted(first, second);
            Assert.Equal(expectedMerged, actualMerged);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[]
            {
                new Node<int>(2),
                new Node<int>(3),
                new Node<int>(2, new Node<int>(3))
            };
        }
    }
}
