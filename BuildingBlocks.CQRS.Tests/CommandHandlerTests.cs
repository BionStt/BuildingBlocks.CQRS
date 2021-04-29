using System;
using System.Threading.Tasks;
using BuildingBlocks.CQRS.CommandHandling;
using BuildingBlocks.CQRS.Tests.Examples;
using FluentAssertions;
using Xunit;

namespace BuildingBlocks.CQRS.Tests
{
    public class CommandHandlerTests
    {
        [Fact]
        public async Task Command_is_executed()
        {
            var command = new CommandExample("test@test.com");
            CommandHandlerResult handlerResult = await new CommandHandlerExample().Handle(command);

            handlerResult.ValidationResult.IsValid.Should().BeTrue();
        }

        [Fact]
        public async Task Command_is_not_Executed()
        {
            var command = new CommandExample(string.Empty);
            CommandHandlerResult handlerResult = await new CommandHandlerExample().Handle(command);

            handlerResult.ValidationResult.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task CommandHandler_fails_with_exception()
        {
            var command = new CommandExample("test@test.com");
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => new FaultyCommandHandlerExample().Handle(command));
            ex.GetType().Should().Be(typeof(ArgumentNullException));
        }

        [Fact]
        public async Task Typed_Command_is_executed()
        {
            var command = new TypedCommandExample("Foo");
            CommandHandlerResult<Guid> handlerResult = await new TypedCommandHandlerExample().Handle(command);

            handlerResult.ValidationResult.IsValid.Should().BeTrue();
            handlerResult.Id.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Typed_Command_is_not_executed()
        {
            var command = new TypedCommandExample(string.Empty);
            CommandHandlerResult<Guid> handlerResult = await new TypedCommandHandlerExample().Handle(command);

            handlerResult.ValidationResult.IsValid.Should().BeFalse();
            handlerResult.Id.Should().BeEmpty();
        }
    }
}