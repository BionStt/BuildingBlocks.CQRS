using BuildingBlocks.CQRS.Core;
using FluentValidation.Results;

namespace BuildingBlocks.CQRS.CommandHandling
{
    /// <summary>
    /// Abstract class meant to be inherited by Commands
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public abstract class Command<TID> : IValidationHandler, ICommand<CommandHandlerResult<TID>>
        where TID : struct
    {
        public ValidationResult ValidationResult { get; set; } = new ValidationResult();

        public virtual ValidationResult Validate()
        {
            return ValidationResult;
        }
    }
}
