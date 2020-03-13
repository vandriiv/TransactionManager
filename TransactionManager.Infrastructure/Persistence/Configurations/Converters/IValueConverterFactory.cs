using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace TransactionManager.Infrastructure.Persistence.Configurations.Converters
{
    public interface IValueConverterFactory
    {
        public ValueConverter<T, string> CreateEnumToStringValueConverter<T>() where T : Enum;
    }
}
