using Bowling.Core.Domain.Frames;
using System.Collections.Generic;
using System.Linq;

namespace Bowling.Core.Domain.Scoring
{
    public class PlayerScoreCard : IPlayerScoreCard
    {
        private IList<IFrame> _frames;

        public PlayerScoreCard() {
            _frames = new List<IFrame>();
        }

        public IEnumerable<IFrame> Frames => _frames;

        public void AddFrame(IFrame frame) {
            _frames.Add(frame);
        }

        public int TotalScore => _frames.Sum(x => x.TotalScore);

        public int TotalScoreUpToFrame(IFrame frame) {
            return _frames.Take(frame.Id).Sum(x => x.TotalScore);
        }

        public void AddBonusToFrame(int frameId, int bonus)
        {
            _frames.FirstOrDefault(x => x.Id == frameId).Bonus += bonus;
        }

        public void UpdateFrames(params IFrame[] frames)
        {
            foreach (IFrame frame in frames) {
                _frames.RemoveAt(frame.Id);
                _frames.Insert(frame.Id, frame);
            }
        }

        public bool HasFrameMarkTypeSpare(int frameId)
        {
            return _frames.FirstOrDefault(x => x.Id == frameId && x.MarkType == MarkType.Spare) != null;
        }

        public bool HasFrameMarkTypeStrike(int frameId)
        {
            return _frames.FirstOrDefault(x => x.Id == frameId && x.MarkType == MarkType.Strike) != null;
        }
    }
}
