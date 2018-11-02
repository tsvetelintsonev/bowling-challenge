using Bowling.Core.Domain.Frames;
using Bowling.Core.Domain.Scoring;
using System;

namespace Bowling.Core.Domain.Games.EventDriven.Events
{
    public class FrameEndedEventArgs : EventArgs
    {
        public IFrame Frame { get; set; }
        public IPlayerScoreCard PlayerScoreCard { get; set; }
    }
}
