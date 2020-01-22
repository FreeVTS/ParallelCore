using System;
using System.Threading;

namespace ParallelCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            _ = new TParallel();
            string a = "aa";
            var inputFrom = Console.ReadLine();
        }
    }
}
