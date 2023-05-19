using System.Text;

namespace BookReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookReading();
        }

        private static void BookReading()
        {
            Console.OutputEncoding = Encoding.Unicode;
            string filePath = "F:\\NAV\\com\\vidaibao\\learning\\csharp\\MyLinkedList\\BookReader\\Resources\\TienHiep.txt";
            var pages = Open(filePath, 2000);
            var current = pages.First;
            while (current != null)
            {
                Console.Clear();
                Console.WriteLine($"- page {current.Value.Number} -\r\n");
                Console.WriteLine(current.Value.Content);
                Console.WriteLine("\r\n< Previous [P] | [N] Next >");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.N:
                        if (current.Next != null)
                        {
                            current = current.Next;
                        }
                        break;
                    case ConsoleKey.P:
                        if (current.Previous != null)
                        {
                            current = current.Previous;
                        }
                        break;
                    default: return;
                }
            }
        }

        static LinkedList<Page> Open(string file, int charPerPage = 3000)
        {
            Console.Title = Path.GetFileNameWithoutExtension(file);
            LinkedList<Page> pages = new LinkedList<Page>();
            var content = File.ReadAllText(file);
            var p = 0;
            for (p = 0; p < content.Length / charPerPage; p++)
            {
                var pageContent = content.Substring(charPerPage * p, charPerPage);
                pages.AddLast(new Page { Number = p + 1, Content = pageContent });
            }
            pages.AddLast(new Page { Number = p + 1, Content = content.Substring(charPerPage * p) });
            return pages;
        }
    }
}