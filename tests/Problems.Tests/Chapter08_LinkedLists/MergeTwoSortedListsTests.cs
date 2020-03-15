using Problems.Chapter08_LinkedLists;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Problems.Tests.Chapter08_LinkedLists
{
    public class MergeTwoSortedListsTests
    {
        [Theory]
        [InlineData(new[] { 1, 3, 5 }, new[] { 2, 4, 6 }, new[] { 1, 2, 3, 4, 5, 6 })]
        [InlineData(new int[] { }, new[] { 2, 4, 6 }, new[] { 2, 4, 6 })]
        [InlineData(new[] { 1, 2 }, new[] { 2, 3 }, new[] { 1, 2, 2, 3 })]
        public void MergeAscending(int[] firstArray, int[] secondArray, int[] expectedArray)
        {
            var first = new SinglyLinkedList<int>(firstArray);
            var second = new SinglyLinkedList<int>(secondArray);

            var expected = new SinglyLinkedList<int>(expectedArray);

            var actual = first.MergeSortedAscending(second);

            Assert.Equal(expected, actual);
        }
    }
}
