using System;

namespace TransactionManager.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
                
        }
    }
}
