using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransactionManager.Application.Common.Exceptions;
using TransactionManager.Application.Transactions.Commands.UpsertTransactions;
using ValidationException = TransactionManager.Application.Common.Exceptions.ValidationException;

namespace TransactionManager.Application.Common.Behaviours
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext(request);



            if (context.InstanceToValidate is UpsertTransactionsCommand)
            {               
                var validator = new TransactionUpsertModelValidator();

                var instance = (UpsertTransactionsCommand)context.InstanceToValidate;

                var i = 0;
                foreach(var transaction in instance.Transactions)
                {
                    var errors = validator.Validate(transaction).Errors;
                    if (errors.Count != 0)
                    {
                        throw new FileRecordsValidationException(i + 1, errors);
                    }

                    i++;
                }
            }
            else
            {
                var failures = _validators
                       .Select(v => v.Validate(context))
                       .SelectMany(result => result.Errors)
                       .Where(f => f != null)
                       .ToList();

                if (failures.Count != 0)
                {
                    throw new ValidationException(failures);
                }
            }

            return next();
        }
    }
}
