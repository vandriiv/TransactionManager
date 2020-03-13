using TransactionManager.Domain.Enums;

namespace TransactionManager.Domain.Entities
{
    public class Transaction
    {
        public long Id { get; set; }
        public TransactionStatus Status { get; set; }
        public TransactionType Type { get; set; }
        public string ClientName { get; set; }
        public decimal Amount { get; set; }
    }
}
