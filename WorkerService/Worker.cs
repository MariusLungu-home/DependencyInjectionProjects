using DIDemoLib;

namespace WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMessages messages;

        public Worker(ILogger<Worker> logger, IMessages messages)
        {
            _logger = logger;
            this.messages = messages;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                _logger.LogError(messages.SayHello());
                _logger.LogError(messages.SayGoodbye());
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}