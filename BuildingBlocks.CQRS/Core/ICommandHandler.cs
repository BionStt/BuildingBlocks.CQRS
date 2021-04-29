using MediatR;

namespace BuildingBlocks.CQRS.Core
{
    /// <summary>
    /// Interface for Command Handler implementation
    /// </summary>
    public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult> 
        where TCommand : ICommand<TResult> {}
}
