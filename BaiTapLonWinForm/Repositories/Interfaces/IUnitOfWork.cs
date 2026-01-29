using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();

        Task CommitAsync();

        Task RollbackAsync();

        Task<int> SaveChangesAsync();

        bool HasActiveTransaction { get; }
    }
}