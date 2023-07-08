using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Library
{
    public class Dto<T> : IDto
    {
        public T Id { get; set; }
    }
}
