using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpeedAir.Repositories;
using SpeedAir.Services;

namespace SpeedAir
{
    public class Program
    {
        static void Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IFlightsRepository, FlightsRepository>();
                    services.AddSingleton<IOrdersRepository, OrdersRepository>();
                    services.AddSingleton<IApplicationService, ApplicationService>();
                    services.AddSingleton<IScheduleDatesService, ScheduleDatesService>();
                    services.AddSingleton<IScheduleOrdersService, ScheduleOrdersService>();
                })
                .Build();

            var app = host.Services.GetRequiredService<IApplicationService>();
            app.Run();
        }
    }
}