using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using TransactionManager.Application.Transactions.Commands.UpsertTransactions;
using TransactionManager.Application.Transactions.Enums;
using TransactionManager.Infrastructure.Files.Converters;

namespace TransactionManager.Infrastructure.Files.Maps
{
    public class TransactionUpsertModelMap : ClassMap<TransactionUpsertModel>
    {
        public TransactionUpsertModelMap()
        {           
            Map(x => x.Id).Name("TransactionId");
            Map(x => x.ClientName);
            Map(x => x.Amount).TypeConverter(new CustomDecimalConverter());
            Map(x => x.Status).TypeConverter(new EnumConverter(typeof(TransactionStatus))); ;
            Map(x => x.Type).TypeConverter(new EnumConverter(typeof(TransactionType)));
        }
    }
}
