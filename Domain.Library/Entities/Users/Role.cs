using Domain.Library.Bases.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Library.Entities
{
    public class Role : BaseEntity
    {
        public string Title { get; set; }
    }
}
