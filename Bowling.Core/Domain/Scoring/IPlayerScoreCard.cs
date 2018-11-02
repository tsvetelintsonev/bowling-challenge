using Bowling.Core.Domain.Frames;
using System.Collections.Generic;

namespace Bowling.Core.Domain.Scoring
{
    public interface IPlayerScoreCard
    {
        IEnumerable<IFrame> Frames { get; }
        int TotalScore { get; }
        int TotalScoreUpToFrame(IFrame frame);
        void UpdateFrames(params IFrame[] frames);
        void AddFrame(IFrame frame);
        void AddBonusToFrame(int frameId, int bonus);
        bool HasFrameMarkTypeStrike(int frameId);
        bool HasFrameMarkTypeSpare(int frameId);
    }
}