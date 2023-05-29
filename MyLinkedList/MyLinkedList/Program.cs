using CustomLinkedList;

namespace MyLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedListDataInit();
            //DoublyLinkedListDataInit();
            
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

            Console.WriteLine();
            //Console.WriteLine(llist.Find(2).Data); ;
            
            Node<string> dd = new Node<string>("Add");
            int index = 2;
            Console.WriteLine($"Insert node data {dd.Data} to index = {index}, data = {llist.Find(index).Data}");
            llist.InsertNodeAt(2, dd);

            llist.Traverse();
        }
        /*
        static SinglyLinkedListNode insertNodeAtPosition(SinglyLinkedListNode llist, int data, int position)
        {
            SinglyLinkedListNode nextNode = llist;
            int i = 1;

            while (i < position)
            {
                nextNode = nextNode.next;
                i++;
            }

            SinglyLinkedListNode newNode = new SinglyLinkedListNode(data);
            newNode.next = nextNode.next;
            nextNode.next = newNode;

            return llist;
        }*/
    }
}