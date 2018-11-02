using Bowling.Core.Domain.Rolls;
using System.Collections.Generic;
using System.Linq;

namespace Bowling.Core.Domain.Frames
{
    public class Frame : IFrame
    {
        private IList<IRoll> _rolls;

        public Frame(int id)
        {
            Id = id;
            _rolls = new List<IRoll>();
            MarkType = MarkType.Default;
        }

        public int Id { get; }
        public IEnumerable<IRoll> Rolls => _rolls;

        public int TotalScore => _rolls.Sum(x => x.KnockedDownPins.Quantity) + Bonus;

        public int Bonus { get; set; } = 0;

        public MarkType MarkType { get; set; }

        public void AddRoll(IRoll roll)
        {
            _rolls.Add(roll);
        }
    }
}
