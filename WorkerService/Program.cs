using DIDemoLib;
using WorkerService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>()
                .AddTransient<IMessages, Messages>();
    })
    .Build();

await host.RunAsync();
