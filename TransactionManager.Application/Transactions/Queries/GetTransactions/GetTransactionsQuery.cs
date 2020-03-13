using MediatR;
using TransactionManager.Application.Transactions.Enums;

namespace TransactionManager.Application.Transactions.Queries.GetTransactions
{
    public class GetTransactionsQuery : IRequest<TransactionsEnvelope>
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
        public TransactionStatus? Status { get; set; }
        public TransactionType? Type { get; set; }
    }
}
