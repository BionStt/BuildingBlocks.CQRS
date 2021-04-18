using NUnit.Framework;
using BuildingBlocks.CQRS.Tests.Examples;

namespace BuildingBlocks.CQRS.Tests
{
    public class QueryTests
    {
        [Test]
        public void Query_Is_Valid()
        {
            var query = new QueryExample(123).Validate();
            Assert.True(query.IsValid);
        }

        [Test]
        public void Query_Is_Not_Valid()
        {
            var query = new QueryExample(-1).Validate();
            Assert.False(query.IsValid);
        }
    }
}