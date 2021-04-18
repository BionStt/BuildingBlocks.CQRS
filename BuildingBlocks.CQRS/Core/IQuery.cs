using MediatR;

namespace BuildingBlocks.CQRS.Core
{
    /// <summary>
    /// Interface to implement Queries
    /// </summary>
    public interface IQuery<out TResult> : IValidationResult, IRequest<TResult> {}
}
