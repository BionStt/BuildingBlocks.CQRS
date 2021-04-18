using FluentValidation.Results;

namespace BuildingBlocks.CQRS.Core
{
    /// <summary>
    /// Interface for FluentValidation result
    /// </summary>
    public interface IValidationResult
    {
        ValidationResult ValidationResult { get; set; }

        /// <summary>
        /// To override
        /// </summary>
        /// <returns></returns>
        public abstract ValidationResult Validate();
    }
}
