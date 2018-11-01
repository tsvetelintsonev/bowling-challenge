using Bowling.Core.Domain.PinFalls;
using Bowling.Core.Domain.Pins;
using Bowling.Core.Domain.Rolls;
using System.Collections.Generic;

namespace Bowling.Core.Domain.Lanes
{
    public interface ILane
    {
        IEnumerable<IPin> Pins { get; }

        void CollectFalledPins(IPinFall pinFall);
        IPinFall HandleRoll(IRoll roll);
        void Reset();
    }
}