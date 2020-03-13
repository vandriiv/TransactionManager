namespace TransactionManager.Application.Transactions.Queries.ExportTransactions
{
    public class TransactionRecord
    {
        public long Id { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string ClientName { get; set; }
        public decimal Amount { get; set; }
    }
}
