using BookingAppDio.Core.ModelsAggregate;

namespace BookingAppDio.Flight.Domain.Flights.Models;

public class Flight : Aggregate<long>
{
    public string FlightNumber { get; private set; }
    public long AircraftId { get; private set; }
    public DateTime DepartureDate { get; private set; }
    public long DepartureAirportId { get; private set; }
    public DateTime ArriveDate { get; private set; }
    public long ArriveAirportId { get; private set; }
    public decimal DurationMinutes { get; private set; }
    public DateTime FlightDate { get; private set; }
    public FlightStatus Status { get; private set; }
    public decimal Price { get; private set; }
}