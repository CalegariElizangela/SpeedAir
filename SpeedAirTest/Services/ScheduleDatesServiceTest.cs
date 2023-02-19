using FluentAssertions;
using Moq;
using SpeedAir.DTOs;
using SpeedAir.Repositories;
using SpeedAir.Services;

namespace SpeedAirTest.Services
{
    [Trait("SpeedAirTest", "ScheduleDatesServiceTest")]
    public class ScheduleDatesServiceTest
    {
        private readonly IScheduleDatesService scheduleDatesService;
        private readonly Mock<IFlightsRepository> flightsRepositoryMock;

        public ScheduleDatesServiceTest()
        {
            flightsRepositoryMock = new Mock<IFlightsRepository>();
            scheduleDatesService = new ScheduleDatesService(flightsRepositoryMock.Object);
        }

        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 6)]
        [InlineData(5, 15)]
        public void ShouldReturnScheduleDatesSuccefully(int days, int schedule)
        {
            // Arrange
            var datesToSchedule = new List<DateTime>();
            var today = DateTime.Today;
            for (int i = 1; i <= days; i++)
            {
                datesToSchedule.Add(today.AddDays(i));
            }

            var flights = new List<FlightsDTO>
            {
                new FlightsDTO(1, "Montreal (YUL) to Toronto (YYZ)", GetYULAirport(), GetYYZAirport()),
                new FlightsDTO(2, "Montreal (YUL) to Calgary (YYC)", GetYULAirport(), GetYYCAirport()),
                new FlightsDTO(3, "Montreal (YUL) to Vancouver (YVR)", GetYULAirport(), GetYVRAirport()),
            };

            flightsRepositoryMock
                .Setup(s => s.GetAllFlights())
                .Returns(flights);

            // Act
            var response = scheduleDatesService.ScheduleDates(datesToSchedule);

            // Assert
            response.Should().HaveCount(schedule);
        }

        [Fact]
        public void ShouldReturnScheduleDatesException()
        {
            // Arrange
            var datesToSchedule = new List<DateTime>();

            flightsRepositoryMock
                .Setup(s => s.GetAllFlights())
                .Returns(new List<FlightsDTO>());

            // Act
            // Assert
            Assert.Throws<Exception>(() =>
                scheduleDatesService.ScheduleDates(datesToSchedule));
        }

        private static AirportDTO GetYULAirport() => new("YUL", "Montreal airport");
        private static AirportDTO GetYYZAirport() => new("YYZ", "Toronto airport");
        private static AirportDTO GetYYCAirport() => new("YYC", "Calgari airport");
        private static AirportDTO GetYVRAirport() => new("YVR", "Vancouver airport");
    }
}