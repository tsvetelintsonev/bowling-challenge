using Bowling.Core.Domain.Pins;
using System;
using System.Collections.Generic;

namespace Bowling.Core.Domain.PinFalls
{
    public class PinFall : IPinFall
    {
        public PinFall(IEnumerable<IPin> pins) {
            Pins = pins;
        }

        public IEnumerable<IPin> Pins { get; }
    }
}
