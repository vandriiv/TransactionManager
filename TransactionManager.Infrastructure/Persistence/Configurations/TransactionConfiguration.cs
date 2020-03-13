using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransactionManager.Domain.Entities;
using TransactionManager.Domain.Enums;
using TransactionManager.Infrastructure.Persistence.Configurations.Converters;

namespace TransactionManager.Infrastructure.Persistence.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {     
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.ClientName)
                .HasColumnType("varchar(255)")                              
                .IsRequired();
                

            builder.Property(x => x.Amount)           
                .HasColumnType("decimal(38,18)");

            IValueConverterFactory valueConverterFactory = new ValueConverterFactory();

            var transactionStatusValueConverter = valueConverterFactory.CreateEnumToStringValueConverter<TransactionStatus>();
            builder.Property(x => x.Status)
                .HasConversion(transactionStatusValueConverter)
                .HasColumnType("varchar(50)");

            var transactionTypeValueConverter = valueConverterFactory.CreateEnumToStringValueConverter<TransactionType>();
            builder.Property(x => x.Type)
                .HasConversion(transactionTypeValueConverter)
                .HasColumnType("varchar(50)"); ;

        }
    }
}
