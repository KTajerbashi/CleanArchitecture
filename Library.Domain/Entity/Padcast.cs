using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entity
{
    public class Padcast : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string File { get; set; }
        public string Picture { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelted { get; set; }
    }
}
