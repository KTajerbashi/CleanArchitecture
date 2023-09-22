using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Library.Interfaces.Patterns.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void SaveChangesAsync();
        void CommitTransaction();
        void Rollback();
    }
}
