using FluentValidation;
using FluentValidation.Results;
using BuildingBlocks.CQRS.QueryHandling;

namespace BuildingBlocks.CQRS.Tests.Examples
{
    internal class QueryExample : Query<ExampleResultObject>
    {
        public QueryExample(int id)
        {
            Id = id;
        }

        public override ValidationResult Validate()
        {
            return new ExampleQueryValidator().Validate(this);
        }

        public int Id { get; protected set; }
    }

    internal class ExampleQueryValidator : AbstractValidator<QueryExample>
    {
        public ExampleQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be > 0.");
        }
    }
}
