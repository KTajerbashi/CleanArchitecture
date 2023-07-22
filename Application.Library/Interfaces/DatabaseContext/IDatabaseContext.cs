using Microsoft.EntityFrameworkCore;

namespace Application.Library.Interfaces
{
    public interface IDatabaseContext
    {
        //  For Save Data in Database by this interface use these methods
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
