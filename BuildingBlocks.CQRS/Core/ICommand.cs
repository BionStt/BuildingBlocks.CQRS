using MediatR;

namespace BuildingBlocks.CQRS.Core
{
    /// <summary>
    /// Interface for Command implementation
    /// </summary>
    public interface ICommand<out TResult> : IValidationResult, IRequest<TResult> {}
}