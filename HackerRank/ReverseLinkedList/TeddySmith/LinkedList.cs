using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseLinkedList.TeddySmith
{
    public class LinkedList
    {
        public TeddySmith.Node First { get; set; }
        public void InsertFirst(int data)
        {
            // Create the new Node
            TeddySmith.Node newNode = new TeddySmith.Node();
            // Put data in the node
            newNode.Data = data;
            // Put the old node in next
            newNode.Next = First;
            // Make the first the new node
            First = newNode;
        }
    }
}
