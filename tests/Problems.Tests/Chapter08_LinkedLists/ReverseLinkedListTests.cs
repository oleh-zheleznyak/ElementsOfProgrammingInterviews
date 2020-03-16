using Problems.Chapter08_LinkedLists;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace Problems.Tests.Chapter08_LinkedLists
{
    public class ReverseLinkedListTests
    {
        [Fact]
        public void Reverse()
        {
            var original = new[] { 1, 2, 3 };

            var list = new SinglyLinkedList<int>(original);

            list.Reverse();

            var expected = new[] { 3, 2, 1 };

            Assert.Equal(expected.Length, list.Count);
            Assert.Equal(expected.First(), list.Head.Value);
            Assert.Equal(expected.Last(), list.Tail.Value); 

            Assert.Equal(expected, list.ToArray());
        }
    }
}
