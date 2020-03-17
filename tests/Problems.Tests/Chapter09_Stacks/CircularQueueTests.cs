using Problems.Chapter09_Stacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Problems.Tests.Chapter09_Stacks
{
    public class CircularQueueTests
    {
        [Fact]
        public void Enumerate()
        {
            var input = new[] { 1, 2, 3, 4, 5 };
            var queue = new CircularQueue<int>(input);

            Assert.Equal(input, queue);
            Assert.Equal(input.Length, queue.Count);
        }

        [Fact]
        public void Enqueue()
        {
            var input = new List<int>() { 1, 2 };
            var queue = new CircularQueue<int>(input);

            queue.Enqueue(3);
            input.Add(3);

            Assert.Equal(input, queue);
        }

        [Fact]
        public void Dequeue()
        {
            var input = new List<int>() { 1, 2, 3 };
            var queue = new CircularQueue<int>(input);

            var value = queue.Dequeue();
            Assert.Equal(input.First(), value);

            input.RemoveAt(0);
            Assert.Equal(input, queue);
        }

        [Fact]
        public void WrapAround()
        {
            var input = new List<int>() { 1, 2 };
            var queue = new CircularQueue<int>(input);

            var removed = queue.Dequeue();
            Assert.Equal(input.First(), removed);

            var added = 3;
            queue.Enqueue(added);

            var expected = new[] { 2, 3 };

            Assert.Equal(expected, queue);
        }
    }
}
