using SpeedAir.DTOs;

namespace SpeedAir.Services
{
    public interface IScheduleDatesService
    {
        List<ScheduledFlightsDTO> ScheduleDates(List<DateTime> scheduledDays);
    }
}
