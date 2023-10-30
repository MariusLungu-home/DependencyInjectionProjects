using DIDemoLib;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Transactions;

namespace ConsoleUI
{
    public class Program
    { 
        public static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            using var messages = host.Services.CreateScope();
            
            var services = messages.ServiceProvider;

            try
            {
                services.GetRequiredService<App>().Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"And error has occured: {ex.Message}");
                Console.ReadLine();
            }

           
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                {
                    services.AddTransient<IMessages, Messages>();
                    services.AddTransient<App>();
                });

    }
}