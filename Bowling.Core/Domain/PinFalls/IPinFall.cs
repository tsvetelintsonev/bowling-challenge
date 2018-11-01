using Bowling.Core.Domain.Pins;
using System.Collections.Generic;

namespace Bowling.Core.Domain.PinFalls
{
    public interface IPinFall
    {
        IEnumerable<IPin> Pins { get; }
    }
}