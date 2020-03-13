using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionManager.Application.Transactions.Enums
{
    public enum TransactionStatus : byte
    {
        Pending = 1,
        Completed = 10,
        Cancelled = 100
    }
}
