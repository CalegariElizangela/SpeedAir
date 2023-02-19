using Newtonsoft.Json;
using SpeedAir.DTOs;

namespace SpeedAir.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        public Dictionary<string, OrdersJsonDTO>? GetQueueOrders()
        {
            var jsonFile = File.ReadAllText(@"OrdersFiles\Orders.json");
            var orders = JsonConvert.DeserializeObject<Dictionary<string, OrdersJsonDTO>>(jsonFile);
            return orders;
        }
    }
}
