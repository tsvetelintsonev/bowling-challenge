using Bowling.Core.Domain.Frames;
using Bowling.Core.Domain.Players;
using Bowling.Core.Domain.Rolls;

namespace Bowling.Core.Domain.Games
{
    public interface IGameRules
    {
        int MaxLanePinsQty { get; }
        /// <summary>
        /// Processes the given roll and adds it to the frame. It also determines frame MarkType and bonus.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="frame"></param>
        /// <param name="roll"></param>
        void ProcessRoll(IPlayer player, IFrame frame, IRoll roll);
        bool HasFrameEnded(IFrame frame);
    }
}
