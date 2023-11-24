using Identity.Library.Models;
using System.Security.Claims;

namespace Identity.Library.Config
{
    public class ConfigIdentity
    {
        public static ResultModel<List<User>> GetAllUsers()
        {
            return new ResultModel<List<User>>
            {
                Data = new List<User>
                {
                    new User
                    {
                        SubjectId = "E645EFB2-6455-4F91-A43C-D82BAF0C860D",
                        Username = "Tajerbashi",
                        Password = "456456",
                        Claims = new List<Claim>
                        {
                            new Claim("Name","Kamran"),
                            new Claim("UserName","Tajerbashi"),
                            new Claim("SSN","00989020320844"),
                            new Claim("Address","MSHD,IRAN"),
                            new Claim("Role","ADMIN"),
                        },
                    },
                    new User
                    {
                        SubjectId = "3C85395D-C724-46E4-B435-5B121F8B703C",
                        Username = "Mirzaie",
                        Password = "123123",
                        Claims = new List<Claim>
                        {
                            new Claim("Name","Farhad"),
                            new Claim("UserName","Mirzaie"),
                            new Claim("SSN","00989020320844"),
                            new Claim("Address","MSHD,IRAN"),
                            new Claim("Role","OPERATOR"),
                        },
                    },
                    new User
                    {
                        SubjectId = "252E65F1-E2FA-4D19-8D1C-921D612FFCA0",
                        Username = "Karimi",
                        Password = "789789",
                        Claims = new List<Claim>
                        {
                            new Claim("Name","Ali"),
                            new Claim("UserName","Karimi"),
                            new Claim("SSN","00989020320844"),
                            new Claim("Address","MSHD,IRAN"),
                            new Claim("Role","USER"),
                        },
                    },
                    new User
                    {
                        SubjectId = "A260C7C1-98F7-4658-AA9C-29EE7175329B",
                        Username = "Mohammadi",
                        Password = "852852",
                        Claims = new List<Claim>
                        {
                            new Claim("Name","Behnam"),
                            new Claim("UserName","Mohammadi"),
                            new Claim("SSN","00989020320844"),
                            new Claim("Address","MSHD,IRAN"),
                            new Claim("Role","ADMIN"),
                        },
                    },


                },
                Message = "",
                StatusCode = 200
            };
        }
    }
}
