using System;
using System.Collections.Generic;
using System.Text;

namespace capuli_MidtermAssignment
{
    public class Flights
    {
        private int _ID; //id
        private int _airlineID; //foreign id for flight information (Flight.cs)
        private string _departureCity;//Departure city
        private string _destinationCity;//Destination City
        private string _departureDate;//Departure date
        private double _flightTime;//length of the flight (hours)

        //Constructor
        public Flights(int iD, int airlineID, string departureCity, string destinationCity, string departureDate, double flightTime)
        {
            _ID = iD;
            _airlineID = airlineID;
            _departureCity = departureCity;
            _destinationCity = destinationCity;
            _departureDate = departureDate;
            _flightTime = flightTime;
        }

        //Properties (getters and setters)
        public int ID { get => _ID; set => _ID = value; }
        public int AirlineID { get => _airlineID; set => _airlineID = value; }
        public string DepartureCity { get => _departureCity; set => _departureCity = value; }
        public string DestinationCity { get => _destinationCity; set => _destinationCity = value; }
        public string DepartureDate { get => _departureDate; set => _departureDate = value; }
        public double FlightTime { get => _flightTime; set => _flightTime = value; }
    }
}
