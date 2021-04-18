using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.CQRS.QueryHandling;

namespace BuildingBlocks.CQRS.Tests.Examples
{
    internal class QueryHandlerExample : QueryHandler<QueryExample, ExampleResultObject>
    {
        public override async Task<ExampleResultObject> ExecuteQuery(QueryExample query, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new ExampleResultObject(query.Id));
        }
    }

    internal class ExampleResultObject 
    {
        public ExampleResultObject(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
