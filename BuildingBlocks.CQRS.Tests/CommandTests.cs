using System;
using NUnit.Framework;
using BuildingBlocks.CQRS.Tests.Examples;

namespace BuildingBlocks.CQRS.Tests
{
    public class CommandTests
    {
        [Test]
        public void Command_Is_Valid()
        {
            var command = new CommandExample("test@test.com").Validate();
            Assert.True(command.IsValid);
        }

        [Test]
        public void Command_Is_Not_Valid()
        {
            var emptyCommand = new CommandExample(string.Empty).Validate();
            var invalidAddressCommand = new CommandExample("test").Validate();
            
            Assert.False(emptyCommand.IsValid);
            Assert.False(invalidAddressCommand.IsValid);
        }
    }
}