using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Library
{
    public interface IDTO
    {
    }
    public abstract class DTO<T> : IDTO
    {
        public T ID { get; set; }
    }
}
