namespace SpeedAir.DTOs
{
    public class AirportDTO
    {
        public AirportDTO(int id, string code, string name)
        {
            Id = id;
            Code = code;
            Name = name;
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}