using MediatR;

namespace BuildingBlocks.CQRS.Core
{
    /// <summary>
    /// Interface for Query implementation
    /// </summary>
    public interface IQuery<out TResult> : IValidationResult, IRequest<TResult> {}
}
