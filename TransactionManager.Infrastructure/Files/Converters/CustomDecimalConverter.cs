using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace TransactionManager.Infrastructure.Files.Converters
{
    public class CustomDecimalConverter : DecimalConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            text = text.Substring(1);
            return base.ConvertFromString(text, row, memberMapData);
        }

        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
           return "$" + base.ConvertToString(value, row, memberMapData);
        }
    }
}
