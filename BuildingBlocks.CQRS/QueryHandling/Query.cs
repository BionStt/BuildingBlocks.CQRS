using BuildingBlocks.CQRS.Core;
using FluentValidation.Results;

namespace BuildingBlocks.CQRS.QueryHandling
{
    /// <summary>
    /// Abstract class to be inherited by Queries
    /// </summary>
    public abstract class Query<TResult> : IQuery<QueryHandlerResult<TResult>>
    {
        public ValidationResult ValidationResult { get; set; }

        public virtual ValidationResult Validate()
        {
            return ValidationResult;
        }
    }
}
