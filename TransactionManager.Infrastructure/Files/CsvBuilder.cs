using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using TransactionManager.Application.Common.Interfaces;
using TransactionManager.Application.Transactions.Queries.ExportTransactions;
using TransactionManager.Infrastructure.Files.Maps;

namespace TransactionManager.Infrastructure.Files
{
    public class CsvBuilder : ICsvBuilder
    {
        public byte[] BuildTransactionsFile(IEnumerable<TransactionRecord> transactions)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
                csvWriter.Configuration.RegisterClassMap<TransactionRecordMap>();

                csvWriter.WriteRecords(transactions);
            }

            return memoryStream.ToArray();
        }
    }
}
