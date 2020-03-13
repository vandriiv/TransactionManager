using System.Collections.Generic;
using System.IO;
using TransactionManager.Application.Transactions.Commands.UpsertTransactions;

namespace TransactionManager.Application.Common.Interfaces
{
    public interface ICsvParser
    {
        public IEnumerable<TransactionUpsertModel> ParseStreamToTransactionUpsertModels(Stream stream);
    }
}
