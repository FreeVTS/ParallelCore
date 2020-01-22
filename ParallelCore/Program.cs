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

            Console.Write("Enter your choice: ");
            var inputFrom = Console.ReadLine();
        }
    }
}
