using Bowling.Core.Domain.PinFalls;
using Bowling.Core.Domain.Pins;
using Bowling.Core.Domain.Rolls;
using Bowling.Core.Strategies;
using Bowling.Core.Strategies.RollHandling;
using System.Collections.Generic;
using System.Linq;

namespace Bowling.Core.Domain.Lanes
{
    public class Lane : ILane
    {
        private IEnumerable<IPin> _pins;
        private IRollHandlingStrategy _rollHandlingStrategy;

        public Lane(IRollHandlingStrategy rollHandlingStrategy) {
            CreatePins();
            _rollHandlingStrategy = rollHandlingStrategy;
        }

        public IEnumerable<IPin> Pins { get; }

        public void Reset()
        {
            CreatePins();
        }

        public IPinFall HandleRoll(IRoll roll) {
            IPinFall pinFall = _rollHandlingStrategy.Handle(roll, this);
            CollectFalledPins(pinFall);
            return pinFall;
        }

        public void CollectFalledPins(IPinFall pinFall)
        {
            IList<IPin> temporaryPins = Pins.ToList();
            foreach (IPin pin in pinFall.Pins) {
                temporaryPins.Remove(pin);
            }
            _pins = temporaryPins;
        }

        private void CreatePins() {
            IList<IPin> pins = new List<IPin>();
            for (int i = 0; i < 10; i++) {
                pins.Add(new Pin());
            }
            _pins = pins;
        }
    }
}
