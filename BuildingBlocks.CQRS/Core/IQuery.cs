using MediatR;

namespace BuildingBlocks.CQRS.Core
{
    /// <summary>
    /// Interface to implement Queries
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface IQuery<out TResult> : IValidationHandler, IRequest<TResult> { }    
}
