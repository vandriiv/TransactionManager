using FluentValidation;

namespace TransactionManager.Application.Transactions.Commands.UpsertTransactions
{
    public class TransactionUpsertModelValidator : AbstractValidator<TransactionUpsertModel>
    {
        public TransactionUpsertModelValidator()        
        {          
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.ClientName).NotNull().NotEmpty().MaximumLength(255);
            RuleFor(x => x.Status).NotEmpty();
            RuleFor(x => x.Type).NotEmpty();            
        }
    }
}