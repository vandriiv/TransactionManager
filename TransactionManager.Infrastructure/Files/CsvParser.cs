using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using TransactionManager.Application.Common.Exceptions;
using TransactionManager.Application.Common.Interfaces;
using TransactionManager.Application.Transactions.Commands.UpsertTransactions;
using TransactionManager.Infrastructure.Files.Maps;

namespace TransactionManager.Infrastructure.Files
{
    public class CsvParser : ICsvParser
    {
        public IEnumerable<TransactionUpsertModel> ParseStreamToTransactionUpsertModels(Stream stream)
        {
            var transactions = new List<TransactionUpsertModel>();

            using var streamReader = new StreamReader(stream);
            using var csv = new CsvReader(streamReader, CultureInfo.InvariantCulture);

            csv.Configuration.RegisterClassMap<TransactionUpsertModelMap>();

            var record = new TransactionUpsertModel();

            try
            {
                var records = csv.EnumerateRecords(record);

                foreach (var r in records)
                {
                    transactions.Add(new TransactionUpsertModel
                    {
                        Id = r.Id,
                        Amount = r.Amount,
                        Status = r.Status,
                        ClientName = r.ClientName,
                        Type = r.Type
                    });
                }
            }
            catch(CsvHelperException exception)
            {
                var message = "";
                if (exception.ReadingContext.Row == 1)
                {
                    message = "Invalid header format";
                }
                else if (exception.ReadingContext.Row > 1)
                {
                    message = "Invalid row format";
                }

                throw new CsvFileReadException(message, exception.ReadingContext.Record, exception.ReadingContext.Row);
            }          

            return transactions;
        }
    }
}
