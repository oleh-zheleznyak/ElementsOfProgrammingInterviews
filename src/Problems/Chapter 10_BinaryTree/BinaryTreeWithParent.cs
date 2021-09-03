namespace Problems.Chapter_10_BinaryTree
{
    public class BinaryTreeWithParent<T>
    {
        public BinaryTreeWithParent() { }
        public BinaryTreeWithParent(T value) { Value = value; }

        public T Value { get; set; }

        private BinaryTreeWithParent<T>? left { get; set; }
        public BinaryTreeWithParent<T>? Left
        {
            get { return left; }
            set { left = value; if (value != null) value.Parent = this; }
        }

        private BinaryTreeWithParent<T>? right;
        public BinaryTreeWithParent<T>? Right
        {
            get { return right; }
            set { right = value; if (value != null) value.Parent = this; }
        }

        public BinaryTreeWithParent<T>? Parent { get; private set; }

        public bool IsLeaf => (Left is null) && (Right is null);

        public override string ToString() => Value?.ToString();
    }
}
