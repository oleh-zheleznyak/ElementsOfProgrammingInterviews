namespace Problems.Chapter09_Stacks
{
    public class BinaryTreeNode<T> // Binary tree, not a BST
    {
        public BinaryTreeNode(T value) => this.Value = value;

        public T Value { get; set; }
        public BinaryTreeNode<T>? Left { get; set; }
        public BinaryTreeNode<T>? Right { get; set; }
    }
}
