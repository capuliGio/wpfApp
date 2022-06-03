using System;
using System.Collections.Generic;
using System.Text;

namespace capuli_MidtermAssignment
{
    public class Logins
    {
        private int _ID;//id
        private string _username;//username
        private string _password;//password
        private int _superUser;//superuser 1 (have add/update/delete access)/superuser 0 (don't have add/update/delete access)

        //Constructor
        public Logins(int iD, string username, string password, int superUser)
        {
            _ID = iD;
            _username = username;
            _password = password;
            _superUser = superUser;
        }

        //Properties (getters and setters)
        public int ID { get => _ID; set => _ID = value; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public int SuperUser { get => _superUser; set => _superUser = value; }
    }
}
