using System;

namespace Bowling.Core.Domain.Games.Exceptions
{
    public class RollNotAllowedException : Exception
    {
        public RollNotAllowedException(string message) : base(message) { }
    }
}
