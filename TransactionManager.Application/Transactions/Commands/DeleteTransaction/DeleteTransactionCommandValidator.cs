using FluentValidation;

namespace TransactionManager.Application.Transactions.Commands.DeleteTransaction
{
    public class DeleteTransactionCommandValidator : AbstractValidator<DeleteTransactionCommand>
    {
        public DeleteTransactionCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
