using MediatR;
using System.Collections.Generic;

namespace TransactionManager.Application.Transactions.Commands.UpsertTransactions
{
    public class UpsertTransactionsCommand : IRequest<Unit>
    {
        public IEnumerable<TransactionUpsertModel> Transactions { get; set; }
    }
}
