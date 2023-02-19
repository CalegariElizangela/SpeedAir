using Newtonsoft.Json;
using SpeedAir.DTOs;

namespace SpeedAir.Services
{
    public static class ScheduleOrdersService
    {
        public static void ScheduleOrders(IList<ScheduledFlightsDTO> scheduledFlights)
        {
            var jsonFile = File.ReadAllText(@"OrdersFiles\Orders.json");
            var orders = JsonConvert.DeserializeObject<Dictionary<string, OrdersJsonDTO>>(jsonFile);
            if (orders == null)
            {
                Console.WriteLine("No orders in the queue...");
                return;
            }

            foreach (var order in orders)
            {
                var itinerary = scheduledFlights.FirstOrDefault(w => w.Destination == order.Value.Destination && w.Box < w._maxBoxes);
                if (itinerary != null)
                {
                    itinerary.AddOneOrder();
                    Console.WriteLine($"Order: {order.Key}, FlightNumber: {itinerary.Flight}, Departure: {itinerary.Departure}, Arrival: {itinerary.Destination}, Day: {itinerary.Day}");
                }
                else
                {
                    Console.WriteLine($"Order: {order.Key}, FlightNumber: not scheduled");
                }
            }
        }
    }
}
