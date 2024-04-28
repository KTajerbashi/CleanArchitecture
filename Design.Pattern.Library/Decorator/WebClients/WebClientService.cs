using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Design.Pattern.Library.Decorator.WebClients
{
    public class WebClientService
    {
        public void Execute()
        {
            WebClient client =  new();
            WebClientComponent webClient = new(client);
            string source = webClient.DownloadString("https://www.google.com");
            Console.WriteLine(source);
        }
    }

    public class WebClientComponent : WebClient
    {
        private readonly WebClient webClient;

        public WebClientComponent(WebClient webClient)
        {
            this.webClient = webClient;
        }
        public string DownloadString(string address)
        {
            if (address.StartsWith("https://bugeto.net"))
            {
                return webClient.DownloadString(address);
            }
            return string.Empty;
        }
    }

}
