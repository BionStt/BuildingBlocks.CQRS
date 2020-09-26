using BuildingBlocks.CQRS.Core;

namespace BuildingBlocks.CQRS.QueryHandling
{
    /// <summary>
    /// QueryHandler result class
    /// </summary>
    public class QueryHandlerResult<TResult> : HandlerResult
    {
        public TResult Result { get; set; }


        public QueryHandlerResult(IQuery<QueryHandlerResult<TResult>> query)
        {
            ValidationResult = query.Validate();
        }
    }
}
