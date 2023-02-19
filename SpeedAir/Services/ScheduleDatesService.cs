using SpeedAir.DTOs;
using SpeedAir.Extensions;
using SpeedAir.Repositories;

namespace SpeedAir.Services
{
    public class ScheduleDatesService : IScheduleDatesService
    {
        private readonly IFlightsRepository flightsRepository;

        public ScheduleDatesService(IFlightsRepository flightsRepository)
        {
            this.flightsRepository = flightsRepository;
        }

        public List<ScheduledFlightsDTO> ScheduleDates(List<DateTime> scheduledDays)
        {
            var flights = flightsRepository.GetAllFlights();
            if (!flights.Any() || !scheduledDays.Any())
            {
                SpeedWrite.WriteFlight();
                throw new Exception(SpeedWrite.NoFlightsFounded);
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
            return scheduledFlights;
        }
    }
}
