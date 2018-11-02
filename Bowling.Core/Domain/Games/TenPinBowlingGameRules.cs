using System.Linq;
using Bowling.Core.Domain.Frames;
using Bowling.Core.Domain.Games.Exceptions;
using Bowling.Core.Domain.Players;
using Bowling.Core.Domain.Rolls;

namespace Bowling.Core.Domain.Games
{
    public class TenPinBowlingGameRules : IGameRules
    {
        private int _ordinaryFrameMaxRollsQty;
        private int _lastFrameMaxRollsQty;
        private int _strikePinsQty;

        public TenPinBowlingGameRules() {
            _ordinaryFrameMaxRollsQty = 2;
            _lastFrameMaxRollsQty = 3;
            _strikePinsQty = 10;
            MaxFramesQty = 10;
        }

        public int MaxFramesQty { get; }
        public int MaxLanePinsQty => 10;

        public void ProcessRoll(IPlayer player, IFrame frame, IRoll roll)
        {
            if (frame.Rolls.Count() == GetFrameMaxRollsQty(frame))
                throw new RollNotAllowedException($"No more rolls are allowed for {player.Name} in frame {frame.Id}");
            if (IsLastFrame(frame))
                ProcessLastFrameRoll(player, frame, roll);
            else
                ProcessOrdinaryFrameRoll(player, frame, roll);
        }

        public bool HasFrameEnded(IFrame frame)
        {
            if (IsLastFrame(frame))
                return HasLastFrameEnded(frame);
            return HasOrdinaryFrameEnded(frame);
        }

        private void ProcessLastFrameRoll(IPlayer player, IFrame frame, IRoll roll) {
            DetermineFrameMarkType(frame, roll);
            if(player.ScoreCard.HasFrameMarkTypeStrike(frame.Id - 1) && frame.Rolls.Count() < _lastFrameMaxRollsQty)
                player.ScoreCard.AddBonusToFrame(frame.Id - 1, roll.KnockedDownPins.Quantity);
            else if (player.ScoreCard.HasFrameMarkTypeSpare(frame.Id - 1) && frame.Rolls.Count() == 0)
                player.ScoreCard.AddBonusToFrame(frame.Id - 1, roll.KnockedDownPins.Quantity);
        }

        private void ProcessOrdinaryFrameRoll(IPlayer player, IFrame frame, IRoll roll)
        {
            DetermineFrameMarkType(frame, roll);
            AssingFrameBonuses(player, frame, roll);
        }

        private void AssingFrameBonuses(IPlayer player, IFrame frame, IRoll roll) {
            if (!IsTheVeryLastFrameRoll(frame)) {
                int secondToLastFrameId = frame.Id - 2;
                int lastFrameId = frame.Id - 1;

                if (player.ScoreCard.HasFrameMarkTypeStrike(lastFrameId) && frame.Rolls.Count() < _ordinaryFrameMaxRollsQty) {
                    player.ScoreCard.AddBonusToFrame(lastFrameId, roll.KnockedDownPins.Quantity);
                    if(player.ScoreCard.HasFrameMarkTypeStrike(secondToLastFrameId))
                        player.ScoreCard.AddBonusToFrame(secondToLastFrameId, roll.KnockedDownPins.Quantity);
                }

                if (player.ScoreCard.HasFrameMarkTypeSpare(lastFrameId) && frame.Rolls.Count() == 0)
                    player.ScoreCard.AddBonusToFrame(lastFrameId, roll.KnockedDownPins.Quantity);
            }
        }

        private void DetermineFrameMarkType(IFrame frame, IRoll roll) {
            if (roll.KnockedDownPins.Quantity == _strikePinsQty)
                frame.MarkType = MarkType.Strike;
            else if (frame.Rolls.Any() && IsSpare(frame.Rolls.Last(), roll))
                frame.MarkType = MarkType.Spare;
            else
                frame.MarkType = MarkType.Open;
        }

        private bool IsSpare(IRoll rollOne, IRoll rollTwo) {
            return rollOne.KnockedDownPins.Quantity + rollTwo.KnockedDownPins.Quantity == _strikePinsQty;
        }

        private bool HasOrdinaryFrameEnded(IFrame frame) {
            return frame.MarkType == MarkType.Strike ||
                   frame.MarkType == MarkType.Spare  ||
                   (frame.MarkType == MarkType.Open && frame.Rolls.Count() == _ordinaryFrameMaxRollsQty);
        }

        private bool HasLastFrameEnded(IFrame frame) {
            int rollsCount = frame.Rolls.Count();
            return (rollsCount == _lastFrameMaxRollsQty - 1) && (frame.MarkType == MarkType.Open) ||
                   (rollsCount == _lastFrameMaxRollsQty);
        }

        private int GetFrameMaxRollsQty(IFrame frame)
        {
            if (IsLastFrame(frame))
                return _lastFrameMaxRollsQty;
            return _ordinaryFrameMaxRollsQty;
        }

        private bool IsLastFrame(IFrame frame) {
            return frame.Id == MaxFramesQty;
        }

        private bool IsTheVeryLastFrameRoll(IFrame frame)
        {
            return IsLastFrame(frame) && frame.Rolls.Count() == _lastFrameMaxRollsQty;
        }
    }
}
