using Newtonsoft.Json;
using SpeedAir.DTOs;
using SpeedAir.Extensions;

namespace SpeedAir.Services
{
    public static class ScheduleOrdersService
    {
        public static void ScheduleOrders(IList<ScheduledFlightsDTO> scheduledFlights)
        {
            var orders = ReadQueueOrders();
            if (orders == null)
            {
                Console.WriteLine("No orders in the queue...");
                return;
            }

            foreach (var order in orders)
            {
                var itinerary = scheduledFlights.FirstOrDefault(w => w.Destination.Code == order.Value.Destination && w.Box < w._maxBoxes);
                if (itinerary != null)
                {
                    itinerary.AddOneOrder();
                    SpeedWrite.WriteOrder(order.Key, itinerary);
                }
                else
                    SpeedWrite.WriteOrder(order.Key);
            }
        }

        private static Dictionary<string, OrdersJsonDTO>? ReadQueueOrders()
        {
            var jsonFile = File.ReadAllText(@"OrdersFiles\Orders.json");
            var orders = JsonConvert.DeserializeObject<Dictionary<string, OrdersJsonDTO>>(jsonFile);
            return orders;
        }
    }
}
