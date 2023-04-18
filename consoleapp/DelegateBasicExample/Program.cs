using System;
using System.IO;

namespace DelegateBasicExample
{

    class Program
    {
        delegate void LogDel(string text);

        static void Main(string[] args)
        {
            Log log = new Log();
            //LogDel logDel = new LogDel(log.LogTextToFile);
            LogDel logTextToScreenDel, logTextToFileDel;
            logTextToFileDel = new LogDel(log.LogTextToFile);
            logTextToScreenDel = new LogDel(log.LogTextToScreen);

            LogDel multiLogDel = logTextToFileDel + logTextToScreenDel;

            Console.WriteLine("Input your name");
            var name = Console.ReadLine();

            //logDel(name);
            //multiLogDel(name);
            LogText(multiLogDel, name);
            //LogText(logTextToScreenDel, name);

        }

        static void LogText(LogDel logDel, string text)
        {
            logDel(text);
        }
        

        // 
        //static void LogTextToScreen(string text)
        //{
        //    Console.WriteLine($"{DateTime.Now}: {text}");
        //}

        //static void LogTextToFile(string text)
        //{
        //    using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt")))
        //    {
        //        sw.WriteLine($"{DateTime.Now}: {text}");
        //    }
        //}

    }

    public class Log
    {
        public void LogTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }

        public void LogTextToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now}: {text}");
            }
        }
    }
}
