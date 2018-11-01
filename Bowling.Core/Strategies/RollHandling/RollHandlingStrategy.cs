using Bowling.Core.Domain.Lanes;
using Bowling.Core.Domain.PinFalls;
using Bowling.Core.Domain.Rolls;
using System;
using System.Linq;

namespace Bowling.Core.Strategies.RollHandling
{
    public class RollHandlingStrategy : IRollHandlingStrategy
    {
        public IPinFall Handle(IRoll roll, ILane lane) {
            return new PinFall(lane.Pins.Take(new Random().Next(0, lane.Pins.Count())));
        }
    }
}
