using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Clean_Architecture.AuthenticationViewModel
{
    public class SignupViewModel
    {
        public string Name { get; set; } = "";
        public string Family { get; set; } = "";
        public  string Email{ get; set; }
        public  string Username{ get; set; }
        public  string Password{ get; set; }
        public  string RePassword{ get; set; }
     }
}
