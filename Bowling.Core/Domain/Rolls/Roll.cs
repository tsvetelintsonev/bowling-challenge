using Bowling.Core.Domain.PinFalls;

namespace Bowling.Core.Domain.Rolls
{
    public class Roll : IRoll
    {

        public Roll(int speed, int spinPower) {
            Speed = speed;
            SpinPower = spinPower;
        }

        public IPinFall KnockedDownPins { get; set; }

        public int Speed { get; }

        public int SpinPower { get; }
    }
}
