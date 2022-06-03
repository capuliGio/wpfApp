using System;
using System.Collections.Generic;
using System.Text;

namespace capuli_MidtermAssignment
{
    public class Airlines
    {
        private int _ID; //id 
        private string _name;//Airline's name
        private string _airplane;//Name of the airplane
        private int _seatsAvailable;//Number of seats available 
        private string _mealAvailable;//Meals available in flight

        //Constructor
        public Airlines(int iD, string name, string airplane, int seatsAvailable, string mealAvailable)
        {
            _ID = iD;
            _name = name;
            _airplane = airplane;
            _seatsAvailable = seatsAvailable;
            _mealAvailable = mealAvailable;
        }
        
        //Properties (getters and setters)
        public int ID { get => _ID; set => _ID = value; }
        public string Name { get => _name; set => _name = value; }
        public string Airplane { get => _airplane; set => _airplane = value; }
        public int SeatsAvailable { get => _seatsAvailable; set => _seatsAvailable = value; }
        public string MealAvailable { get => _mealAvailable; set => _mealAvailable = value; }

    }
}
