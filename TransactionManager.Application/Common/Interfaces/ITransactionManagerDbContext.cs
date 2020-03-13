using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TransactionManager.Domain.Entities;

namespace TransactionManager.Application.Common.Interfaces
{
    public interface ITransactionManagerDbContext
    {
        public DbSet<Transaction> Transactions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
