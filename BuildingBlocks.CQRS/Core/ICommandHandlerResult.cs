using FluentValidation.Results;

namespace BuildingBlocks.CQRS.Core
{
    /// <summary>
    /// Interface for CommandHandlerResult implementation
    /// </summary>
    public interface ICommandHandlerResult
    {
        public ValidationResult ValidationResult { get; set; }
    }
}
