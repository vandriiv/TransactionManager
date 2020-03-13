using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransactionManager.Application.Common.Interfaces;
using TransactionManager.Application.Common.Mappers;
using TransactionManager.Application.Transactions.Enums;
using TransactionManager.Domain.Entities;

namespace TransactionManager.Application.Transactions.Queries.ExportTransactions
{
    public class ExportTransactionsQueryHandler : IRequestHandler<ExportTransactionsQuery, ExportTransactionsModel>
    {
        private readonly ITransactionManagerDbContext _context;
        private readonly ICsvBuilder _csvBuilder;
        private readonly EnumMapper _enumMapper;

        public ExportTransactionsQueryHandler(ITransactionManagerDbContext context, ICsvBuilder csvBuilder, EnumMapper enumMapper)
        {
            _context = context;
            _csvBuilder = csvBuilder;
            _enumMapper = enumMapper;
        }

        public async Task<ExportTransactionsModel> Handle(ExportTransactionsQuery request, CancellationToken cancellationToken)
        {
            var exportTransactionModel = new ExportTransactionsModel();

            IQueryable<Transaction> queryable = _context.Transactions;

            if (request.Status.HasValue)
            {
                var status = _enumMapper.MapEnum<Domain.Enums.TransactionStatus, TransactionStatus>(request.Status.Value);
                queryable = queryable.Where(x => x.Status == status);
            }

            if (request.Type.HasValue)
            {
                var type = _enumMapper.MapEnum<Domain.Enums.TransactionType, TransactionType>(request.Type.Value);
                queryable = queryable.Where(x => x.Type == type);
            }

            var transactions = await queryable.Select(x => new TransactionRecord
            {
                Id = x.Id,
                Status = x.Status.ToString(),
                Type = x.Type.ToString(),
                ClientName = x.ClientName,
                Amount = x.Amount
            }).ToListAsync(cancellationToken);

            exportTransactionModel.Content = _csvBuilder.BuildTransactionsFile(transactions);
            exportTransactionModel.ContentType = "text/csv";
            exportTransactionModel.FileName = "Transactions.csv";

            return await Task.FromResult(exportTransactionModel);
        }
    }
}
