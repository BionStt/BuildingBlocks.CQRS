using BuildingBlocks.CQRS.Core;
using FluentValidation.Results;

namespace BuildingBlocks.CQRS.CommandHandling
{
    /// <summary>
    /// CommandHandler result class
    /// Only Id of struct and ValidationResult properties 
    /// Preventing CommandHandlers from being used as QueryHandlers
    /// </summary>
    /// <typeparam name="TID"></typeparam>
    public class CommandHandlerResult<TID> : CommandHandlerResultBase where TID : struct
    {
        /// <summary>
        /// Id of an entity class
        /// </summary>
        public TID Id { get; set; }

        public CommandHandlerResult(ICommand<CommandHandlerResult<TID>> command)
        {
            ValidationResult = command.Validate();
        }
    }

    /// <summary>
    /// No Id return implementation
    /// </summary>
    public class CommandHandlerResult : CommandHandlerResultBase
    {
        public CommandHandlerResult(ICommand<CommandHandlerResult> command)
        {
            ValidationResult = command.Validate();
        }
    }

    /// <summary>
    /// Common validation result object
    /// </summary>
    public abstract class CommandHandlerResultBase
    {
        public ValidationResult ValidationResult { get; set; }
    }
}
