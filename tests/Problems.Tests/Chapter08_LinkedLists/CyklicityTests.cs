using Problems.Chapter08_LinkedLists;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Problems.Tests.Chapter08_LinkedLists
{
    public class CyklicityTests
    {
        [Fact]
        public void FindFirstNodeInCycle_NoCycle()
        {
            var list = new SinglyLinkedList<int>(new[] { 1, 2 });
            var node = list.FindFirstNodeInCycle();

            Assert.Null(node);
        }

        [Fact]
        public void FindFirstNodeInCycle_SingleElementCycle()
        {
            var list = new SinglyLinkedList<int>(new[] { 1 });
            list.Head.Next = list.Head;

            var node = list.FindFirstNodeInCycle();

            Assert.Equal(list.Head, node);
        }

        [Fact]
        public void FindFirstNodeInCycle_TwoElementCycle()
        {
            var list = new SinglyLinkedList<int>(new[] { 1, 2 });
            list.Tail.Next = list.Head;

            var node = list.FindFirstNodeInCycle();

            Assert.Equal(list.Head, node);
        }

        [Fact]
        public void FindFirstNodeInCycle_TwoElementCycle_InTheMiddle()
        {
            var list = new SinglyLinkedList<int>(new[] { 1, 2, 3 });
            list.Tail.Next = list.Head.Next;

            var node = list.FindFirstNodeInCycle();

            Assert.Equal(list.Head.Next, node);
        }

        [Fact]
        public void FindFirstNodeInCycle_ThreeElementCycle_InTheMiddle()
        {
            var list = new SinglyLinkedList<int>(new[] { 1, 2, 3, 4 });

            var firstNodeInCycle = list.Head.Next; // 2

            list.Tail.Next = firstNodeInCycle;

            var node = list.FindFirstNodeInCycle();

            Assert.Equal(firstNodeInCycle, node);
        }
    }
}
