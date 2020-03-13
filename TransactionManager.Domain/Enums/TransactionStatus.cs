namespace TransactionManager.Domain.Enums
{
    public enum TransactionStatus : byte
    {
        Pending = 1,
        Completed = 10,
        Cancelled = 100
    }
}
