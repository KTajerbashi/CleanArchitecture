using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class ApplicationContextBase : DbContext
    {
        private ApplicationContextBase context;

        public ApplicationContextBase()
        {
        }

        public ApplicationContextBase(DbContextOptions<ApplicationContextBase> Options) : base(Options) { }

        public ApplicationContextBase(ApplicationContextBase context)
        {
            this.context = context;
        }
    }
}
