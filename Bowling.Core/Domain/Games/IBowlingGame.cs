namespace Bowling.Core.Domain.Games
{
    public interface IBowlingGame
    {
        void StartAutoPlay();
        void StartFrame(int frameNumber);
    }
}