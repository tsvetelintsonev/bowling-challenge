using Bowling.Core.Domain.Rolls;
using System.Collections.Generic;

namespace Bowling.Core.Domain.Frames
{
    public interface IFrame
    {
        int Id { get; }
        MarkType MarkType { get; set; }
        IEnumerable<IRoll> Rolls { get; }
        int TotalScore { get; }
        int Bonus { get; set; }
        void AddRoll(IRoll roll);
    }
}