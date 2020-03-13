using FluentValidation.Results;
using System.Collections.Generic;

namespace TransactionManager.Application.Common.Exceptions
{
    public class FileRecordsValidationException : ValidationException
    {
        public int Row { get; set; }
        public FileRecordsValidationException(int row, IEnumerable<ValidationFailure> failures) :base(failures)
        {
            Row = row;
        }
    }
}
