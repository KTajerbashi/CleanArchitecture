using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entity
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public double Price { get; set; }
        public int Sell { get; set; }
        public int Buy { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; }
        public DateTime Publish { get; set; }
        public string Details { get; set; }
        public string Categroi { get; set; }
        public int Pages { get; set; }
        public List<string> Pictures { get; set; }
        public string File { get; set; }
        public int Scores { get; set; }
        public int Visits { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelted { get; set; }


        public Author Author { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
