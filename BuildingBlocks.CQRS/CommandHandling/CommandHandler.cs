using System;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.CQRS.Core;
using FluentValidation.Results;

namespace BuildingBlocks.CQRS.CommandHandling
{
    /// <summary>
    /// Abstract class meant to be inherited by Command Handlers
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    /// <typeparam name="TID"></typeparam>
    public abstract class CommandHandler<TCommand, TID> : ICommandHandler<TCommand, CommandHandlerResult<TID>>
        where TCommand : ICommand<CommandHandlerResult<TID>>
        where TID : struct
    {
        /// <summary>
        /// To override
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task<TID> ExecuteCommand(TCommand command, CancellationToken cancellationToken = default);

        /// <summary>
        /// MediatR Handle implementation
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CommandHandlerResult<TID>> Handle(TCommand command, CancellationToken cancellationToken = default)
        {
            if ((dynamic)command == null)
                throw new ArgumentNullException(nameof(command));

            CommandHandlerResult<TID> result = new CommandHandlerResult<TID>(command);

            try
            {
                if (result.ValidationResult.IsValid)
                    result.Id = await ExecuteCommand(command, cancellationToken);
            }
            catch (Exception e)
            {
                result.ValidationResult.Errors.Add(new ValidationFailure(string.Empty, e.Message));
            }

            return result;
        }
    }

    /// <summary>
    /// No Id return implementation
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand, CommandHandlerResult>
        where TCommand : ICommand<CommandHandlerResult>
    {

        public abstract Task ExecuteCommand(TCommand command, CancellationToken cancellationToken = default);

        public async Task<CommandHandlerResult> Handle(TCommand command, CancellationToken cancellationToken = default)
        {
            if ((dynamic)command == null)
                throw new ArgumentNullException(nameof(command));

            CommandHandlerResult result = new CommandHandlerResult(command);

            try
            {
                if (result.ValidationResult.IsValid)
                    await ExecuteCommand(command, cancellationToken);
            }
            catch (Exception e)
            {
                result.ValidationResult.Errors.Add(new ValidationFailure(string.Empty, e.Message));
            }

            return result;
        }
    }
}
