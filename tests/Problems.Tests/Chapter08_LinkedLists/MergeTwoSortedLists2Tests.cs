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
                TestHelpers.ToSinglyLinkedList(2,3)
            };
            yield return new object[]
            {
                TestHelpers.ToSinglyLinkedList(1,3,5),
                TestHelpers.ToSinglyLinkedList(2,4,6),
                TestHelpers.ToSinglyLinkedList(1,2,3,4,5,6)
            };
            yield return new object[]
            {
                TestHelpers.ToSinglyLinkedList(1),
                TestHelpers.ToSinglyLinkedList(1),
                TestHelpers.ToSinglyLinkedList(1,1)
            };
        }
    }
}
