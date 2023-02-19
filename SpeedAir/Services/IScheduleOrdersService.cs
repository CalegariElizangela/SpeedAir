using Newtonsoft.Json;
using SpeedAir.DTOs;
using SpeedAir.Extensions;

namespace SpeedAir.Services
{
    public interface IScheduleOrdersService
    {
        void ScheduleOrders(IList<ScheduledFlightsDTO> scheduledFlights);
    }
}
