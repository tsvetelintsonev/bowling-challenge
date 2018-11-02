using Bowling.Core.Domain.Players;
using System.Collections.Generic;

namespace Bowling.Core.Domain.Scoring
{
    public interface IScoreBoard
    {
        IEnumerable<IPlayer> Players { get; }
    }
}