using SpeedAir.DTOs;
using SpeedAir.Extensions;
using SpeedAir.Repositories;

namespace SpeedAir.Services
{
    public static class ScheduleDatesService
    {
        public static void ScheduleDates(List<DateTime> scheduledDays)
        {
            var flights = FlightsRepository.GetAllFlights();
            if (flights == null)
            {
                SpeedWrite.WriteFlight();
                return;
            }

            var flightNumber = 1;
            var scheduledFlights = new List<ScheduledFlightsDTO>();
            for (int day = 1; day <= scheduledDays.Count; day++)
            {
                foreach (var flight in flights)
                {
                    SpeedWrite.WriteFlight(flightNumber, day, flight);
                    scheduledFlights.Add(new(flightNumber, flight.DepartureAirport, flight.DestinationAirport, day));
                    flightNumber++;
                }
            }
            ScheduleOrdersService.ScheduleOrders(scheduledFlights);
        }
    }
}
