using System;

namespace MockInterview.Recursion
{
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
}