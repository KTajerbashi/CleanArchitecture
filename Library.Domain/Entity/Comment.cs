using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entity
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
        public bool IsDelted { get; set; }
    }
}
