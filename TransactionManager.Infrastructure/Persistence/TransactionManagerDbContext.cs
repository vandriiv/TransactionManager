using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using TransactionManager.Application.Common.Interfaces;
using TransactionManager.Domain.Entities;

namespace TransactionManager.Infrastructure.Persistence
{
    public class TransactionManagerDbContext : DbContext, ITransactionManagerDbContext
    {
        public DbSet<Transaction> Transactions { get; set; }

        public TransactionManagerDbContext(DbContextOptions options) :base(options)
        {           
        }

        public TransactionManagerDbContext()
        {
          
        }       

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }       

        protected override void OnModelCreating(ModelBuilder builder)
        {                     
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
