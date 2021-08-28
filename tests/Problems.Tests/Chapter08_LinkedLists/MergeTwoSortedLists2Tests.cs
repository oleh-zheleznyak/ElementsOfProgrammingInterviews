using Problems.Chapter08_LinkedLists;
using System;
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
                ToSinglyLinkedList(2,3)
            };
            yield return new object[]
            {
                ToSinglyLinkedList(1,3,5),
                ToSinglyLinkedList(2,4,6),
                ToSinglyLinkedList(1,2,3,4,5,6)
            };
            yield return new object[]
            {
                ToSinglyLinkedList(1),
                ToSinglyLinkedList(1),
                ToSinglyLinkedList(1,1)
            };
        }

        public static Node<T> ToSinglyLinkedList<T>(params T[] array)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
            if (array.Length == 0) throw new ArgumentException("Cannot convert empty array to Linked List", nameof(array));

            var dummyHead = new Node<T>(default);
            var current = dummyHead;
            for (int i = 0; i < array.Length; i++)
            {
                current.Next = new Node<T>(array[i]);
                current = current.Next;
            }
            return dummyHead.Next;
        }
    }
}
