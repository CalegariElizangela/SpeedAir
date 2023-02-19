using System.Text.Json.Serialization;

namespace SpeedAir.DTOs
{
    public class OrdersJsonDTO
    {
        [JsonPropertyName("destination")]
        public string Destination { get; set; } = string.Empty;
    }
}