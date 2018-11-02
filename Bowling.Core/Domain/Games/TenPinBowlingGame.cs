using Bowling.Core.Domain.Frames;
using Bowling.Core.Domain.Games.EventDriven;
using Bowling.Core.Domain.Games.EventDriven.Events;
using Bowling.Core.Domain.Lanes;
using Bowling.Core.Domain.Players;
using Bowling.Core.Domain.Rolls;
using Bowling.Core.Domain.Scoring;
using Bowling.Core.Strategies.RollHandling;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling.Core.Domain.Games
{
    public class TenPinBowlingGame : IEventDrivenBowlingGame
    {
        private TenPinBowlingGameRules _rules;
        private IEnumerable<IPlayer> _players;
        private ILane _lane;
        private ScoreBoard _scoreBoard;

        public TenPinBowlingGame(IEnumerable<string> playerNames) {
            if (playerNames == null)
                throw new ArgumentNullException("playerNames may not be null");
            if (playerNames.Count() == 0)
                throw new ArgumentException("At least one player name is needed to create a game");
            
            _rules = new TenPinBowlingGameRules();
            _lane = new Lane(_rules, new RollProcessingStrategyFactory().CreateRollProcessingStrategy());
            CreatePlayers(playerNames);
            CreateScoreBoard();
        }

        public event EventHandler<FrameStartedEventArgs> FrameStarted;
        public event EventHandler<FrameEndedEventArgs> FrameEnded;
        public event EventHandler<RollEndedEventArgs> RollEnded;
        public event EventHandler<GameEndedEventArgs> GameEnded;

        public void OnFrameStarted(FrameStartedEventArgs eventArgs) => FrameStarted?.Invoke(this, eventArgs);
        public void OnFrameEnded(FrameEndedEventArgs eventArgs) => FrameEnded?.Invoke(this, eventArgs);
        public void OnRollEnded(RollEndedEventArgs eventArgs) => RollEnded?.Invoke(this, eventArgs);
        public void OnGameEnded(GameEndedEventArgs eventArgs) => GameEnded?.Invoke(this, eventArgs);

        public void StartAutoPlay() {
            for (int i = 1; i <= _rules.MaxFramesQty; i++) {
                StartFrame(i);
            }

            OnGameEnded(new GameEndedEventArgs { ScoreBoard = _scoreBoard, MaxFramesQty = _rules.MaxFramesQty });
        }

        public void StartFrame(int frameNumber) {
            foreach (IPlayer player in _players) {
                IFrame frame = new Frame(frameNumber);
                OnFrameStarted(new FrameStartedEventArgs { Frame = frame, PlayerName = player.Name });
                player.ScoreCard.AddFrame(frame);

                do
                {
                    IRoll roll = player.DoRoll(frame, 10, 10);
                    OnRollEnded(new RollEndedEventArgs { Roll = roll });
                } while (!_rules.HasFrameEnded(frame));

                OnFrameEnded(new FrameEndedEventArgs { Frame = frame, PlayerScoreCard = player.ScoreCard});

                _lane.Reset();
            }
        }

        private void CreatePlayers(IEnumerable<string> playerNames) {
            IList<IPlayer> players = new List<IPlayer>();

            foreach (string playerName in playerNames) {
                players.Add(new Player(playerName, _rules, _lane));
            }
            _players = players;
        }

        private void CreateScoreBoard() {
            _scoreBoard = new ScoreBoard(_players);
        }
    }
}
