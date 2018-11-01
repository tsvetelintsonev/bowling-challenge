using System;
using System.Collections.Generic;

namespace Bowling.Core.Domain.Scoring
{
    public class ScoreBoard : IScoreBoard
    {
        public ScoreBoard(IEnumerable<IPlayerScoreCard> playerScoreCards) {
            if (playerScoreCards == null)
                throw new ArgumentNullException("playerScoreCards may not be null");

            PlayerScoreCards = playerScoreCards;
        }

        public IEnumerable<IPlayerScoreCard> PlayerScoreCards { get; }
    }
}
