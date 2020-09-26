using System;
using FluentValidation;
using FluentValidation.Results;
using BuildingBlocks.CQRS.CommandHandling;

namespace BuildingBlocks.CQRS.Tests.Examples
{
    internal class ExampleGuidResultCommand : Command<Guid>
    {
        public ExampleGuidResultCommand(Guid id)
        {
            Id = id;
        }

        public override ValidationResult Validate()
        {
            return new ExampleGuidCommandValidator().Validate(this);
        }

        public Guid Id { get; protected set; }
    }

    internal class ExampleGuidCommandValidator : AbstractValidator<ExampleGuidResultCommand>
    {
        public ExampleGuidCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage("Id is empty.");
        }
    }
}
