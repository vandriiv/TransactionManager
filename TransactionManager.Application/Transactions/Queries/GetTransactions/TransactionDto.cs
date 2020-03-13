
namespace TransactionManager.Application.Transactions.Queries.GetTransactions
{
    public class TransactionDto
    {
        public long Id { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string ClientName { get; set; }
        public decimal Amount { get; set; }
    }
}
