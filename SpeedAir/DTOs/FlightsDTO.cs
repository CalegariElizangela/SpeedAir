namespace SpeedAir.DTOs
{
    public class FlightsDTO
    {
        public FlightsDTO(int id, string name, AirportDTO departureAirportId, AirportDTO destinationAirportId)
        {
            Id = id;
            Name = name;
            DepartureAirport = departureAirportId;
            DestinationAirport = destinationAirportId;
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public AirportDTO DepartureAirport { get; set; }
        public AirportDTO DestinationAirport { get; set; }
    }
}
