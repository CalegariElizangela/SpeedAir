using SpeedAir.Services;

namespace SpeedAir
{
    public class Program
    {
        static void Main(string[] args)
        {
            ScheduleDatesService.ScheduleDates(new List<DateTime>
            {
                new DateTime(2023, 02, 01), 
                new DateTime(2023, 02, 02) 
            });
        }
    }
}