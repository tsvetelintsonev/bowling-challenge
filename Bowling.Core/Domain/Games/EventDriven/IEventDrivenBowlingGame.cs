using Bowling.Core.Domain.Games.EventDriven.Events;
using System;

namespace Bowling.Core.Domain.Games.EventDriven
{
    public interface IEventDrivenBowlingGame : IBowlingGame
    {
        event EventHandler<FrameStartedEventArgs> FrameStarted;
        event EventHandler<FrameEndedEventArgs> FrameEnded;
        event EventHandler<RollEndedEventArgs> RollEnded;
        event EventHandler<GameEndedEventArgs> GameEnded;
    }
}
