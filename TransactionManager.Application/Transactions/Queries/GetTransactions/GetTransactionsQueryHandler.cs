using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransactionManager.Application.Common.Interfaces;
using TransactionManager.Application.Common.Mappers;
using TransactionManager.Application.Transactions.Enums;
using TransactionManager.Domain.Entities;

namespace TransactionManager.Application.Transactions.Queries.GetTransactions
{
    public class GetTransactionsQueryHandler : IRequestHandler<GetTransactionsQuery, TransactionsEnvelope>
    {
        private readonly ITransactionManagerDbContext _context;
        private readonly EnumMapper _enumMapper;

        public GetTransactionsQueryHandler(ITransactionManagerDbContext context, EnumMapper enumMapper)
        {
            _context = context;
            _enumMapper = enumMapper;
        }

        public async Task<TransactionsEnvelope> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Transaction> queryable = _context.Transactions.AsNoTracking();
            if (request.Status.HasValue)
            {
                var status = _enumMapper.MapEnum<Domain.Enums.TransactionStatus, TransactionStatus>(request.Status.Value);
                queryable = queryable.Where(x =>x.Status == status);
            }

            if (request.Type.HasValue)
            {
                var type = _enumMapper.MapEnum<Domain.Enums.TransactionType, TransactionType>(request.Type.Value);
                queryable = queryable.Where(x => x.Type == type);
            }        
                     
            List<TransactionDto> transactions;
            if (request.Limit == 0)
            {

                transactions = await queryable.Skip(request.Offset)
                    .Select(x => new TransactionDto
                    {
                        Id = x.Id,
                        Status = x.Status.ToString(),
                        Type = x.Type.ToString(),
                        Amount = x.Amount,
                        ClientName = x.ClientName
                    }).ToListAsync(cancellationToken);
            }
            else
            {
                transactions = await queryable.Skip(request.Offset)
                    .Take(request.Limit)
                    .Select(x => new TransactionDto
                    {
                        Id = x.Id,
                        Status = x.Status.ToString(),
                        Type = x.Type.ToString(),
                        Amount = x.Amount,
                        ClientName = x.ClientName
                    }).ToListAsync(cancellationToken);
            }           

            var totalCount = queryable.Count();

            var envelope = new TransactionsEnvelope
            {
                TotalCount = totalCount,
                Transactions = transactions
            };

            return envelope;
        }
    }
}
