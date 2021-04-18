using System;
using FluentValidation;
using FluentValidation.Results;
using BuildingBlocks.CQRS.CommandHandling;

namespace BuildingBlocks.CQRS.Tests.Examples
{
    internal class CommandExample : Command
    {
        public CommandExample(string email)
        {
            Email = email;
        }

        public override ValidationResult Validate()
        {
            return new CommandValidator().Validate(this);
        }

        public string Email { get; protected set; }

        internal class CommandValidator : AbstractValidator<CommandExample>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Email).NotEmpty().WithMessage("Email is empty.");
                RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not a valid address.");
            }
        }
    }

    internal class TypedCommandExample : Command<Guid>
    {
        public TypedCommandExample(string name)
        {
            Name = name;
        }

        public override ValidationResult Validate()
        {
            return new TypedCommandValidator().Validate(this);
        }

        public string Name { get; protected set; }

        internal class TypedCommandValidator : AbstractValidator<TypedCommandExample>
        {
            public TypedCommandValidator()
            {
                RuleFor(x => x.Name).NotEmpty().WithMessage("Name is empty.");
            }
        }
    }
}
