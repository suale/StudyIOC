namespace StudyIOC.Services
{
    public class ConsumerStarter : IHostedService
    {
        private static Consumer _consumer;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Thread t1 = new Thread(() =>
            {
                _consumer = new Consumer();
            });
            t1.Start();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }



}
