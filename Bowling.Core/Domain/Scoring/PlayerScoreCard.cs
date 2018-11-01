using Bowling.Core.Domain.Frames;
using Bowling.Core.Domain.Players;
using System.Collections.Generic;

namespace Bowling.Core.Domain.Scoring
{
    public class PlayerScoreCard : IPlayerScoreCard
    {
        private IList<IFrame> _frames;

        public PlayerScoreCard(IPlayer player) {
            Player = player;
            _frames = new List<IFrame>();
        }

        public IPlayer Player { get; }

        public void AddFrame(IFrame frame) {
            _frames.Add(frame);
        }
    }
}
