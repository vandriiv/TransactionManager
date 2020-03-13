using FluentValidation;

namespace TransactionManager.Application.Transactions.Commands.UpdateTransaction
{
    public class UpdateTransactionCommandValidator : AbstractValidator<UpdateTransactionCommand>
    {
        public UpdateTransactionCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);          
            RuleFor(x => x.Status).NotEmpty();           
        }
    }
}
