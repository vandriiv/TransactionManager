using TransactionManager.Application.Transactions.Enums;

namespace TransactionManager.Application.Transactions.Commands.UpsertTransactions
{
    public class TransactionUpsertModel
    {
        public long Id { get; set; }
        public TransactionStatus Status { get; set; }
        public TransactionType Type { get; set; }
        public string ClientName { get; set; }
        public decimal Amount { get; set; }
    }
}
