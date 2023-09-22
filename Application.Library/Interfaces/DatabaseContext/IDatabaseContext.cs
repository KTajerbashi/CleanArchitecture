using Domain.Library.Entities.SEC;
using Microsoft.EntityFrameworkCore;

namespace Application.Library.Interfaces
{
    public interface IDatabaseContext:IDisposable
    {
        #region SEC
        DbSet<Person> People { get; set; }
        DbSet<Picture> Pictures { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<PictureLocation> PictureLocations { get; set; }
        DbSet<Privilege> Privileges { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<PersonRole> PersonRoles { get; set; }
        #endregion



        //  For Save Data in Database by this interface use these methods
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
