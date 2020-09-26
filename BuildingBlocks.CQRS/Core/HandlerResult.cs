using FluentValidation.Results;

namespace BuildingBlocks.CQRS.Core
{
    public abstract class HandlerResult
    {
        /// <summary>
        /// Validation object of FluentValidation https://fluentvalidation.net/
        /// </summary>
        public ValidationResult ValidationResult { get; set; }
    }
}
