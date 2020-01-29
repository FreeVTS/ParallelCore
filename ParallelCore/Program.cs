using System;
using System.Threading;

namespace ParallelCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var Par = new TParallel();

            Console.Write("Enter your choice: ");
            var inputFrom = Console.ReadLine();
            Console.WriteLine(Par.LastResult);
            Console.Write("\n");

            // Test WhenAllAny
            _ = new WhenAllAny();
            Console.Write("\n");
            Console.WriteLine("Wait for loop to compute");
            Console.ReadLine();
        }
    }
}
