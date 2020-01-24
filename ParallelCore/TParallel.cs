using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelCore
{
    public class TParallel
    {
        CancellationTokenSource cancellationTokenSource = null;
        public TParallel()
        {
            Init();
        }

        ///
        /// Just a comment
        public int LastResult { get; set; }

        private async void Init()
        {
            cancellationTokenSource = new CancellationTokenSource();
            var rand = new Random();
            var number = rand.Next(0, 2);
            if (number == 0)
                cancellationTokenSource.Cancel();

            cancellationTokenSource.Token.Register(() =>
            {
                LastResult = 50;
                Console.WriteLine("CancellationToken has been cancelled");
            });

            var result = await CountToOneHundred(cancellationTokenSource.Token);

            if (number != 0)
                LastResult = result;
        }

        private async Task<int> CountToOneHundred(CancellationToken cancellationToken)
        {
            int accumulateur = 0;

            var un = Task.Run(() =>
           {
               int accu = 0;
               for (int i = 0; i < 100; i++)
               {
                   if (cancellationToken.IsCancellationRequested)
                       continue;
                   accu = i;
               }
               accumulateur = accu;
           });

            var deux = un.ContinueWith(t =>
           {
               int accu = accumulateur;
               int acculocal = 0;
               for (int i = 0; i < 200; i++)
               {
                   if (cancellationToken.IsCancellationRequested)
                       continue;
                   acculocal = i;
               }
               accumulateur = acculocal;
           });

            await deux.ContinueWith(t =>
            {
                int accu = accumulateur;
                int acculocal = 0;
                for (int i = 0; i < 300; i++)
                {
                   if (cancellationToken.IsCancellationRequested)
                       continue;
                    acculocal = i;
                }
                accumulateur = acculocal;
            });
            return accumulateur;
        }
    }
}