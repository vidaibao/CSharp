
namespace ReverseLinkedList
{
    



    internal class Program
    {
        class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode next;

            public SinglyLinkedListNode(int x) { data = x; next = null; }

            public void InsertNode(int x)
            {

            }
        }


        static void Main(string[] args)
        {
            /*
            SinglyLinkedList llist = new SinglyLinkedList();

            List<int> llistCount = new List<int>() { 1,2,3,4,5 };

            for (int i = 0; i < llistCount.Count; i++)
            {
                llist.InsertNode(llistCount[i]);
            }

            SinglyLinkedListNode llist1 = reverse(llist.head);
            */

            LinkedList_Tutorials();

        }

        static void LinkedList_Tutorials()
        {
            Console.Title = "Custom Linked List";
            CustomLinkedList list = new CustomLinkedList();

            Console.WriteLine($"Is it empty? - {list.isEmpty()}");
            Console.WriteLine($"Count ? - {list.Count}");

            list.Add("test1");
            list.Add("test2");
            list.Add(1,"test3");
            list.Add("Hello");
            list.Add("world");
            list.Add("from");
            list.Add("my");
            list.Add("LinkedList");
            //list.Traverse(s => Console.Write($"{s} "));

            if (list.Contains("Hello"))
                Console.WriteLine($"index of Hello:  {list.IndexOf("Hello")}");

            Console.WriteLine($"Is it empty? - {list.isEmpty()}");
            Console.WriteLine($"Count ? - {list.Count}");

            list.showList();

            object test = list.Get(3);
            Console.WriteLine($"object test = list.Get(3) :  {test.ToString()}");
        }

        /*
        public static SinglyLinkedListNode reverse(SinglyLinkedListNode llist.head)
        {

        }
        */
    }
}