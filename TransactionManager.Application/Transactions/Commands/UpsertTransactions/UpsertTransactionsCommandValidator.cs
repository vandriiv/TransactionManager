using FluentValidation;

namespace TransactionManager.Application.Transactions.Commands.UpsertTransactions
{
    public class UpsertTransactionsCommandValidator : AbstractValidator<UpsertTransactionsCommand>
    {
        public UpsertTransactionsCommandValidator()
        {           
            RuleFor(x => x.Transactions).NotNull();
            
            /*RuleForEach(x => x.Transactions)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .SetValidator(new TransactionUpsertModelValidator()); */           
              
        }
    }
}
