using Bowling.Core.Domain.Frames;
using Bowling.Core.Domain.Games;
using Bowling.Core.Domain.Games.Exceptions;
using Bowling.Core.Domain.Lanes;
using Bowling.Core.Domain.Rolls;
using Bowling.Core.Domain.Scoring;

namespace Bowling.Core.Domain.Players
{
    public class Player : IPlayer
    {
        private readonly IGameRules _gameRules;

        public Player(string name, IGameRules gameRules, ILane lane) {
            Name = name;
            Lane = lane;
            _gameRules = gameRules;
            ScoreCard = new PlayerScoreCard();
        }

        public ILane Lane { get; }
        public string Name { get; }

        public IPlayerScoreCard ScoreCard { get; }

        public IRoll DoRoll(IFrame frame, int speed, int spinPower)
        {
            IRoll roll = new Roll(speed, spinPower);
            try {
                Lane.ProcessRoll(roll);
                _gameRules.ProcessRoll(this, frame, roll);
                frame.AddRoll(roll);
            }
            catch (NotAllowedRollException ex) {
                // ignore it
            }

            return roll;
        }

    }
}
