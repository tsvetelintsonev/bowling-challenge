using Bowling.Core.Domain.Frames;
using System;

namespace Bowling.Core.Domain.Games.EventDriven.Events
{
    public class FrameStartedEventArgs : EventArgs
    {
        public IFrame Frame { get; set; }
        public string PlayerName { get; set; }
    }
}
