using Bowling.Core.Domain.Lanes;
using Bowling.Core.Domain.PinFalls;
using Bowling.Core.Domain.Rolls;
using System;
using System.Linq;

namespace Bowling.Core.Strategies.RollHandling
{
    public class RollProcessingStrategy : IRollProcessingStrategy
    {
        public void Handle(IRoll roll, ILane lane) {
            roll.KnockedDownPins = new PinFall(lane.Pins.Take(new Random().Next(0, lane.Pins.Count() + 1)));
        }
    }
}
