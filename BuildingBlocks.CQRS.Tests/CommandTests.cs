using BuildingBlocks.CQRS.Tests.Examples;
using FluentAssertions;
using Xunit;

namespace BuildingBlocks.CQRS.Tests
{
    public class CommandTests
    {
        [Fact]
        public void Command_is_valid()
        {
            var command = new CommandExample("test@test.com").Validate();

            command.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Command_is_not_valid()
        {
            var emptyCommand = new CommandExample(string.Empty).Validate();
            var invalidAddressCommand = new CommandExample("test").Validate();

            emptyCommand.IsValid.Should().BeFalse();
            invalidAddressCommand.IsValid.Should().BeFalse();
        }
    }
}