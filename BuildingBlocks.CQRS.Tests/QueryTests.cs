using BuildingBlocks.CQRS.Tests.Examples;
using FluentAssertions;
using Xunit;

namespace BuildingBlocks.CQRS.Tests
{
    public class QueryTests
    {
        [Fact]
        public void Query_is_valid()
        {
            var query = new QueryExample(123).Validate();
            query.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Query_is_not_valid()
        {
            var query = new QueryExample(-1).Validate();
            query.IsValid.Should().BeFalse();
        }
    }
}