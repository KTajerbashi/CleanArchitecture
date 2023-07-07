using Domain.Library.Bases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Library.Bases.Services
{
    public class BaseEntity : IBaseEntity
    {
        public long Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
