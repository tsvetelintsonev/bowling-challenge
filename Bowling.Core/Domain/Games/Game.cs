using Bowling.Core.Domain.Frames;
using Bowling.Core.Domain.Lanes;
using Bowling.Core.Domain.Players;
using Bowling.Core.Domain.Scoring;
using Bowling.Core.Strategies.RollHandling;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling.Core.Domain.Games
{
    public class Game : IGame
    {
        private IEnumerable<IPlayer> _players;
        private ILane _lane;
        private ScoreBoard _scoreBoard;

        public Game(IEnumerable<string> playerNames) {
            if (playerNames == null)
                throw new ArgumentNullException("playerNames may not be null");
            if (playerNames.Count() == 0)
                throw new ArgumentException("Please provide at least one player name");

            _lane = new Lane(new RollHandlingStrategyFactory().CreateRollHandilngStrategy());
            CreatePlayers(playerNames);
            CreateScoreBoard();
        }

        public void StartAutoPlay() {
            for (int i = 1; i <= 10; i++) {
                StartFrame(i);
            }
        }

        public void StartFrame(int frameNumber) {
            IFrame frame = new Frame(frameNumber, 2);
            foreach (IPlayerScoreCard playerScoreCard in _scoreBoard.PlayerScoreCards) {
                playerScoreCard.AddFrame(frame);
                playerScoreCard.Player.PlayFrame(frame);
                _lane.Reset();
            }
        }

        private void CreatePlayers(IEnumerable<string> playerNames) {
            IList<IPlayer> players = new List<IPlayer>();

            foreach (string playerName in playerNames) {
                players.Add(new Player(playerName, _lane));
            }
            _players = players;
        }

        private void CreateScoreBoard() {
            _scoreBoard = new ScoreBoard(CreatePlayerScoreCards());
        }

        private IEnumerable<IPlayerScoreCard> CreatePlayerScoreCards() {
            foreach (Player player in _players) {
                yield return new PlayerScoreCard(player);
            }
        }
    }
}
