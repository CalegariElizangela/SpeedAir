namespace SpeedAir.DTOs
{
    public class ScheduledFlightsDTO
    {
        public int _maxBoxes = 20;
        private int _box = 0;

        public ScheduledFlightsDTO(int flight, AirportDTO departure, AirportDTO destination, int day)
        {
            Flight = flight;
            Departure = departure;
            Destination = destination;
            Day = day;
        }

        public int Flight { get; set; }
        public AirportDTO Departure { get; set; } 
        public AirportDTO Destination { get; set; }
        public int Day { get; set; }
        public int Box
        {
            get { return _box; }
            set
            {
                _box = Math.Min(_maxBoxes, value);
            }
        }

        internal void AddOneOrder()
        {
            _box++;
        }
    }
}