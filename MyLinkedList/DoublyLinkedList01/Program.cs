namespace DoublyLinkedList01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedListInit();
        }

        private static void DoublyLinkedListInit()
        {
            DoublyLinkedList<int> ll = new DoublyLinkedList<int>();

            ll.InsertNode(10);
            ll.InsertNode(20);
            ll.InsertNode(3);
            ll.InsertNode(4);

            ll.PrintList();

            ll.Reverse2();

            ll.PrintList();
        }
    }
}