using BuildingBlocks.CQRS.Core;
using FluentValidation.Results;
using System;

namespace BuildingBlocks.CQRS.CommandHandling
{
    /// <summary>
    /// CommandHandler result class
    /// Only Id of struct and ValidationResult properties 
    /// Preventing CommandHandlers from being used as QueryHandlers
    /// </summary>
    /// <typeparam name="TID"></typeparam>
    public sealed class CommandHandlerResult<TID> : CommandHandlerResultBase
        where TID : struct
    {
        /// <summary>
        /// Id of an entity class
        /// </summary>
        public TID Id { get; set; }

        public CommandHandlerResult(ICommand<CommandHandlerResult<TID>> command) : base(command) {}
    }

    /// <summary>
    /// No Id return implementation
    /// </summary>
    public sealed class CommandHandlerResult : CommandHandlerResultBase
    {
        public CommandHandlerResult(ICommand<CommandHandlerResult> command) : base(command) {}
    }

    /// <summary>
    /// No Id return implementation
    /// </summary>
    public abstract class CommandHandlerResultBase : ICommandHandlerResult
    {
        public ValidationResult ValidationResult { get; set; }
        public CommandHandlerResultBase(ICommand<ICommandHandlerResult> command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            ValidationResult = command.Validate();
        }
    }
}
