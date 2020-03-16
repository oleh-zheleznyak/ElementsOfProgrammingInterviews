namespace Problems.Chapter08_LinkedLists
{
    public interface ISinglyLinkedListNode<T>
    {
        T Value { get; }
        ISinglyLinkedListNode<T>? Next { get; }
    }
}