using BuildingBlocks.CQRS.Core;
using FluentValidation.Results;

namespace BuildingBlocks.CQRS.CommandHandling
{
    /// <summary>
    /// Abstract classes meant to be inherited by Commands
    /// </summary>
    
    public abstract class Command : CommandBase, ICommand<CommandHandlerResult> {}
    public abstract class Command<TID> : CommandBase, ICommand<CommandHandlerResult<TID>> where TID : struct {}

    public abstract class CommandBase
    {
        public ValidationResult ValidationResult { get; set; }

        /// <summary>
        /// Validation method
        /// </summary>
        /// <returns></returns>
        public virtual ValidationResult Validate()
        {
            return ValidationResult;
        }
    }
}
