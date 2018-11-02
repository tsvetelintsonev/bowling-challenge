using Bowling.Core.Domain.Players;
using System;
using System.Collections.Generic;

namespace Bowling.Core.Domain.Scoring
{
    public class ScoreBoard : IScoreBoard
    {
        public ScoreBoard(IEnumerable<IPlayer> players) {
            if (players == null)
                throw new ArgumentNullException("players may not be null");

            Players = players;
        }

        public IEnumerable<IPlayer> Players { get; }
    }
}
