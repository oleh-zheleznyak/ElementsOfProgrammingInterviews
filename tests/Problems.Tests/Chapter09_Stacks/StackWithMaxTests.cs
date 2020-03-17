using Problems.Chapter09_Stacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Problems.Tests.Chapter09_Stacks
{
    public class StackWithMaxTests
    {
        [Fact]
        public void Max_SingleElement()
        {
            var expected = 42;
            var stack = new StackWithMax<int>(new[] { expected });

            var actual = stack.Max;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Max_MultipleElements()
        {
            var input = new[] { 1, 5, 3, 7, 2, 7, 2 };
            var expected = input.Max();
            var stack = new StackWithMax<int>(input);

            var actual = stack.Max;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Push_UpdatesMax()
        {
            var stack = new StackWithMax<int>();

            var first = 42;
            stack.Push(42);
            Assert.Equal(first, stack.Max);

            var second = 53;
            stack.Push(second);
            Assert.Equal(second, stack.Max);
        }

        [Fact]
        public void Pop_UpdatesMax()
        {
            var stack = new StackWithMax<int>(new[] { 1, 2, 3 });
            Assert.Equal(3, stack.Max);

            Assert.Equal(3, stack.Pop());
            Assert.Equal(2, stack.Max);

            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Max);
        }
    }
}
