using Bowling.Core.Domain.Frames;
using Bowling.Core.Domain.Players;

namespace Bowling.Core.Domain.Scoring
{
    public interface IPlayerScoreCard
    {
        IPlayer Player { get; }

        void AddFrame(IFrame frame);
    }
}