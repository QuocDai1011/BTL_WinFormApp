using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Bắt đầu một giao dịch
        void BeginTransaction();

        // Lưu tất cả thay đổi xuống DB và Chốt giao dịch (Commit)
        Task CommitAsync();

        // Hoàn tác lại nếu có lỗi (Rollback)
        Task RollbackAsync();

        // Lưu thay đổi tạm thời (tương đương SaveChanges của EF)
        Task<int> SaveChangesAsync();
    }
}
