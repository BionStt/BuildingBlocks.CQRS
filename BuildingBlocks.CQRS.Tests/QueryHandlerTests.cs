using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.CQRS.Tests.Examples;
using Xunit;
using FluentAssertions;

namespace BuildingBlocks.CQRS.Tests
{
    public class QueryHandlerTests
    {
        [Fact]
        public async Task Query_is_executed()
        {
            var id = 123;
            var query = new QueryExample(id);
            var handler = await new QueryHandlerExample().Handle(query, CancellationToken.None);

            handler.Result.Id.Should().Be(id);
            handler.ValidationResult.IsValid.Should().BeTrue();
        }

        [Fact]
        public async Task Query_is_not_executed()
        {
            var id = -1;
            var query = new QueryExample(id);
            var handler = await new QueryHandlerExample().Handle(query, CancellationToken.None);

            handler.Result.Should().BeNull();
            handler.ValidationResult.IsValid.Should().BeFalse();
        }
    }    
}