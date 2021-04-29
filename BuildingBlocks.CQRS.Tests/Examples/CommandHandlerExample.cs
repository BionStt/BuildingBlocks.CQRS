using System;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.CQRS.CommandHandling;

namespace BuildingBlocks.CQRS.Tests.Examples
{
    internal class CommandHandlerExample : CommandHandler<CommandExample>
    {
        public async override Task ExecuteCommand(CommandExample command, CancellationToken cancellationToken = default)
        {
            await Task.FromResult(new CommandHandlerResult(command));
        }
    }

    internal class FaultyCommandHandlerExample : CommandHandler<CommandExample>
    {
        public async override Task ExecuteCommand(CommandExample command, CancellationToken cancellationToken = default)
        {
            ThrowException();
            await Task.FromResult(new CommandHandlerResult(command));
        }

        private void ThrowException()
        {
            throw new ArgumentNullException();
        }
    }

    internal class TypedCommandHandlerExample : CommandHandler<TypedCommandExample, Guid>
    {
        public async override Task<Guid> ExecuteCommand(TypedCommandExample command, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(Guid.NewGuid());
        }
    }
}
