using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionManager.Application.Transactions.Queries.ExportTransactions
{
    public class ExportTransactionsModel
    {
        public string FileName { get; set; }

        public string ContentType { get; set; }

        public byte[] Content { get; set; }
    }
}
