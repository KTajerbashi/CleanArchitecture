using Library.Domain.Entity.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interface.Contexts
{
    public interface IDataBaseContext
    {
        //  هر موجودیت که در کانتکس اضافه میکنیم درین فایل هم اضافه میکنیم
        //  ازین پس برای استفاده از کانتکس از همین اینترفس استفاده میکنیم
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,CancellationToken cancellationToken = new CancellationToken());
    }
}
