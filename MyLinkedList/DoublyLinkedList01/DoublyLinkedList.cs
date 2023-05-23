using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList01
{
    public class DoublyLinkedList<T>
    {
        public DoublyLinkedListNode<T> Head;
        public DoublyLinkedListNode<T> Tail;
        public int Count = 0;

        public DoublyLinkedList()
        {
            this.Head = null;
            this.Tail = null;
        }

        public void InsertNode(T nodeData)
        {
            DoublyLinkedListNode<T> node = new DoublyLinkedListNode<T>(nodeData);

            // empty list
            if (Head == null )
            {
                this.Head = node;
            }
            else // add to eolist
            {
                this.Tail.Next = node;
                node.Prev = this.Tail;
            }
            this.Tail = node;
            this.Count++;
        }

        public void PrintList()
        {
            DoublyLinkedListNode<T> node = this.Head;
            Console.WriteLine("LinkedList:");
            while (node != null)
            {
                Console.Write(node.Data + " ");
                node = node.Next;
            }
            Console.WriteLine();
        }

        public void Reverse()
        {
            if (this.Head == null || this.Count == 1)
            {
                return;
            }
            DoublyLinkedListNode<T>? cur = this.Head;
            DoublyLinkedListNode<T>? tempP, tempN;
            while (cur != null)
            {
                tempP = cur.Prev;
                cur.Prev = cur.Next;
                tempN = cur.Next;
                cur.Next = tempP;
                if (tempN == null) this.Head = cur;
                cur = tempN;
            }
        }

        public void Reverse2()
        {
            DoublyLinkedListNode<T>? cur = this.Head;
            DoublyLinkedListNode<T>? temp;
            while (cur != null)
            {
                temp = cur.Prev;
                cur.Prev = cur.Next;
                cur.Next = temp;
                if (cur.Prev == null) this.Head = cur;
                cur = cur.Prev;
            }
        }

    }
}
