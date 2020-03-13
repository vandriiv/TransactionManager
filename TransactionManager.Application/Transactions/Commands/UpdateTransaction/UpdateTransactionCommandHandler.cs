using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TransactionManager.Application.Common.Exceptions;
using TransactionManager.Application.Common.Interfaces;
using TransactionManager.Application.Common.Mappers;
using TransactionManager.Application.Transactions.Enums;

namespace TransactionManager.Application.Transactions.Commands.UpdateTransaction
{
    public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand>
    {
        private readonly ITransactionManagerDbContext _context;
        private readonly EnumMapper _enumMapper;

        public UpdateTransactionCommandHandler(ITransactionManagerDbContext context, EnumMapper enumMapper)
        {
            _context = context;
            _enumMapper = enumMapper;
        }

        public async Task<Unit> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _context.Transactions.FindAsync(request.Id);
            if(transaction == null)
            {
                throw new NotFoundException($"Transaction with Id {request.Id} not found.");
            }
            
            var mappedStatus = _enumMapper.MapEnum<Domain.Enums.TransactionStatus, TransactionStatus>(request.Status);
            if (transaction.Status!=mappedStatus)
            {
                transaction.Status = mappedStatus;
                await _context.SaveChangesAsync(cancellationToken);
            }            
          
            return Unit.Value;
        }
    }
}
