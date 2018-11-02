namespace Bowling.Core.Strategies.RollHandling
{
    public interface IRollProcessingStrategyFactory
    {
        IRollProcessingStrategy CreateRollProcessingStrategy();
    }
}