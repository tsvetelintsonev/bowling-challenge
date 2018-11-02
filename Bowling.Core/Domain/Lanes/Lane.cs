using Bowling.Core.Domain.Games;
using Bowling.Core.Domain.PinFalls;
using Bowling.Core.Domain.Pins;
using Bowling.Core.Domain.Rolls;
using Bowling.Core.Strategies.RollHandling;
using System.Collections.Generic;
using System.Linq;

namespace Bowling.Core.Domain.Lanes
{
    public class Lane : ILane
    {
        private IGameRules _gameRules;
        private IEnumerable<IPin> _pins;
        private IRollProcessingStrategy _rollHandlingStrategy;

        public Lane(IGameRules gameRules, IRollProcessingStrategy rollHandlingStrategy) {
            _gameRules = gameRules;
            _rollHandlingStrategy = rollHandlingStrategy;
            CreatePins();
        }

        public IEnumerable<IPin> Pins => _pins;

        public void Reset()
        {
            CreatePins();
        }

        public void ProcessRoll(IRoll roll) {
            _rollHandlingStrategy.Handle(roll, this);
            CollectFalledPins(roll.KnockedDownPins);
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
            for (int i = 0; i < _gameRules.MaxLanePinsQty; i++) {
                pins.Add(new Pin());
            }
            _pins = pins;
        }
    }
}
