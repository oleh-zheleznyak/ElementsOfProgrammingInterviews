using MockInterview.Recursion;
using System;
using System.Collections.Generic;

namespace Problems.Tests.Chapter16_Recursion
{
    public class GenerateBinaryTreesTestBase
    {

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { 0, Array.Empty<BinaryTree<int>>() };
            yield return new object[] { 1, new[] { new BinaryTree<int>() } };
            yield return new object[] { 2, new[]
            {
                new BinaryTree<int>() { Left = new() },
                new BinaryTree<int>() { Right = new() },
            } };
            yield return new object[] { 3, new[]
            {
                new BinaryTree<int>() { Left = new() { Left=new() } },
                new BinaryTree<int>() { Left = new() { Right=new() } },
                new BinaryTree<int>() { Left=new(), Right=new()  },
                new BinaryTree<int>() { Right=new() { Left=new() } },
                new BinaryTree<int>() { Right=new() { Right=new() } },
            } };
            yield return new object[] { 4, new[]
            {
                new BinaryTree<int>() { Left = new() { Left=new() { Left=new() } } },
                new BinaryTree<int>() { Left = new() { Left=new() { Right=new() } } },
                new BinaryTree<int>() { Left = new() { Left=new() , Right=new() } },
                new BinaryTree<int>() { Left = new() { Left=new() }, Right = new() },

                new BinaryTree<int>() { Left = new() { Left=new(), Right=new() } },
                new BinaryTree<int>() { Left = new() { Right=new() }, Right=new() },
                new BinaryTree<int>() { Left = new() { Right=new() { Left=new() } } },
                new BinaryTree<int>() { Left = new() { Right=new() { Right = new() } } },

                new BinaryTree<int>() { Left=new() {Left=new()}, Right=new()  },
                new BinaryTree<int>() { Left=new() {Right=new()}, Right=new()  },
                new BinaryTree<int>() { Left=new(), Right=new() {Left=new() }  },
                new BinaryTree<int>() { Left=new(), Right=new() { Right = new() }  },

                new BinaryTree<int>() { Left=new(), Right=new() { Left=new() } },
                new BinaryTree<int>() { Right=new() { Left=new(), Right=new() } },
                new BinaryTree<int>() { Right=new() { Left=new() {Left=new() } } },
                new BinaryTree<int>() { Right=new() { Left=new() {Right=new() } } },

                new BinaryTree<int>() { Left=new(), Right=new() { Right=new() } },
                new BinaryTree<int>() { Right=new() { Left=new(), Right=new() } },
                new BinaryTree<int>() { Right=new() { Right=new() {Left=new() } } },
                new BinaryTree<int>() { Right=new() { Right=new() {Right=new() } } },
            } };
        }
    }
}