using System;
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
            var query = new ExampleQuery(id);
            var handler = await new ExampleQueryHandler().Handle(query, CancellationToken.None);

            Assert.True(handler.Result.Id == id);
            Assert.True(handler.ValidationResult.Errors.Count == 0);
        }

        [Test]
        public async Task Query_Is_Not_Executed()
        {
            var id = -1;
            var query = new ExampleQuery(id);
            var handler = await new ExampleQueryHandler().Handle(query, CancellationToken.None);

            Assert.True(handler.Result == null);
            Assert.True(handler.ValidationResult.Errors.Count > 0);
        }
    }    
}