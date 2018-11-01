﻿using Bowling.Core.Domain.Frames;
using Bowling.Core.Domain.Lanes;

namespace Bowling.Core.Domain.Players
{
    public interface IPlayer
    {
        ILane Lane { get; }
        string Name { get; }
        IFrame CurrentFrame { get; set; }

        void PlayFrame(IFrame frame);
    }
}