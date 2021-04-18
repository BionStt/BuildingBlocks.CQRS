using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.CQRS.Tests.Examples;
using NUnit.Framework;

namespace BuildingBlocks.CQRS.Tests
{
    public class QueryHandlerTests
    {
        [Test]
        public async Task Query_Is_Executed()
        {
            var id = 123;
            var query = new QueryExample(id);
            var handler = await new QueryHandlerExample().Handle(query, CancellationToken.None);

            Assert.True(handler.Result.Id == id);
            Assert.True(handler.ValidationResult.Errors.Count == 0);
        }

        [Test]
        public async Task Query_Is_Not_Executed()
        {
            var id = -1;
            var query = new QueryExample(id);
            var handler = await new QueryHandlerExample().Handle(query, CancellationToken.None);

            Assert.IsNull(handler.Result);
            Assert.True(handler.ValidationResult.Errors.Count > 0);
        }
    }    
}