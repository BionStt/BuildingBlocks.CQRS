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
    /// <typeparam name="TCommand">Command of ICommand</typeparam>
    /// <typeparam name="TResult">CommandHandlerResult object</typeparam>
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
        public abstract Task<TID> ExecuteCommand(TCommand command, CancellationToken cancellationToken);

        /// <summary>
        /// MediatR Handle implementation
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CommandHandlerResult<TID>> Handle(TCommand command, CancellationToken cancellationToken)
        {
            if ((dynamic)command == null)
                throw new ArgumentNullException(nameof(command));

            CommandHandlerResult<TID> result = new CommandHandlerResult<TID>(command);

            try
            {
                if (result.ValidationResult.IsValid)
                    result.Id = await ExecuteCommand(command, cancellationToken);
            }
            catch(Exception e)
            {
                result.ValidationResult.Errors.Add(new ValidationFailure(string.Empty, e.Message));
            }

            return result;
        }
    }
}
