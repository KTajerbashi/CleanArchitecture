using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entity
{
    public class Factor : IEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string SerialNumber { get; set; }
        public string TotalPrice { get; set; }
        public int Type { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelted { get; set; }
    }
}
