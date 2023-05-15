using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ReverseLinkedList
{
    public class CustomLinkedList
    {
        /*
         * Constructor:
         * LinkedList() - Initializes the private fields
         * 
         * Private fields:
         * Node head - Is a reference to the FIRST node in the list
         * int size - the current size of the list
         * 
         * Puplic Properties:
         * Empty - if the list is empty
         * Count - How many items in the list
         * Indexer - Access data like an array
         * 
         * Methods:
         * Add(int index, object o) - Add an item to the END of the list
         * Remove(int index) - Remove the item in the list at the specified index
         * Clear() - Clear the list
         * IndexOf(object o) - get the index of the item in the list, if not in list, return -1
         * Contains(object o) - if the list contains the object
         * Get(int index) - Gets item at the specified index
         */

        private Node head;
        private int count;

        public CustomLinkedList() 
        {
            this.head = null;
            this.count = 0;
        }

        public bool isEmpty() { return this.count == 0; } 

        public int Count { get { return this.count; } }

        public object this[int index]
        {
            get { return this.Get(index); }
        }

        // 0  1  2  3  4
        // a->b->e->c->d
        public object Add(int index, object o)
        {
            if (index < 0 ) { throw new ArgumentOutOfRangeException($"index: {index}"); }
            if (index > this.count) index = this.count;
            
            Node current = this.head;

            if (this.isEmpty() || index == 0)
            {
                this.head = new Node(o, this.head);
            }
            else
            {
                for (int i = 0; i < index - 1; i++)
                    current = current.next;
                
                current.next = new Node(o, current.next);
            }

            this.count++;
            return o;
        }

        public object Add(object o) 
        {
            return this.Add(count, o);
        }

        public object Remove(int index)
        {
            if (index < 0) { throw new ArgumentOutOfRangeException($"index: {index}"); }
            
            if (this.isEmpty()) return null;

            if (index > this.count) index = count - 1;
            
            Node current = this.head;
            object result = null;

            if (index == 0)
            {
                result = current.Data;
                this.head = current.next;
            }
            else
            {
                for (int i = 0; i < index; i++)
                    current = current.next;

                result = current.next.Data;

                current.next = current.next.next;
                // a->b->d
            }

            this.count--;

            return result;
        }

        public void Clear()
        {
            this.head = null;
            this.count = 0;
        }

        public int IndexOf(object o)
        {
            Node current = this.head;

            for (int i = 0; i < this.count; i++)
            {
                if (current.Data.Equals(o))
                    return i;

                current = current.next;
            }
            return -1;
        }

        public bool Contains(object o)
        {
            return this.IndexOf(o) >= 0;
        }

        public void showList()
        {
            Node current = this.head;

            for (int i = 0; i < this.count; i++)
            {
                Console.WriteLine(current.Data.ToString());
                current = current.next;
            }
        }

        public object Get(int index)
        {
            if (index < 0) { throw new ArgumentOutOfRangeException($"index: {index}"); }

            if (this.isEmpty()) return null;

            if (index > this.count) index = count - 1;

            Node current = this.head;

            for (int i = 0; i < index; i++)
                current = current.next;
            
            return current.Data;
        }

        /*
        public void Traverse(Action<T> action)
        {
            var current = head;
            while (current.next != null)
            {
                action?.Invoke(current.next.Data);
                current = current.next;
            }
        }
        */
    }
}
