namespace Bowling.Core.Strategies.RollHandling
{
    public class RollProcessingStrategyFactory : IRollProcessingStrategyFactory
    {
        public IRollProcessingStrategy CreateRollProcessingStrategy() {
            return new RollProcessingStrategy();
        }
    }
}
