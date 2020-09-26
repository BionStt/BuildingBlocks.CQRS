using FluentValidation;
using FluentValidation.Results;
using BuildingBlocks.CQRS.CommandHandling;

namespace BuildingBlocks.CQRS.Tests.Examples
{
    internal class ExampleIntResultCommand : Command<int>
    {
        public ExampleIntResultCommand(int id)
        {
            Id = id;
        }

        public override ValidationResult Validate()
        {
            return new ExampleIntCommandValidator().Validate(this);
        }

        public int Id { get; protected set; }
    }

    internal class ExampleIntCommandValidator : AbstractValidator<ExampleIntResultCommand>
    {
        public ExampleIntCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be > 0.");
        }
    }
}
