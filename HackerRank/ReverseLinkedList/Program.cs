

namespace ReverseLinkedList
{
    
    public class ListNode
    {
        public int val;
        public ListNode? next;

        public ListNode(int x) { val = x; }

    }


    class Program
    {
       


        static void Main(string[] args)
        {

            LinkedListGeneric.LListGeneric();
            
            //LinkedList_Leetcode();

            //LinkedList_Tutorials();

            //LinkedList_TeddySmith();


        }

        

        private static void LinkedList_Generics00()
        {
            LinkedList<int> llist = new LinkedList<int>();

            llist.AddLast(1);
            llist.AddLast(2);
            llist.AddLast(3);
            llist.AddLast(4);

            llist.AddFirst(555);

            Console.WriteLine(string.Join(", ", llist.ToArray()));

            //Reverse<int>(llist);
            LinkedListNode<int>? currentNode = llist.First;
            //LinkedListNode<int>? previousNode = null;

            while (currentNode != null)
            {
                LinkedListNode<int>? nextNode = currentNode.Next;
                llist.Remove(currentNode);
                llist.AddFirst(currentNode);
                currentNode = nextNode;
            }

            //llist.First = previousNode;

            Console.WriteLine(string.Join(", ", llist.ToArray()));


        }

        public static void Reverse<T>(LinkedList<T> linkedList)
        {
            if (linkedList == null)
            {
                throw new ArgumentNullException(nameof(linkedList));
            }

            LinkedListNode<T>? currentNode = linkedList.First;
            LinkedListNode<T>? previousNode = null;

            while (currentNode != null)
            {
                LinkedListNode<T>? nextNode = currentNode.Next;
                previousNode = currentNode;
                currentNode = nextNode;
            }

            //linkedList.First = previousNode;
        }

        private static void LinkedList_Leetcode()
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);

            ListNode currentNode = head;

            while (currentNode != null)
            {
                Console.Write(currentNode.val + ",");
                currentNode = currentNode.next;
            }
            Console.WriteLine();

            currentNode = ReverseList(head);

            while (currentNode != null)
            {
                Console.Write(currentNode.val + ",");
                currentNode = currentNode.next;
            }
        }


        //Time complexity O(n) - list length
        //Space Complexicity O(1) - inplace sorting
        public static ListNode ReverseList(ListNode head)
        {
            ListNode currentNode = head;// needed to traverse through the list
            ListNode previousNode = null;//needed to point to previous node on each iteration
            ListNode tempNext;//needed to hold old point to next node

            while (currentNode != null)
            {
                tempNext = currentNode.next;//save point to next node
                currentNode.next = previousNode;//point current node to previous node
                previousNode = currentNode;//set new previous for next iteration
                currentNode = tempNext;//iterate forward
            }

            return previousNode;//return last actual node; note current node is null now
        }


        //Time complexity O(n) - list length
        //Space Complexicity O(n) - inplace sorting but recursing uses internal stack size = list.length
        public static ListNode ReverseListRecursive(ListNode head)
        {
            //when head.next is null then your at the end of the list or if its the single node then head will be null
            if (head == null || head.next == null) //return second to last
                return head;

            //loop through list
            ListNode p = ReverseListRecursive(head.next);

            // going 5 to 4 3 2 1
            //first will be second to last so 4.next = 5 then 5.next points to 4
            //head.next.next = head;
            ListNode last = head.next;
            last.next = head;// aka previous node
            head.next = null;// remove old pointer
            return p;
        }


        /*
        static SinglyLinkedListNode reverse(SinglyLinkedListNode llist)
        {
            if (llist == null)
                return llist;
            if (llist.next == null)
                return llist;
            SinglyLinkedListNode result = null;
            SinglyLinkedListNode current = llist, previous = null;

            while (current != null)
            {
                previous = current;
                current = current.next;
                previous.next = result;
                result = previous;

            }

            return result;
        }
        */








            private static void LinkedList_TeddySmith()
        {
            TeddySmith.Node nodeA = new TeddySmith.Node();
            nodeA.Data = 865;
            TeddySmith.Node nodeB = new TeddySmith.Node();
            nodeB.Data = 344;
            TeddySmith.Node nodeC = new TeddySmith.Node();
            nodeC.Data = 888;
            TeddySmith.Node nodeD = new TeddySmith.Node();
            nodeD.Data = 222;
            TeddySmith.Node nodeE = new TeddySmith.Node();
            nodeE.Data = 121;

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