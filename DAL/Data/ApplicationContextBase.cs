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
        public ApplicationContextBase(DbContextOptions<ApplicationContextBase> Options) : base(Options) { }

    }
}
