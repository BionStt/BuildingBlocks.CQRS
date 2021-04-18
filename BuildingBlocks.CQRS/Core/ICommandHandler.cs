using MediatR;

namespace BuildingBlocks.CQRS.Core
{
    /// <summary>
    /// Interface to implement Command Handlers
    /// </summary>
    public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult> 
        where TCommand : ICommand<TResult> {}
}
