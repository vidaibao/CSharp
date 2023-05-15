using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseLinkedList
{
    public class Node
    {
        /*
         * Constructor:
         * 
         * Private fields:
         * object data - contain data of the node, what we want to store in the list
         * Mode next - reference to the next node in the list
         * 
         * Public fields:
         * Data - get/set data field
         * Next - get/set next field
         */

        private object data;
        public Node next;

        public Node(object data, Node next)
        {
            this.data = data;
            this.next = next;
        }

        public object Data { get { return data; } set { this.Data = value; } }
    }
}
