using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransactionManager.Application.Common.Interfaces;
using TransactionManager.Application.Common.Mappers;
using TransactionManager.Application.Transactions.Enums;
using TransactionManager.Domain.Entities;

namespace TransactionManager.Application.Transactions.Commands.UpsertTransactions
{
    public class UpsertTransactionsCommandHandler : IRequestHandler<UpsertTransactionsCommand, Unit>
    {
        private readonly ITransactionManagerDbContext _context;
        private readonly EnumMapper _enumMapper;

        public UpsertTransactionsCommandHandler(ITransactionManagerDbContext context, EnumMapper enumMapper)
        {
            _context = context;
            _enumMapper = enumMapper;
        }

        public async Task<Unit> Handle(UpsertTransactionsCommand request, CancellationToken cancellationToken)
        {
            var mappedTransactions = request.Transactions.Select(x =>
                                new Transaction
                                {
                                    Id = x.Id,
                                    Status = _enumMapper.MapEnum<Domain.Enums.TransactionStatus, TransactionStatus>(x.Status),
                                    Type = _enumMapper.MapEnum<Domain.Enums.TransactionType, TransactionType>(x.Type),
                                    ClientName = x.ClientName,
                                    Amount = x.Amount
                                });

            var toInsert = mappedTransactions.Where(x => !_context.Transactions.Any(entity => entity.Id == x.Id)).ToList();
            var toUpdate = mappedTransactions.Where(x => !toInsert.Any(i => i.Id == x.Id)).ToList();

            if (toInsert.Any())
            {
                await _context.Transactions.AddRangeAsync(toInsert);
            }

            if (toUpdate.Any())
            {
                _context.Transactions.UpdateRange(toUpdate);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
