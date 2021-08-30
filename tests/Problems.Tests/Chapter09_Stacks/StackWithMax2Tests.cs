using Problems.Chapter09_Stacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Problems.Tests.Chapter09_Stacks
{
    public class StackWithMax2Tests
    {
        [Fact]
        public void Peek_ShouldNotChangeMax()
        {
            var stack = new StackWithMax2<int>();
            stack.Push(5);

            Assert.Equal(5, stack.Peek());
            Assert.Equal(5, stack.Max());
        }

        [Fact]
        public void Pop_ShoulReflectMaxChange()
        {
            var stack = new StackWithMax2<int>();
            stack.Push(1);
            Assert.Equal(1, stack.Max());
            stack.Push(2);
            Assert.Equal(2, stack.Max());

            stack.Pop();
            Assert.Equal(1, stack.Max());
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void MaxTest(int expectedMax, StackWithMax2<int> stackWithMax2)
        {
            Assert.Equal(expectedMax, stackWithMax2.Max());
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return IncreasingOrder();
            yield return DecreasingOrder();
            yield return SawTooth();
        }

        private static object[] IncreasingOrder() => new object[] { 5, PutArrayInStack(1, 2, 3, 4, 5) };
        private static object[] DecreasingOrder() => new object[] { 5, PutArrayInStack(5, 4, 3, 2, 1) };
        private static object[] SawTooth() => new object[] { 3, PutArrayInStack(1, 3, 1, 3, 1) };

        private static StackWithMax2<T> PutArrayInStack<T>(params T[] data)
            where T : IComparable<T>
        {
            var stackWithMax = new StackWithMax2<T>();
            for (int i = 0; i < data.Length; i++)
            {
                stackWithMax.Push(data[i]);
            }
            return stackWithMax;
        }
    }
}
