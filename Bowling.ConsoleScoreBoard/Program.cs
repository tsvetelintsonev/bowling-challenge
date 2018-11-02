using Bowling.Core.Domain.Frames;
using Bowling.Core.Domain.Games;
using Bowling.Core.Domain.Games.EventDriven;
using Bowling.Core.Domain.Games.EventDriven.Events;
using Bowling.Core.Domain.Players;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling.ConsoleScoreBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            IEventDrivenBowlingGame bowlingGame = new TenPinBowlingGame(new List<string>{ "Henrik", "Jesper" });

            bowlingGame.FrameStarted += (object sender, FrameStartedEventArgs e) => Console.WriteLine($"{e.PlayerName} started frame {e.Frame.Id}");
            bowlingGame.RollEnded += (object sender, RollEndedEventArgs e) => Console.WriteLine($"Roll ended with {e.Roll.KnockedDownPins.Quantity} knocked down pin(s)");
            bowlingGame.FrameEnded += (object sender, FrameEndedEventArgs e) => {
                Console.WriteLine($"Frame {e.Frame.Id} ended with total score of {e.Frame.TotalScore} ({e.Frame.MarkType.ToString()})");
                Console.WriteLine();
            };

            bowlingGame.GameEnded += (object sender, GameEndedEventArgs e) =>
            {
                string scoreBoardHeaderLine = "Player name  |";
                for (int i = 1; i <= e.MaxFramesQty; i++)
                {
                    scoreBoardHeaderLine += $"   Frame {i}  |";
                }
                scoreBoardHeaderLine += $"   Total  |";
                Console.WriteLine(scoreBoardHeaderLine);

                
                foreach (IPlayer player in e.ScoreBoard.Players)
                {
                    string scoreBoardPlayerResultsLine = string.Empty;
                    scoreBoardPlayerResultsLine += $"{player.Name}       ";
                    foreach (IFrame frame in player.ScoreCard.Frames) {
                        scoreBoardPlayerResultsLine += 
                            $"   {string.Join("+", frame.Rolls.Select(x => x.KnockedDownPins.Quantity.ToString()))} " +
                            $"({player.ScoreCard.TotalScoreUpToFrame(frame).ToString()})   ";
                    }
                    scoreBoardPlayerResultsLine += $"{player.ScoreCard.TotalScore}";
                    Console.WriteLine(scoreBoardPlayerResultsLine);
                }
            };

            bowlingGame.StartAutoPlay();

            Console.ReadLine();
        }
    }
}
