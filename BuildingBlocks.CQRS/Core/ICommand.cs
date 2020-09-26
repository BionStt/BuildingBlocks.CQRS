using MediatR;

namespace BuildingBlocks.CQRS.Core
{
    /// <summary>
    /// Interface to implement Commands
    /// </summary>
    public interface ICommand : IValidationHandler, IRequest {}

    public interface ICommand<out TResult> : IValidationHandler, IRequest<TResult> {}
}