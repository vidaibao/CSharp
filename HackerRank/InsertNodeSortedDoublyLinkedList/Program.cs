using System.IO;

namespace InsertNodeSortedDoublyLinkedList
{

    class DoublyLinkedListNode
    {
        public int data;
        public DoublyLinkedListNode next;
        public DoublyLinkedListNode prev;

        public DoublyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
            this.prev = null;
        }
    }

    class DoublyLinkedList
    {
        public DoublyLinkedListNode head;
        public DoublyLinkedListNode tail;

        public DoublyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData)
        {
            DoublyLinkedListNode node = new DoublyLinkedListNode(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
                node.prev = this.tail;
            }

            this.tail = node;
        }
    }

    


    internal class Program
    {

        

        static void Main(string[] args)
        {
            int data = 5;
            DoublyLinkedList llist = new DoublyLinkedList();
            llist.InsertNode(1);
            llist.InsertNode(3);
            llist.InsertNode(4);
            llist.InsertNode(10);

            DoublyLinkedListNode llist1 = sortedInsert(llist.head, data);

            PrintListInts(llist1);
        }

        // 


        public static DoublyLinkedListNode sortedInsert(DoublyLinkedListNode llist, int data)
        {
            if (llist == null) return null;
            
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(data);
            DoublyLinkedListNode cur = llist;

            if (cur.data >= data)
            {
                newNode.next = cur;
                cur.prev = newNode;
                return newNode;
            }

            while (cur != null)
            {
                if (cur.data >= data)
                {
                    cur.prev.next = newNode;
                    newNode.prev = cur.prev;
                    newNode.next = cur;
                    cur.prev = newNode;
                    break;
                }
                else if (cur.next == null)
                {
                    cur.next = newNode;
                    newNode.prev = cur;
                    break;
                }
                cur = cur.next;
            }

            return llist;
        }
        
            
            
            
            
            
        public static DoublyLinkedListNode sortedInsert00(DoublyLinkedListNode llist, int data)
        {
            List<int> list = new List<int>();
            DoublyLinkedListNode node = llist;
            //DoublyLinkedListNode prevNode;
            while (node != null)
            {
                if (node.data >= data) list.Add(data);
                
                list.Add(node.data);
                //prevNode = node;
                node = node.next;
            }

            DoublyLinkedList resLlist = new DoublyLinkedList();
            foreach (int i in list)
            {
                resLlist.InsertNode(i);
            }

            return resLlist.head;
        }


        static void PrintListInts(DoublyLinkedListNode node)
        {
            List<int> list = new List<int>();
            while (node != null)
            {
                list.Add(node.data);
                node = node.next;
            }
            Console.WriteLine(string.Join(" ", list));
        }

        static void PrintDoublyLinkedList(DoublyLinkedListNode node, string sep, TextWriter textWriter)
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
 * Given a reference to the head of a doubly-linked list and an integer, data, 
 * create a new DoublyLinkedListNode object having data value data and insert it 
 * at the proper location to maintain the sort.

Example

head refers to the list 1 <-> 2 <-> 4 -> NULL
data = 3

Return a reference to the new list: 1 <-> 2 <-> 3 <-> 4 -> NULL.


Function Description

Complete the sortedInsert function in the editor below.

sortedInsert has two parameters:

DoublyLinkedListNode pointer head: a reference to the head of a doubly-linked list

int data: An integer denoting the value of the data field for the DoublyLinkedListNode 
you must insert into the list.

Returns

DoublyLinkedListNode pointer: a reference to the head of the list
Note: Recall that an empty list (i.e., where head = NULL) and a list with one element are sorted lists.

Input Format

The first line contains an integer t, the number of test cases.

Each of the test case is in the following format:

The first line contains an integer n, the number of elements in the linked list.
Each of the next n lines contains an integer, the data for each node of the linked list.
The last line contains an integer, data, which needs to be inserted into the sorted doubly-linked list.


Constraints
1 <= t <= 10
1 <= n <= 1000
1 <= DoublyLinkedListNode.data <= 1000

Sample Input

STDIN   Function
-----   --------
1       t = 1
4       n = 4
1       node data values = 1, 3, 4, 10
3
4
10
5       data = 5
Sample Output

1 3 4 5 10
Explanation

The initial doubly linked list is:  1 <-> 3 <-> 4 <-> 10 -> NULL.

The doubly linked list after insertion is: 1 <-> 3 <-> 4 <-> 5 <-> 10 -> NULL.

 ----------------++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 
 
 /tmp/submission/20230529/23/42/hackerrank-3a01cccf862a290ad76b27b40cf333e4/code/Solution.cs(24,25): warning CS8625: Cannot convert null literal to non-nullable reference type. [/tmp/submission/20230529/23/42/hackerrank-3a01cccf862a290ad76b27b40cf333e4/code/Solution.csproj]
/tmp/submission/20230529/23/42/hackerrank-3a01cccf862a290ad76b27b40cf333e4/code/Solution.cs(25,25): warning CS8625: Cannot convert null literal to non-nullable reference type. [/tmp/submission/20230529/23/42/hackerrank-3a01cccf862a290ad76b27b40cf333e4/code/Solution.csproj]
/tmp/submission/20230529/23/42/hackerrank-3a01cccf862a290ad76b27b40cf333e4/code/Solution.cs(22,16): warning CS8618: Non-nullable field 'next' must contain a non-null value when exiting constructor. Consider declaring the field as nullable. [/tmp/submission/20230529/23/42/hackerrank-3a01cccf862a290ad76b27b40cf333e4/code/Solution.csproj]
/tmp/submission/20230529/23/42/hackerrank-3a01cccf862a290ad76b27b40cf333e4/code/Solution.cs(22,16): warning CS8618: Non-nullable field 'prev' must contain a non-null value when exiting constructor. Consider declaring the field as nullable. [/tmp/submission/20230529/23/42/hackerrank-3a01cccf862a290ad76b27b40cf333e4/code/Solution.csproj]
/tmp/submission/20230529/23/42/hackerrank-3a01cccf862a290ad76b27b40cf333e4/code/Solution.cs(34,25): warning CS8625: Cannot convert null literal to non-nullable reference type. [/tmp/submission/20230529/23/42/hackerrank-3a01cccf862a290ad76b27b40cf333e4/code/Solution.csproj]
/tmp/submission/20230529/23/42/hackerrank-3a01cccf862a290ad76b27b40cf333e4/code/Solution.cs(35,25): warning CS8625: Cannot convert null literal to non-nullable reference type. [/tmp/submission/20230529/23/42/hackerrank-3a01cccf862a290ad76b27b40cf333e4/code/Solution.csproj]
/tmp/submission/20230529/23/42/hackerrank-3a01cccf862a290ad76b27b40cf333e4/code/Solution.cs(33,16): warning CS8618: Non-nullable field 'head' must contain a non-null value when exiting constructor. Consider declaring the field as nullable. [/tmp/submission/20230529/23/42/hackerrank-3a01cccf862a290ad76b27b40cf333e4/code/Solution.csproj]
/tmp/submission/20230529/23/42/hackerrank-3a01cccf862a290ad76b27b40cf333e4/code/Solution.cs(33,16): warning CS8618: Non-nullable field 'tail' must contain a non-null value when exiting constructor. Consider declaring the field as nullable. [/tmp/submission/20230529/23/42/hackerrank-3a01cccf862a290ad76b27b40cf333e4/code/Solution.csproj]
/tmp/submission/20230529/23/42/hackerrank-3a01cccf862a290ad76b27b40cf333e4/code/Solution.cs(145,43): error CS0103: The name 'sortedInsert' does not exist in the current context [/tmp/submission/20230529/23/42/hackerrank-3a01cccf862a290ad76b27b40cf333e4/code/Solution.csproj]
/tmp/submission/20230529/23/42/hackerrank-3a01cccf862a290ad76b27b40cf333e4/code/Solution.cs(129,50): warning CS8604: Possible null reference argument for parameter 'path' in 'StreamWriter.StreamWriter(string path, bool append)'. [/tmp/submission/20230529/23/42/hackerrank-3a01cccf862a290ad76b27b40cf333e4/code/Solution.csproj]
Exit Status

1
 
 
 
 
 */