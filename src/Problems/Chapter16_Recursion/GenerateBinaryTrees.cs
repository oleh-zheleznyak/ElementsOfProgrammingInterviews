﻿using System;
using System.Collections.Generic;

namespace MockInterview.Recursion
{
	// 16.8 Generate Binary Trees
	// 44 min 32 sec, no hints

	public class BinaryTree<T> where T : IComparable<T>
	{
		// TODO: improve OO desing, improve incapsulation
		// Encapsulate construction of tree, to avoid invalid trees
		public T Value { get; set; }
		public BinaryTree<T>? Left { get; set; }
		public BinaryTree<T>? Right { get; set; }

		// copies the enire structure and returns the new reference
		public BinaryTree<T> Clone()
		{
			var newTree = new BinaryTree<T>();
			newTree.Value = Value;

			newTree.Left = Left?.Clone();
			newTree.Right = Right?.Clone();

			return newTree;
		}
	}

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

		public void GenerateAllBinaryTrees(int numberOfNodes, BinaryTree<T> root,  BinaryTree<T> currentNode, int nodeCounter, ICollection<BinaryTree<T>> results)
		{
			// TODO: mistakes to fix - copy tree, otherwise it's mutated.
			if (numberOfNodes == nodeCounter) results.Add(root.Clone());
			if (numberOfNodes <= nodeCounter) return;

			// go left
			currentNode.Left = new BinaryTree<T>();
			GenerateAllBinaryTrees(numberOfNodes, root, currentNode.Left, nodeCounter + 1, results);
			currentNode.Left = null;

			// go right
			currentNode.Right = new BinaryTree<T>();
			GenerateAllBinaryTrees(numberOfNodes, root, currentNode.Right, nodeCounter + 1, results);
			currentNode.Right = null;

			// naive approach - to verify
			currentNode.Left = new BinaryTree<T>();
			currentNode.Right = new BinaryTree<T>();
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