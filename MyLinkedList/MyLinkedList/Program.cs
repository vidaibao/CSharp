using CustomLinkedList;

namespace MyLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedListDataInit();
            
        }

      
        private static void LinkedListDataInit()
        {
            CustomLinkedList.LinkedList<string> llist = new CustomLinkedList.LinkedList<string>();

            Node<string> a = new Node<string>("aaa");
            llist.AddFirst(a);
            Node<string> b = new Node<string>("bbb");
            llist.AddLast(b);
            Node<string> c = new Node<string>("ccc");
            llist.AddLast(c);
            Node<string> d = new Node<string>("dddd");
            llist.AddLast(d);
            Node<string> e = new Node<string>("eeeee");
            llist.AddAfter(e, b);

            llist.Traverse();

            llist.ReverseSingly();

            llist.Traverse();

        }
    }
}