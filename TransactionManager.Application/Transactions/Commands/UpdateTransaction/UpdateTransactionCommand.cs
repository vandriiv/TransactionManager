using MediatR;
using TransactionManager.Application.Transactions.Enums;

namespace TransactionManager.Application.Transactions.Commands.UpdateTransaction
{
    public class UpdateTransactionCommand : IRequest<Unit>
    {
        public long Id { get; set; }
        public TransactionStatus Status { get; set; }        
    } 
}
