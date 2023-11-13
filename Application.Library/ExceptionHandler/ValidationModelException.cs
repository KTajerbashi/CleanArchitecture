using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Library.ExceptionHandler
{
    public class ValidationModelException : Exception
    {
        public ValidationModelException(string message) : base(message)
        {

        }
    }
    public class DatabaseException : Exception
    {
        public DatabaseException(string message) : base(message)
        {

        }
    }
    public class SystemModelException : Exception
    {
        public SystemModelException(string message):base(message)
        {
            
        }
    }
}
