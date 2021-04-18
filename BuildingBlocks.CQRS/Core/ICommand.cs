using MediatR;

namespace BuildingBlocks.CQRS.Core
{
    /// <summary>
    /// Interfaces to implement Commands
    /// </summary>
    public interface ICommand<out TResult> : IValidationResult, IRequest<TResult> {}
}