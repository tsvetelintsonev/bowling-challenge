using Bowling.Core.Domain.Frames;
using Bowling.Core.Domain.Lanes;

namespace Bowling.Core.Domain.Players
{
    public class Player : IPlayer
    {
        public Player(string name, ILane lane) {
            Name = name;
            Lane = lane;
        }

        public ILane Lane { get; }
        public string Name { get; }

        public void PlayFrame(IFrame frame) {
            for (int i = 1; i <= frame.MaxRollsQty; i++) {

            }
        }
    }
}
