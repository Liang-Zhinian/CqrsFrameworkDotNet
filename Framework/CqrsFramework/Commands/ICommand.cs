using CqrsFramework.Messages;
using System;

namespace CqrsFramework.Commands
{
    /// <summary>
    /// A command is a message
    /// </summary>
    public interface ICommand : IMessage
    {
        /// <summary>
        /// The Aggregate ID of the Aggregate Root being changed
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// The Expected Version which the Aggregate will become.
        /// </summary>
        int ExpectedVersion { get; set; }
    }
}
