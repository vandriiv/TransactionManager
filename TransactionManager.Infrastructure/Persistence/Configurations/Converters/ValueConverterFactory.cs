using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace TransactionManager.Infrastructure.Persistence.Configurations.Converters
{
    public class ValueConverterFactory : IValueConverterFactory
    {
        public ValueConverter<T, string> CreateEnumToStringValueConverter<T>() where T : Enum
        {
            return new ValueConverter<T, string>(
                    v => v.ToString(),
                    v => (T)Enum.Parse(typeof(T), v));
        }
    }
}
