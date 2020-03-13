using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionManager.Application.Transactions.Enums
{
    public enum TransactionType :byte
    {
        Refill = 1,
        Withdrawal = 10
    }
}
