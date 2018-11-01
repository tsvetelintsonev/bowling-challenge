using Bowling.Core.Domain.Rolls;

namespace Bowling.Core.Domain.Frames
{
    public class Frame : IFrame
    {
        private IRoll _roll;

        public Frame(int id, int maxRollsQty)
        {
            Id = id;
            MaxRollsQty = maxRollsQty;
        }

        public int Id { get; }

        public int MaxRollsQty { get; }

        public void SetRoll(IRoll roll)
        {
            _roll = roll;
        }
    }
}
