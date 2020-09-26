using BuildingBlocks.CQRS.Core;

namespace BuildingBlocks.CQRS.CommandHandling
{
    /// <summary>
    /// CommandHandler result class
    /// Only Id of struct and ValidationResult properties 
    /// to prevent CommandHandlers from being used as QueryHandlers
    /// </summary>
    public class CommandHandlerResult<TID> : HandlerResult where TID : struct
    {
        /// <summary>
        /// Id of an entity class
        /// </summary>
        public TID Id { get; set; }

        public CommandHandlerResult(ICommand<CommandHandlerResult<TID>> command)
        {
            ValidationResult = command.Validate();
        }
    }
}
