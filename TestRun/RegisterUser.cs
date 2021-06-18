using System;
using System.Collections.Generic;
using System.Text;

namespace TestRun
{
    public class RegisteredUser
    {
        public string username { get; set; }
        public string first_name { get; set; }
        public string surname { get; set; }
        public string password { get; set; }
    }

    public class RootUser
    {
        public List<RegisteredUser> registered_users { get; set; } //creating a list with the RegisteredUser class containing the objects
    }

}
