using Bowling.Core.Domain.Rolls;

namespace Bowling.Core.Domain.Frames
{
    public interface IFrame
    {
        int Id { get; }
        int MaxRollsQty { get; }

        void SetRoll(IRoll roll);
    }
}