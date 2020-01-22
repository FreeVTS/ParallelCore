using System;
using System.Threading.Tasks;

namespace ParallelCore
{
    public class TParallel
    {
        public TParallel()
        {
            Init();
        }

        private async void Init()
        {
            var result = await CountToOneHundred();
            string a = "asdf";
        }

        private async Task<int> CountToOneHundred()
        {
            int accumulateur = 0;

            await Task.Run(() =>
           {
               int accu = 0;
               for (int i = 0; i < 100; i++)
               {
                   accu = i;
               }
               accumulateur = accu;
           });
            return accumulateur;
        }
    }
}