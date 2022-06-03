using System;
using System.Collections.Generic;
using System.Text;

namespace capuli_MidtermAssignment
{
    public class Passenger
    {
        private int _ID;//id
        private int _customerID;//foreign key for customer information (Customer.cs)
        private int _flightID;//foreign key for flight informaiton (Flights.cs)

        //Constructor
        public Passenger(int iD, int customerID, int flightID)
        {
            _ID = iD;
            _customerID = customerID;
            _flightID = flightID;
        }

        //Properties (getters and setters)
        public int ID { get => _ID; set => _ID = value; }
        public int CustomerID { get => _customerID; set => _customerID = value; }
        public int FlightID { get => _flightID; set => _flightID = value; }
    }
}
