using System;
using System.Collections.Generic;
using System.Text;

namespace capuli_MidtermAssignment
{
    public class Customer
    {
        private int _ID; //id
        private string _name; //Customer's name
        private string _address; //Customer's address
        private string _email; //Customer's email
        private string _phone; //Customer's phone number

        //Constructor
        public Customer(int iD, string name, string address, string email, string phone)
        {
            _ID = iD;
            _name = name;
            _address = address;
            _email = email;
            _phone = phone;
        }

        //Properties (getters and setters)
        public int ID { get => _ID; set => _ID = value; }
        public string Name { get => _name; set => _name = value; }
        public string Address { get => _address; set => _address = value; }
        public string Email { get => _email; set => _email = value; }
        public string Phone { get => _phone; set => _phone = value; }
    }
}
