using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList01
{
    public class DoublyLinkedListNode<T>
    {
        // Data
        public T Data { get; set; }

        //Link
        public DoublyLinkedListNode<T>? Next { get; internal set; }
        public DoublyLinkedListNode<T>? Prev { get; internal set; }

        // Constructor
        public DoublyLinkedListNode(T data) { this.Data = data; }
    }
}
