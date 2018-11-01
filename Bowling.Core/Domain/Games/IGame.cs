namespace Bowling.Core.Domain.Games
{
    public interface IGame
    {
        void StartAutoPlay();
        void StartFrame(int frameNumber);
    }
}