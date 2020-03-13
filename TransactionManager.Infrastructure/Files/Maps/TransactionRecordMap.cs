using CsvHelper.Configuration;
using TransactionManager.Application.Transactions.Queries.ExportTransactions;
using TransactionManager.Infrastructure.Files.Converters;

namespace TransactionManager.Infrastructure.Files.Maps
{
    public class TransactionRecordMap : ClassMap<TransactionRecord>
    {
        public TransactionRecordMap()
        {
            Map(x => x.Id).Name("TransactionId");
            Map(x => x.Status);
            Map(x => x.Type);
            Map(x => x.ClientName);
            Map(x => x.Amount).TypeConverter(new CustomDecimalConverter());           
        }
    }
}
