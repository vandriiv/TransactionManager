using System;
using System.Collections.Generic;
using System.Text;
using TransactionManager.Application.Transactions.Queries.ExportTransactions;

namespace TransactionManager.Application.Common.Interfaces
{
    public interface ICsvBuilder
    {
        public byte[] BuildTransactionsFile(IEnumerable<TransactionRecord> transactions);
    }
}
