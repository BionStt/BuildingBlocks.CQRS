using MediatR;

namespace BuildingBlocks.CQRS.Core
{
    /// <summary>
    /// Interface for Query Handler implementation
    /// </summary>
    public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult> {}

}
