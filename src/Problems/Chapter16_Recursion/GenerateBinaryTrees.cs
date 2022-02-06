﻿using System;
using System.Collections.Generic;

namespace MockInterview.Recursion
{
    public class GenerateBinaryTrees<T> where T : IComparable<T>
    {
        public IReadOnlyCollection<BinaryTree<T>> GenerateAllBinaryTrees(int numberOfNodes)
        {
            if (numberOfNodes < 0) throw new ArgumentException(nameof(numberOfNodes));
            if (numberOfNodes == 0) return Array.Empty<BinaryTree<T>>();

            var results = new List<BinaryTree<T>>(); // TODO: hint at exact capacity - decrease allocations
            var tree = new BinaryTree<T>();
            var nodeCounter = 1;

            GenerateAllBinaryTrees(numberOfNodes, tree, tree, nodeCounter, results);

            return results;
        }

        public void GenerateAllBinaryTrees(int numberOfNodes, BinaryTree<T> root, BinaryTree<T> currentNode, int nodeCounter, ICollection<BinaryTree<T>> results)
        {
            if (numberOfNodes == nodeCounter) results.Add(root.Clone());
            if (numberOfNodes <= nodeCounter) return;

            // go left
            currentNode.Left = new();
            GenerateAllBinaryTrees(numberOfNodes, root, currentNode.Left, nodeCounter + 1, results);
            currentNode.Left = null;

            // go right
            currentNode.Right = new();
            GenerateAllBinaryTrees(numberOfNodes, root, currentNode.Right, nodeCounter + 1, results);
            currentNode.Right = null;

            // naive approach - to verify
            currentNode.Left = new();
            currentNode.Right = new();
            GenerateAllBinaryTrees(numberOfNodes, root, currentNode.Left, nodeCounter + 2, results);
            GenerateAllBinaryTrees(numberOfNodes, root, currentNode.Right, nodeCounter + 2, results);
            currentNode.Left = null;
            currentNode.Right = null;
        }

        // Test example  - 3 nodes -- error missed tree 3node, balanced
        //   x    	c = 1
        // x 	x	c = 2
        //  x     	c = 3
        //		c = 4
        // Recurrence: C(n) = 4C(n-1) = ... 4^(n-1)
        // c = 3, 4^2 = 16;
    }
}