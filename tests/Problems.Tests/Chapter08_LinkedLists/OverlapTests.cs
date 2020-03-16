using Problems.Chapter08_LinkedLists;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Problems.Tests.Chapter08_LinkedLists
{
    public class OverlapTests
    {
        [Fact]
        public void Overlap_Last()
        {
            var first = new SinglyLinkedList<int>(new[] { 2, 4, 100 });
            var second = new SinglyLinkedList<int>(new[] { 1, 3 });

            var expectedOverlap = first.Tail;
            second.Tail.Next = expectedOverlap;

            var actual = first.FindFirstOverlappingNode(second);

            Assert.Equal(expectedOverlap, actual);
        }

        [Fact]
        public void Overlap_Middle()
        {
            var first = new SinglyLinkedList<int>(new[] { 2, 4, 6 });
            var second = new SinglyLinkedList<int>(new[] { 3 });

            var expectedOverlap = first.Head.Next; // 4
            second.Tail.Next = expectedOverlap;

            var actual = first.FindFirstOverlappingNode(second);

            Assert.Equal(expectedOverlap, actual);
        }

        [Fact]
        public void Overlap_Beginning()
        {
            var first = new SinglyLinkedList<int>(new[] { 2, 3, 4 });
            var second = new SinglyLinkedList<int>(new[] { 0, 1 });

            var expectedOverlap = first.Head;
            second.Tail.Next = expectedOverlap;

            var actual = first.FindFirstOverlappingNode(second);

            Assert.Equal(expectedOverlap, actual);
        }
    }
}
