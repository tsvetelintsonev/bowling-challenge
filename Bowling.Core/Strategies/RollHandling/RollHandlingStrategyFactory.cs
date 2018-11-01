namespace Bowling.Core.Strategies.RollHandling
{
    public class RollHandlingStrategyFactory : IRollHandlingStrategyFactory
    {
        public IRollHandlingStrategy CreateRollHandilngStrategy() {
            return new RollHandlingStrategy();
        }
    }
}
