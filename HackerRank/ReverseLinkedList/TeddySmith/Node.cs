using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseLinkedList.TeddySmith
{
    public class Node
    {
        public int Data { get; set; }
        public Node? Next { get; set; }     // ? Nullable Reference Types

        public void DisplayNode()
        {
            Console.WriteLine(Data);
        }
    }
}
