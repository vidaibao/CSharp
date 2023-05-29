namespace Merge2SortedLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        static SinglyLinkedListNode mergeLists(
            SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            SinglyLinkedList mergedLlist = new SinglyLinkedList();
            SinglyLinkedListNode cur1 = head1;
            SinglyLinkedListNode cur2 = head2;

            while (cur1 != null && cur2 != null)
            {
                if (cur1.data <= cur2.data)
                {
                    mergedLlist.InsertNode(cur1.data);
                    cur1 = cur1.next;
                }
                else
                {
                    mergedLlist.InsertNode(cur2.data);
                    cur2 = cur2.next;
                }
            }
            while (cur1 != null)
            {
                mergedLlist.InsertNode(cur1.data);
                cur1 = cur1.next;
            }
            while (cur2 != null)
            {
                mergedLlist.InsertNode(cur2.data);
                cur2 = cur2.next;
            }
            return mergedLlist.head;
        }
    }
}