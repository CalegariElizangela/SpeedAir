using SpeedAir.DTOs;

namespace SpeedAir.Repositories
{
    public interface IOrdersRepository
    {
        Dictionary<string, OrdersJsonDTO>? GetQueueOrders();
    }
}
