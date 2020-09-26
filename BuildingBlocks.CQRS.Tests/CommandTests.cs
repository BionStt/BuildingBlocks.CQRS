using System;
using NUnit.Framework;
using BuildingBlocks.CQRS.Tests.Examples;

namespace BuildingBlocks.CQRS.Tests
{
    public class CommandTests
    {
        [Test]
        public void Guid_Id_Command_Is_Valid()
        {
            var command = new ExampleGuidResultCommand(Guid.NewGuid()).Validate();
            Assert.True(command.IsValid);
        }

        [Test]
        public void Guid_Id_Command_Is_Not_Valid()
        {
            var command = new ExampleGuidResultCommand(new Guid()).Validate();
            Assert.False(command.IsValid);
        }

        [Test]
        public void Int_Id_Command_Is_Valid()
        {
            var command = new ExampleIntResultCommand(123).Validate();
            Assert.True(command.IsValid);
        }

        [Test]
        public void Int_Id_Command_Is_Not_Valid()
        {
            var command = new ExampleIntResultCommand(-1).Validate();
            Assert.False(command.IsValid);
        }
    }
}