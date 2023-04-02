using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entity
{
    public class Privilege : IEntity
    {
        public int Id { get; set; }
        public bool Read { get; set; }
        public bool Write { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelted { get; set; }
    }
}
