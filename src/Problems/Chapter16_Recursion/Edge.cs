namespace Problems.Chapter16_Recursion
{
    public class Edge
    {
        public Edge(int length, Node root)
        {
            Length = length;
            Root = root;
        }

        public int Length { get; }
        public Node Root { get; }
    }
}