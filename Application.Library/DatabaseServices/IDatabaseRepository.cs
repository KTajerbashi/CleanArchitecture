using Domain.Library.Entities.RPT;
using Domain.Library.Entities.SEC;
using Microsoft.EntityFrameworkCore;

namespace Application.Library.DatabaseServices
{
    public interface IDatabaseRepository
    {
        #region CNT
        #endregion
        #region LOG
        #endregion
        #region PRD
        #endregion
        #region RPT
        DbSet<UserReport> UserReports { get; set; }
        #endregion
        #region SEC
        //DbSet<User> Users { get; set; }
        //DbSet<Role> Roles { get; set; }
        //DbSet<UserRole> UserRoles { get; set; }
        #endregion

        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken));
    }
}
