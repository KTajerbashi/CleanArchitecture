using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Pattern.Library.Facade.SubSystem.EmailContainer
{
    public class EmailService : IEmailRepository
    {
        public void Execute()
        {
            Console.WriteLine("Execute in EmailService");
        }
    }

}
