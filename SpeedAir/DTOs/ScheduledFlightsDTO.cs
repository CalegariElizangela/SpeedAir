namespace SpeedAir.DTOs
{
    public class ScheduledFlightsDTO
    {
        public int _maxBoxes = 20;
        private int _box = 0;

        public ScheduledFlightsDTO(int flight, string departure, string destination, int day)
        {
            Flight = flight;
            Departure = departure;
            Destination = destination;
            Day = day;
        }

        public int Flight { get; set; }
        public string Departure { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
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