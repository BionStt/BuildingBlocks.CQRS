using MediatR;

namespace BuildingBlocks.CQRS.Core
{
    /// <summary>
    /// Interface to implement Command Handlers
    /// </summary>
    /// <typeparam name="TCommand">TCommand object</typeparam>
    /// <typeparam name="TResult">TResult object</typeparam>
    public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult> 
        where TCommand : ICommand<TResult> {}
}
