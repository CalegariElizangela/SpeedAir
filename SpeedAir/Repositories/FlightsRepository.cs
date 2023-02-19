using SpeedAir.DTOs;

namespace SpeedAir.Repositories
{
    public static class FlightsRepository
    {
        public static List<FlightsDTO> GetAllFlights() => new()
        {
            new FlightsDTO(1, "Montreal (YUL) to Toronto (YYZ)", GetYULAirport(), GetYYZAirport()),
            new FlightsDTO(2, "Montreal (YUL) to Calgary (YYC)", GetYULAirport(), GetYYCAirport()),
            new FlightsDTO(3, "Montreal (YUL) to Vancouver (YVR)", GetYULAirport(), GetYVRAirport()),
        };

        private static AirportDTO GetYULAirport() => new(1, "YUL", "Montreal airport");
        private static AirportDTO GetYYZAirport() => new(1, "YYZ", "Toronto airport");
        private static AirportDTO GetYYCAirport() => new(1, "YYC", "Calgari airport");
        private static AirportDTO GetYVRAirport() => new(1, "YVR", "Vancouver airport");
    }
}
