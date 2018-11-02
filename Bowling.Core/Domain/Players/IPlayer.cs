using Bowling.Core.Domain.Frames;
using Bowling.Core.Domain.Lanes;
using Bowling.Core.Domain.Rolls;
using Bowling.Core.Domain.Scoring;

namespace Bowling.Core.Domain.Players
{
    public interface IPlayer
    {
        ILane Lane { get; }
        string Name { get; }
        IPlayerScoreCard ScoreCard { get; }
        IRoll DoRoll(IFrame frame, int speed, int spinPower);
    }
}