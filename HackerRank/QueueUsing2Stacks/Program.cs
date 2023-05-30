namespace QueueUsing2Stacks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QueueStack<int> queue = new QueueStack<int>();

            int N = int.Parse(Console.ReadLine().Trim());
            int queryType = 0;
            
            for (int i = 0; i < N; i++)
            {
                var readLine = Console.ReadLine().Trim().Split(" ");
                queryType = int.Parse(readLine[0]);
                if (queryType == 1) // enqueue
                {
                    queue.Enqueue(int.Parse(readLine[1]));
                }
                else if (queryType == 2)    // dequeue front element
                {
                    queue.Dequeue();
                }
                else if (queryType == 3)    // print the front element
                {
                    Console.WriteLine(queue.Peek());
                }

            }
        }
    }

    class QueueStack<T>
    {
        private Stack<T> st1;
        private Stack<T> st2;

        public QueueStack()
        {
            st1 = new Stack<T>();
            st2 = new Stack<T>();
        }

        public void Enqueue(T data)
        {
            st1.Push(data);
        }

        public T Dequeue()
        {
            if (st2.Count == 0)
            {
                while (st1.Count > 0)
                {
                    st2.Push(st1.Pop());
                }
            }
            return st2.Pop();
        }

        public T Peek()
        {
            if (st2.Count == 0)
            {
                while (st1.Count > 0)
                {
                    st2.Push(st1.Pop());
                }
            }
            return st2.Peek();
        }
    }


    class QueueUsingStack
    {
        private Stack<int> stack1;
        private Stack<int> stack2;

        public QueueUsingStack()
        {
            stack1 = new Stack<int>();
            stack2 = new Stack<int>();
        }

        public void Enqueue(int item)
        {
            stack1.Push(item);
        }

        public int Dequeue()
        {
            if (stack1.Count == 0 && stack2.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            if (stack2.Count == 0)
            {
                while (stack1.Count > 0)
                {
                    stack2.Push(stack1.Pop());
                }
            }

            return stack2.Pop();
        }
    }
}






/*
 * A queue is an abstract data type that maintains the order in which elements were 
 * added to it, allowing the oldest elements to be removed from the front and new 
 * elements to be added to the rear. This is called a First-In-First-Out (FIFO) 
 * data structure because the first element added to the queue (i.e., the one that 
 * has been waiting the longest) is always the first one to be removed.

A basic queue has the following operations:

Enqueue: add a new element to the end of the queue.
Dequeue: remove the element from the front of the queue and return it.

In this challenge, you must first implement a queue using two stacks. 
Then process  queries, where each query is one of the following  types:

1 x: Enqueue element  into the end of the queue.
2: Dequeue the element at the front of the queue.
3: Print the element at the front of the queue.

Input Format

The first line contains a single integer, q, denoting the number of queries.
Each line i of the q subsequent lines contains a single query in the form described
in the problem statement above. All three queries start with an integer denoting the 
query type, but only query 1 is followed by an additional space-separated value, x,
denoting the value to be enqueued.

Constraints
1 <= q <= 10^5
1 <= type <= 3
1 <= |x| <= 10^9
It is guaranteed that a valid answer always exists for each query of type 3.


Output Format

For each query of type 3, print the value of the element at the front of the queue 
on a new line.

Sample Input

STDIN   Function
-----   --------
10      q = 10 (number of queries)
1 42    1st query, enqueue 42
2       dequeue front element
1 14    enqueue 42
3       print the front element
1 28    enqueue 28
3       print the front element
1 60    enqueue 60
1 78    enqueue 78
2       dequeue front element
2       dequeue front element
Sample Output

14
14
Explanation

Perform the following sequence of actions:

Enqueue 42; queue = {42}.
Dequeue the value at the head of the queue, 42; queue = {}.
Enqueue 14; queue = {14}.
Print the value at the head of the queue, 14; queue = {14}.
Enqueue 28; queue = {14,28}.
Print the value at the head of the queue, 14; queue = {14,28}.
Enqueue 60; queue = {14,28,60}.
Enqueue 78; queue = {14,28,60,78}.
Dequeue the value at the head of the queue, 14; queue = {28,60,78}.
Dequeue the value at the head of the queue, 28; queue = {60,78}.
 
 
 
 
 
 
 
 
10     
1 42
2       
1 14    
3       
1 28    
3       
1 60    
1 78    
2       
2  
 
 
 
 
 */