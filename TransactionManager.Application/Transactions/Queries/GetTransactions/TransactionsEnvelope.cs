using System.Collections.Generic;

namespace TransactionManager.Application.Transactions.Queries.GetTransactions
{
    public class TransactionsEnvelope
    {
        public IEnumerable<TransactionDto> Transactions { get; set; }
        public int TotalCount { get; set; }
    }
}
