namespace CustomLinkedList
{
    public class LinkedList<T>
    {
        // properties
        public Node<T> First { get; private set; }  // pointer to the first of the linked list
        public Node<T> Last { get; private set; }
        public int Count { get; private set; }

        public LinkedList() 
        {
            this.First = null;
            this.Last = null;
        }

        public void AddFirst(Node<T> newNode) 
        {
            if (this.First == null)
            {
                // this means the linkedlist is empty
                // insert the new node on point the head and tail
                this.First = newNode;
                this.Last = newNode;
            }
            else
            {
                // move the first to the next node
                newNode.Next = this.First;
                // set the new to the first
                this.First = newNode;
            }
            this.Count++;
        }

        public void AddLast(Node<T> newNode)
        {
            if (this.First == null)
            {
                // this means the linkedlist is empty
                // insert the new node on point the head and tail
                this.First = newNode;
                this.Last = newNode;
            }
            else
            {
                // move the last to the next node
                this.Last.Next = newNode;
                // set the new to the last
                this.Last = newNode;
            }
            this.Count++;   //++
        }

        public void AddAfter(Node<T> newNode, Node<T> existingNode)
        {
            // if you add after the last node, then u need to repoint Last pointer
            if (this.Last == existingNode)
            {
                this.Last = newNode;    // set the last pointer
            }
            newNode.Next = existingNode.Next;   // get the pointer to the next
            existingNode.Next = newNode;    //  point to the right after node
            this.Count++;
        }

        public void InsertNodeAt(int index, Node<T> newNode)
        {
            if (index >= Count)
            {
                AddLast(newNode);
                return;
            }
            if (index == 0)
            {
                AddFirst(newNode);
                return;
            }
            //Node<T> prev = null;
            Node<T> cur = this.First;
            int i = 1;
            while (i++ < index)
            {
                cur = cur.Next;
            }

            newNode.Next = cur.Next;
            cur.Next = newNode;
            Count++;
        }

        public void InsertNodeAt01(int index, Node<T> newNode)
        {
            if (index >= Count)
            {
                AddLast(newNode);
                return;
            }
            if (index == 0)
            {
                AddFirst(newNode);
                return;
            }
            Node<T> prev = null;
            Node<T> cur = this.First;
            int i = 0;
            while (cur != null && i++ < index)
            {
                prev = cur;
                cur = cur.Next;
            }

            prev.Next = newNode;
            newNode.Next = cur;
            Count++;
        }

        public Node<T> Find(T target)
        {
            Node<T> currentNode = First;
            // loop points to the end (null) or to the targer
            while (currentNode != null && !currentNode.Data.Equals(target))
            {
                currentNode = currentNode.Next;
            }
            return currentNode;
        }

        public Node<T> Find(int index)
        {
            Node<T> currentNode = First;
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }
            return currentNode;
        }



        public void RemoveFirst()
        {
            // empty list
            if (First == null || Count == 0)
            {
                return;
            }
            // set new First
            First = First.Next;
            Count--; // --
        }

        public void RemoveLast()
        {
            if (Last == null || Count == 0)
                return;
            
            Node<T> currentNode = First;
            
            while (currentNode.Next != Last)
                currentNode = currentNode.Next;
            
            Last = currentNode;
            Count--;
        }

        public void Remove(Node<T> node)
        {
            if (First == null || Count == 0)
                return;
        
            if (node == First)
            {
                RemoveFirst();
                return;
            }
            else if (node == Last)
            {
                RemoveLast();
                return;
            }
            else // need to traverse the linked list to find the node and remove it
            {
                Node<T> previous = First;
                Node<T> current = previous.Next;
                while (current != null && current != node)
                {
                    // move to the next node
                    previous = current;
                    current = current.Next;
                }
                //remove it
                if (current != null)
                {
                    previous.Next = current.Next;
                    Count--;
                }
                
            }
        }

        public void Remove(T target)
        {
            Remove(Find(target));
        }

        public void Traverse()
        {
            Console.WriteLine($"First {this.First.Data}");
            Console.WriteLine($"Last {this.Last.Data}");

            Node<T> node = First;
            while ( node.Next != null )
            {
                Console.WriteLine(node.Data);
                node = node.Next;
            }
            Console.WriteLine(node.Data);
        }

        public Node<T> ReverseSingly()
        {
            if (First == null || First.Next == null)// empty or only 1 el
                return First;
            // a->b->c->null
            Node<T> prev = null;
            Node<T> cur = First;    //a
            Node<T> post;           //hold old pointer to next node
            while (cur != null)     //the eollist
            {
                post = cur.Next;    //save pointer (b= a.next) to node post 
                cur.Next = prev;    //set b.next points to previous node
                prev = cur;         //set new previous node = a
                cur = post;         //move pointer forward b (post)
            }
            Last = First;
            First = prev;
            return prev;
        }

        public Node<T> ReverseDoubly()
        {
            if (First == null || First.Next == null)// empty or only 1 el
                return First;

            return null;
        }

    }
}