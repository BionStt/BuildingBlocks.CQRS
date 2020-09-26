using FluentValidation.Results;

namespace BuildingBlocks.CQRS.Core
{
    /// <summary>
    /// Interface for FluentValidation object
    /// </summary>
    /// <returns></returns>
    public interface IValidationHandler
    {
        /// <summary>
        /// To override
        /// </summary>
        /// <returns></returns>
        public abstract ValidationResult Validate();
    }
}
