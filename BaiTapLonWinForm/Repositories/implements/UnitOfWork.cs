using BaiTapLonWinForm.Data;
using BaiTapLonWinForm.Repositories.interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.implements
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IDbContextTransaction _transaction;

        // Constructor nhận DbContext từ DI Container
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            // Mở transaction từ EF Core
            _transaction = _context.Database.BeginTransaction();
        }

        public async Task CommitAsync()
        {
            try
            {
                // 1. Lưu các thay đổi xuống DB
                await _context.SaveChangesAsync();

                // 2. Nếu đang trong transaction thì Commit
                if (_transaction != null)
                {
                    await _transaction.CommitAsync();
                }
            }
            catch
            {
                // Nếu lỗi thì Rollback ngay lập tức
                await RollbackAsync();
                throw; // Ném lỗi ra để Service biết
            }
            finally
            {
                DisposeTransaction();
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                DisposeTransaction();
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private void DisposeTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            DisposeTransaction();
            // Không dispose _context ở đây vì DI Container sẽ tự quản lý vòng đời của nó
        }
    }
}
