namespace DoublyLinkedList
{
    class Node<T> where T : IComparable
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node()
        {
            Data = default;
            Next = null;
        }
        public Node(T element)
        {
            Data = element;
            Next = null;
        }
    }
}