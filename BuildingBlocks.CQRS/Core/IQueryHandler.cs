using MediatR;

namespace BuildingBlocks.CQRS.Core
{
    /// <summary>
    /// Interface to implement Query Handlers
    /// </summary>
    /// <typeparam name="TQuery"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult> {}

}
