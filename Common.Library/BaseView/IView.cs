using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Library
{
    public interface IView
    {

    }
    public abstract class View<T> : IView
    {
        public T ID { get; set; }
    }
    public abstract class View : View<long>
    {

    }
    
}
