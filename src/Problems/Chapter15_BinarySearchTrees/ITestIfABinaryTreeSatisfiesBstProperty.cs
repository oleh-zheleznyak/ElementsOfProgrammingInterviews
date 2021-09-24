using Problems.Chapter_10_BinaryTree;
using System;

namespace Problems.Chapter15_BinarySearchTrees
{
    public interface ITestIfABinaryTreeSatisfiesBstProperty<T> where T : IComparable<T>
    {
        bool IsABst(BinaryTree<T> binaryTree);
    }
}