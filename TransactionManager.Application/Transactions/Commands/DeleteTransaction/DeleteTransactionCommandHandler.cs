using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TransactionManager.Application.Common.Exceptions;
using TransactionManager.Application.Common.Interfaces;

namespace TransactionManager.Application.Transactions.Commands.DeleteTransaction
{
    public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand, Unit>
    {
        private readonly ITransactionManagerDbContext _context;

        public DeleteTransactionCommandHandler(ITransactionManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _context.Transactions.FindAsync(request.Id);
            if (transaction == null)
            {
                throw new NotFoundException($"Transaction with Id {request.Id} not found.");
            }

            _context.Transactions.Remove(transaction);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
