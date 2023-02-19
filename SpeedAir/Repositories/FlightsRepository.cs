using SpeedAir.DTOs;

namespace SpeedAir.Repositories
{
    public class FlightsRepository : IFlightsRepository
    {
        public List<FlightsDTO> GetAllFlights() => new()
        {
            new FlightsDTO(1, "Montreal (YUL) to Toronto (YYZ)", GetYULAirport(), GetYYZAirport()),
            new FlightsDTO(2, "Montreal (YUL) to Calgary (YYC)", GetYULAirport(), GetYYCAirport()),
            new FlightsDTO(3, "Montreal (YUL) to Vancouver (YVR)", GetYULAirport(), GetYVRAirport()),
        };

        private AirportDTO GetYULAirport() => new("YUL", "Montreal airport");
        private AirportDTO GetYYZAirport() => new("YYZ", "Toronto airport");
        private AirportDTO GetYYCAirport() => new("YYC", "Calgari airport");
        private AirportDTO GetYVRAirport() => new("YVR", "Vancouver airport");
    }
}
