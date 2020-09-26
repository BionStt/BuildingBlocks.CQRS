using BuildingBlocks.CQRS.Core;
using FluentValidation.Results;

namespace BuildingBlocks.CQRS.QueryHandling
{
    /// <summary>
    /// Abstract class meant to be inherited by Queries
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public abstract class Query<TResult> : IQuery<QueryHandlerResult<TResult>>
    {
        public ValidationResult ValidationResult { get; } = new ValidationResult();

        public virtual ValidationResult Validate()
        {
            return ValidationResult;
        }
    }
}
