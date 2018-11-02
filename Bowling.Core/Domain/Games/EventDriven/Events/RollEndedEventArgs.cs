using Bowling.Core.Domain.Rolls;
using System;

namespace Bowling.Core.Domain.Games.EventDriven.Events
{
    public class RollEndedEventArgs : EventArgs
    {
        public IRoll Roll { get; set; }
    }
}
