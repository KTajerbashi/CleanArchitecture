using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Library
{
    public interface IDTO<T>
    {
        T ID { get; set; }
    }
    public abstract class DTO<T> : IDTO<T>
    {
        public T ID { set; get; }
    }
    public abstract class DTO : DTO<long>
    {

    }
}
