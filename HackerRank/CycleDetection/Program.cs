namespace CycleDetection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList llist = new SinglyLinkedList();

            llist.InsertNode(1);
            llist.InsertNode(2);
            llist.InsertNode(3);
            llist.InsertNode(4);
            llist.InsertNode(5);
            llist.InsertNode(6);
            llist.InsertNode(7);
            llist.InsertNode(8);
            llist.InsertNode(9);
            llist.InsertNode(10);
            SinglyLinkedListNode node1 = new SinglyLinkedListNode(1);
            SinglyLinkedListNode node2 = new SinglyLinkedListNode(2);
            SinglyLinkedListNode node3 = new SinglyLinkedListNode(3);
            SinglyLinkedListNode node4 = new SinglyLinkedListNode(4);
            SinglyLinkedListNode node5 = new SinglyLinkedListNode(5);
            SinglyLinkedListNode node6 = new SinglyLinkedListNode(6);
            SinglyLinkedListNode node7 = new SinglyLinkedListNode(7);
            SinglyLinkedListNode node8 = new SinglyLinkedListNode(8);
            SinglyLinkedListNode node9 = new SinglyLinkedListNode(9);
            SinglyLinkedListNode node10 = new SinglyLinkedListNode(10);

            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = node6;
            node6.next = node7;
            node7.next = node8;
            node8.next = node9;
            node9.next = node10;
            node10.next = node9;


            bool result = hasCycle(llist.head);

            Console.WriteLine((result ? 1 : 0));
            

        }






        static bool hasCycle(SinglyLinkedListNode head)
        {
            var values = new HashSet<SinglyLinkedListNode>();
            while (head != null)
            {
                if (values.Contains(head))
                {
                    return true;
                }
                else
                {
                    values.Add(head);
                    head = head.next;
                }
            }
            return false;
        }


        static bool hasCycle00(SinglyLinkedListNode head)
        {

            //if (head == null || head.next == null) ok
            //    return false;

            SinglyLinkedListNode slow = head;
            SinglyLinkedListNode fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast)
                    return true;
            }

            return false;
        }



        class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode next;

            public SinglyLinkedListNode(int nodeData)
            {
                this.data = nodeData;
                this.next = null;
            }
        }

        class SinglyLinkedList
        {
            public SinglyLinkedListNode head;
            public SinglyLinkedListNode tail;

            public SinglyLinkedList()
            {
                this.head = null;
                this.tail = null;
            }

            public void InsertNode(int nodeData)
            {
                SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

                if (this.head == null)
                {
                    this.head = node;
                }
                else
                {
                    this.tail.next = node;
                }

                this.tail = node;
            }
        }

        static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep, TextWriter textWriter)
        {
            while (node != null)
            {
                textWriter.Write(node.data);

                node = node.next;

                if (node != null)
                {
                    textWriter.Write(sep);
                }
            }
        }
    }
}








/*
 * A linked list is said to contain a cycle if any node is visited more than once while traversing the list. 
 * Given a pointer to the head of a linked list, determine if it contains a cycle. If it does, return 1. 
 * Otherwise, return 0.

Example

head refers to the list of nodes 1 -> 2 -> 3 -> NULL

The numbers shown are the node numbers, not their data values. There is no cycle in this list so return 0.

head refers to the list of nodes 1 -> 2 -> 3 -> 1 -> NULL

There is a cycle where node 3 points back to node 1, so return 1.


Function Description

Complete the has_cycle function in the editor below.

It has the following parameter:

SinglyLinkedListNode pointer head: a reference to the head of the list
Returns

int: 1 if there is a cycle or 0 if there is not
Note: If the list is empty, head will be null.

Input Format

The code stub reads from stdin and passes the appropriate argument to your function.
The custom test cases format will not be described for this question due to its complexity.
Expand the section for the main function and review the code if you would like to figure out 
how to create a custom case.

Constraints

0 <= list size <= 1000

Sample Input

References to each of the following linked lists are passed as arguments to your function:

ref pic

1


Sample Output

0
1
Explanation

The first list has no cycle, so return .
The second list has a cycle, so return .
 */