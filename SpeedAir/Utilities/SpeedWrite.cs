using SpeedAir.DTOs;

namespace SpeedAir.Extensions
{
    public class SpeedWrite
    {
        public const string NoFlightsFounded = "No flights founded...";
        public const string NoOrdersFounded = "No orders founded in the queue...";

        public static void WriteFlight(int? flightNumber = null, int? day = null, FlightsDTO? flight = null)
        {
            if(flight != null)
                Console.WriteLine($"Flight: {flightNumber}, Departure: {flight.DepartureAirport.Code}, Arrival: {flight.DestinationAirport.Code}, Day: {day}");
            else
                Console.WriteLine(NoFlightsFounded);
        }

        public static void WriteOrder(string order, ScheduledFlightsDTO? itinerary = null)
        {
            if (itinerary != null)
                Console.WriteLine($"Order: {order}, FlightNumber: {itinerary.Flight}, Departure: {itinerary.Departure.Code}, Arrival: {itinerary.Destination.Code}, Day: {itinerary.Day}");
            else
                Console.WriteLine($"Order: {order}, FlightNumber: not scheduled");
        }
    }
}
