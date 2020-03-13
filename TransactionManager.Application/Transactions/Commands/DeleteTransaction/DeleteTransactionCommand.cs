using MediatR;

namespace TransactionManager.Application.Transactions.Commands.DeleteTransaction
{
    public class DeleteTransactionCommand : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}
