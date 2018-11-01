using System.Collections.Generic;

namespace Bowling.Core.Domain.Scoring
{
    public interface IScoreBoard
    {
        IEnumerable<IPlayerScoreCard> PlayerScoreCards { get; }
    }
}