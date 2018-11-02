using Bowling.Core.Domain.Lanes;
using Bowling.Core.Domain.PinFalls;
using Bowling.Core.Domain.Rolls;

namespace Bowling.Core.Strategies.RollHandling
{
    public interface IRollProcessingStrategy
    {
        void Handle(IRoll roll, ILane lane);
    }
}