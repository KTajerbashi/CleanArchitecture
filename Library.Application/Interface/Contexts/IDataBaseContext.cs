using Library.Domain;
using Library.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Library.Application
{
    public interface IDataBaseContext
    {
        //  هر موجودیت که در کانتکس اضافه میکنیم درین فایل هم اضافه میکنیم
        //  ازین پس برای استفاده از کانتکس از همین اینترفس استفاده میکنیم
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }

        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
