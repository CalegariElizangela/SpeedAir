using SpeedAir.DTOs;

namespace SpeedAir.Repositories
{
    public interface IFlightsRepository
    {
        List<FlightsDTO> GetAllFlights();
    }
}
