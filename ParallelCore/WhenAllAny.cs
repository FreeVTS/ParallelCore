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
        }


        private async Task<int> CreateRandomOne()
        {
            int result = 0;
            int accu = 0;
            int range = randSource.Next();

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
