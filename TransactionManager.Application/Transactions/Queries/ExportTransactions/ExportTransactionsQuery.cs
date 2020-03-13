using MediatR;
using TransactionManager.Application.Transactions.Enums;

namespace TransactionManager.Application.Transactions.Queries.ExportTransactions
{
    public class ExportTransactionsQuery : IRequest<ExportTransactionsModel>
    {
        public TransactionStatus? Status { get; set; }
        public TransactionType? Type { get; set; }
    }
}
