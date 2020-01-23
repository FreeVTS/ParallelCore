using System.Threading.Tasks;

namespace ParallelCore
{
    public class TParallel
    {
        public TParallel()
        {
            Init();
        }

        ///
        /// Just a comment
        public int LastResult { get; set; }

        private async void Init()
        {
            var result = await CountToOneHundred();
            LastResult = result;
        }

        private async Task<int> CountToOneHundred()
        {
            int accumulateur = 0;

            var un = Task.Run(() =>
           {
               int accu = 0;
               for (int i = 0; i < 100; i++)
               {
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
                    acculocal = i;
                }
                accumulateur = acculocal;
            });
            return accumulateur;
        }
    }
}