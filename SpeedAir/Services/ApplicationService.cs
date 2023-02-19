using Microsoft.Extensions.Logging;
using System.Reflection;

namespace SpeedAir.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IScheduleDatesService scheduleDatesService;
        private readonly IScheduleOrdersService scheduleOrdersService;
        private readonly ILogger<ApplicationService> logger;

        public ApplicationService(IScheduleDatesService scheduleDatesService,
            IScheduleOrdersService scheduleOrdersService,
            ILogger<ApplicationService> logger)
        {
            this.scheduleDatesService = scheduleDatesService;
            this.scheduleOrdersService = scheduleOrdersService;
            this.logger = logger;
        }

        public void Run()
        {
            logger.LogInformation("Starting");

            try
            {
                var scheduledFlights = scheduleDatesService.ScheduleDates(
                    new List<DateTime>
                    {
                        new DateTime(2023, 02, 01),
                        new DateTime(2023, 02, 02)
                    });

                scheduleOrdersService.ScheduleOrders(scheduledFlights);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error on {MethodBase.GetCurrentMethod()!.Name}, message: {ex.Message}");
                throw;
            }

            logger.LogInformation("Finishing");
        }
    }
}
