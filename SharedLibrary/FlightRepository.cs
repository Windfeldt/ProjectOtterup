using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedLibrary
{
    public class FlightRepository
    {
        private List<Flight> _flights = new List<Flight>
        {
            new Flight
            {
                FlightId = 1,
                FlightDestination = "Moon",
                FlightSeats = 2
            },
            new Flight
            {
                FlightId = 2,
                FlightDestination = "Norway",
                FlightSeats = 84
            },
            new Flight
            {
                FlightId = 6,
                FlightDestination = "Atlantis",
                FlightSeats = 42
            },

        };

        public FlightRepository()
        {

        }

        public List<Flight> GetFlights()
        {
            return _flights;
        }

        public Flight GetFlight(int id)
        {
            return (from s in _flights where s.FlightId == id select s).FirstOrDefault();
        }
    }
}