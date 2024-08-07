using EmailProvider.Oragnization.Models;
using System.Web.Services;

namespace EmailProvider.Oragnization.SOAPs
{
    /// <summary>
    /// Summary description for SendEmail_Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SendEmail_Service : System.Web.Services.WebService
    {

        [WebMethod]
        public EmailResult Send(EmailOption email)
        {
            return new EmailResult
            {
                ContactNumber = email.ContactNumber,
                IsSuccess = true
            };
        }

        [WebMethod]
        public EmailResult Recieve(int a, int b)
        {
            return new EmailResult
            {
                ContactNumber = $"{a} + {b} = {a + b}",
                IsSuccess = true
            };
        }
    }
}
