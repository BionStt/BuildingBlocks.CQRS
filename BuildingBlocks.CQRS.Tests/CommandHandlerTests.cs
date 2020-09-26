using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.CQRS.Tests.Examples;
using NUnit.Framework;

namespace BuildingBlocks.CQRS.Tests
{
    public class CommandHandlerTests
    {
        [Test]
        public async Task Int_Id_Command_Is_Executed()
        {
            var id = 123;
            var command = new ExampleIntResultCommand(id);
            var handler = await new ExampleIntResultCommandHandler().Handle(command, CancellationToken.None);

            Assert.True(handler.Id == id);
            Assert.True(handler.ValidationResult.Errors.Count == 0);
        }

        [Test]
        public async Task Int_Id_Command_Is_Not_Executed()
        {
            var id = -1;
            var command = new ExampleIntResultCommand(id);
            var handler = await new ExampleIntResultCommandHandler().Handle(command, CancellationToken.None);

            Assert.True(handler.Id != id);
            Assert.True(handler.ValidationResult.Errors.Count > 0);
        }
    }
}