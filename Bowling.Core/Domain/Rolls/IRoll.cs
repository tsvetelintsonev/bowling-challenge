using Bowling.Core.Domain.PinFalls;

namespace Bowling.Core.Domain.Rolls
{
    public interface IRoll
    {
        int Speed { get; }
        int SpinPower { get; }
        IPinFall KnockedDownPins { get; set; }
    }
}
