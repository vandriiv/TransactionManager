using System;

namespace TransactionManager.Application.Common.Exceptions
{
    public class CsvFileReadException:Exception
    {
        public CsvFileReadException(string message,string[] record, int row):base(message)
        {
            Record = record;
            Row = row;
        }

        public string[] Record { get; set; }
        public int Row { get; set; }
    }
}
