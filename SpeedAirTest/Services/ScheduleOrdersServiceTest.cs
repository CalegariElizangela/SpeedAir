using Moq;
using SpeedAir.DTOs;
using SpeedAir.Repositories;
using SpeedAir.Services;

namespace SpeedAirTest.Services
{
    [Trait("SpeedAirTest", "ScheduleOrdersServiceTest")]
    public class ScheduleOrdersServiceTest
    {
        private readonly IScheduleOrdersService scheduleOrdersService;
        private readonly Mock<IOrdersRepository> ordersRepositoryMock;

        public ScheduleOrdersServiceTest()
        {
            ordersRepositoryMock = new Mock<IOrdersRepository>();
            scheduleOrdersService = new ScheduleOrdersService(ordersRepositoryMock.Object);
        }

        [Fact]
        public void ShouldReturnScheduleOrdersSuccefully()
        {
            // Arrange
            var scheduledFlights = new List<ScheduledFlightsDTO> 
            { 
                new ScheduledFlightsDTO(1, GetYULAirport(), GetYYZAirport(), 1),
                new ScheduledFlightsDTO(2, GetYULAirport(), GetYYZAirport(), 1),
            };

            var orders = new Dictionary<string, OrdersJsonDTO>
            {
                { "Order 1", new OrdersJsonDTO() }
            };

            ordersRepositoryMock
                .Setup(s => s.GetQueueOrders())
                .Returns(orders);

            // Act
            scheduleOrdersService.ScheduleOrders(scheduledFlights);
        }

        [Fact]
        public void ShouldReturnScheduleOrdersException()
        {
            // Arrange
            var scheduledFlights = new List<ScheduledFlightsDTO>();

            var orders = new Dictionary<string, OrdersJsonDTO>();

            ordersRepositoryMock
                .Setup(s => s.GetQueueOrders())
                .Returns(orders);

            // Act
            // Assert
            Assert.Throws<Exception>(() =>
                scheduleOrdersService.ScheduleOrders(scheduledFlights));
        }

        private static AirportDTO GetYULAirport() => new("YUL", "Montreal airport");
        private static AirportDTO GetYYZAirport() => new("YYZ", "Toronto airport");
    }
}