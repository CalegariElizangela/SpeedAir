using SpeedAir.DTOs;
using SpeedAir.Extensions;
using SpeedAir.Repositories;

namespace SpeedAir.Services
{
    public class ScheduleOrdersService : IScheduleOrdersService
    {
        private readonly IOrdersRepository ordersRepository;

        public ScheduleOrdersService(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public void ScheduleOrders(IList<ScheduledFlightsDTO> scheduledFlights)
        {
            var orders = ordersRepository.GetQueueOrders();
            if (orders == null || !scheduledFlights.Any())
            {
                throw new Exception(SpeedWrite.NoOrdersFounded);
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
    }
}
