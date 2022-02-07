using System;
using System.Collections.Generic;

namespace MockInterview.Recursion
{
    public interface IBinaryTreeGenerator<T> where T : IComparable<T>
    {
        IReadOnlyCollection<BinaryTree<T>> GenerateAllBinaryTrees(int numberOfNodes);
    }
}