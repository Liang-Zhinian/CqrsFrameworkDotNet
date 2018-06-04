using CqrsFramework.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsFramework.Events
{
    /// <summary>
    /// An event is a message
    /// </summary>
    public interface IEvent : IMessage
    {
        /// <summary>
        /// The ID of the Aggregate being affected by this event
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// The Version of the Aggregate which results from this event
        /// </summary>
        int Version { get; set; }

        /// <summary>
        /// The UTC time when this event occurred.
        /// </summary>
        DateTimeOffset TimeStamp { get; set; }
    }
}
