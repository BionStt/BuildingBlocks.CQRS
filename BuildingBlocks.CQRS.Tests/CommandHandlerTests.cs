using System;
using System.Threading.Tasks;
using BuildingBlocks.CQRS.CommandHandling;
using BuildingBlocks.CQRS.Tests.Examples;
using NUnit.Framework;

namespace BuildingBlocks.CQRS.Tests
{
    public class CommandHandlerTests
    {
        [Test]
        public async Task Command_Is_Executed()
        {
            var command = new CommandExample("test@test.com");
            CommandHandlerResult handlerResult = await new CommandHandlerExample().Handle(command);

            Assert.True(handlerResult.ValidationResult.Errors.Count == 0);
        }

        [Test]
        public async Task Command_Is_Not_Executed()
        {
            var command = new CommandExample(string.Empty);
            CommandHandlerResult handlerResult = await new CommandHandlerExample().Handle(command);

            Assert.True(handlerResult.ValidationResult.Errors.Count > 0);
        }

        [Test]
        public async Task Typed_Command_Is_Executed()
        {
            var command = new TypedCommandExample("Foo");
            CommandHandlerResult<Guid> handlerResult = await new TypedCommandHandlerExample().Handle(command);

            Assert.True(handlerResult.ValidationResult.Errors.Count == 0);
            Assert.True(handlerResult.Id != Guid.Empty);
        }

        [Test]
        public async Task Typed_Command_Is_Not_Executed()
        {
            var command = new TypedCommandExample(string.Empty);
            CommandHandlerResult<Guid> handlerResult = await new TypedCommandHandlerExample().Handle(command);

            Assert.True(handlerResult.ValidationResult.Errors.Count > 0);
            Assert.True(handlerResult.Id == Guid.Empty);
        }
    }
}