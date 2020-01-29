using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParallelCore
{
    public class WhenAllAny
    {
        readonly Random randSource = new Random();

        public WhenAllAny()
        {
            InitAllTask();
        }

        private async void InitAllTask()
        {
            var randomOneTask = CreateRandomOne();
            var randomTwoTask = CreateRandomTwo();
            var taskList = new List<Task<int>>
            {
                randomOneTask,
                randomTwoTask
            };

            var result = await Task.WhenAll(taskList);

            Console.Write("\n");
            foreach (var number in result)
            {
                Console.WriteLine("One number collected is {0}", number);
            }
        }

        private async Task<int> CreateRandomOne()
        {
            int result = 0;
            int accu = 0;
            int range = randSource.Next();
            Console.WriteLine("Task One will run for {0} loop", range);

            await Task.Run(() =>
            {
                while (accu < range )
                {
                    result = accu;
                    accu++;
                }
            }).ConfigureAwait(true);
            Console.WriteLine("CreateRandomOne finish with number {0}", result);
            return result;
        }

        private async Task<int> CreateRandomTwo()
        {
            int result = 0;
            int accu = 0;
            int range = randSource.Next();
            Console.WriteLine("Task Two will run for {0} loop", range);

            await Task.Run(() =>
            {
                while (accu < range)
                {
                    result = accu;
                    accu++;
                }
            }).ConfigureAwait(true);
            Console.WriteLine("CreateRandomTwo finish with number {0}", result);
            return result;
        }
    }
}
