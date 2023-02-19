using SpeedAir.DTOs;
using SpeedAir.Repositories;

namespace SpeedAir.Services
{
    public static class ScheduleDatesService
    {
        public static void ScheduleDates(List<DateTime> scheduledDays)
        {
            var scheduledFlights = new List<ScheduledFlightsDTO>();
            var flights = FlightsRepository.GetAllFlights();
            var flightCount = 1;

            for (int day = 1; day <= scheduledDays.Count; day++)
            {
                foreach (var flight in flights)
                {
                    scheduledFlights.Add(new(flightCount, flight.DepartureAirport.Code, flight.DestinationAirport.Code, day));
                    Console.WriteLine($"Flight: {flightCount}, departure: {flight.DepartureAirport.Code}, arrival: {flight.DestinationAirport.Code}, day: {day}");
                    flightCount++;
                }
            }
            ScheduleOrdersService.ScheduleOrders(scheduledFlights);
        }
    }
}
