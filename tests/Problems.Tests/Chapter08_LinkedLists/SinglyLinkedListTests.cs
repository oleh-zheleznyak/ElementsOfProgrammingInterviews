using Problems.Chapter08_LinkedLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Problems.Tests.Chapter08_LinkedLists
{
    public class SinglyLinkedListTests
    {
        [Fact]
        public void Create()
        {
            var input = new[] { 1, 2, 3 };
            var linkedList = new SinglyLinkedList<int>(input);

            Assert.Equal(input, linkedList);
        }


        [Fact]
        public void Remove_Middle()
        {
            var linkedList = new SinglyLinkedList<int>(new[] { 1, 2, 3 });

            linkedList.Remove(2);

            Assert.Equal(new[] { 1, 3 }, linkedList);
        }

        [Fact]
        public void Remove_First()
        {
            var valueToRemove = 1;
            var newHeadValue = 2;

            var input = new[] { valueToRemove, newHeadValue, 3 };

            var linkedList = new SinglyLinkedList<int>(input);
            var head = linkedList.Head;

            linkedList.Remove(valueToRemove);
            var newHead = linkedList.Head;

            Assert.NotSame(head, newHead);
            Assert.Equal(newHeadValue, newHead.Value);
            Assert.Same(newHead, head.Next);

            Assert.Equal(new[] { 2, 3 }, linkedList);
        }

        [Fact]
        public void Remove_Last()
        {
            var linkedList = new SinglyLinkedList<int>(new[] { 1, 2, 3 });

            linkedList.Remove(3);

            Assert.Equal(new[] { 1, 2 }, linkedList);
        }

        [Fact]
        public void Add_AddsElementAtTheEnd()
        {
            var linkedList = new SinglyLinkedList<int>(new[] { 1, 2 });

            linkedList.Add(3);

            Assert.Equal(new[] { 1, 2, 3 }, linkedList);
        }

        [Fact]
        public void Add_IcreasesCount()
        {
            var input = new[] { 1, 2 };

            var linkedList = new SinglyLinkedList<int>(input);

            linkedList.Add(3);

            Assert.Equal(input.Length + 1, linkedList.Count);
        }

        [Fact]
        public void Add_UpdatesTail()
        {
            var input = new[] { 1, 2 };

            var linkedList = new SinglyLinkedList<int>(input);

            var tail = linkedList.Tail;
            Assert.Equal(tail.Value, input.Last());

            var valueToAdd = 3;
            linkedList.Add(valueToAdd);
            var newTail = linkedList.Tail;

            Assert.NotSame(tail, newTail);
            Assert.Same(tail.Next, newTail);
            Assert.Equal(valueToAdd, newTail.Value);
        }
    }
}
