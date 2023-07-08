using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Library
{
    public class View<T> : IView
    {
        public T Id { get; set; }
    }
}
