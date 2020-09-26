using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.CQRS.CommandHandling;

namespace BuildingBlocks.CQRS.Tests.Examples
{
    internal class ExampleIntResultCommandHandler : CommandHandler<ExampleIntResultCommand, int>
    {
        public override async Task<int> ExecuteCommand(ExampleIntResultCommand command, CancellationToken cancellationToken)
        {
            return await Task.FromResult(123);
        }
    }
}
