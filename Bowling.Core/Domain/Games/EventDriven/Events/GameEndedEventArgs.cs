using Bowling.Core.Domain.Scoring;
using System;

namespace Bowling.Core.Domain.Games.EventDriven.Events
{
    public class GameEndedEventArgs : EventArgs
    {
        public IScoreBoard ScoreBoard { get; set; }
        public int MaxFramesQty { get; set; }
    }
}
