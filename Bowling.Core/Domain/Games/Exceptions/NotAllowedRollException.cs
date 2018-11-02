using System;

namespace Bowling.Core.Domain.Games.Exceptions
{
    public class NotAllowedRollException : Exception
    {
        public NotAllowedRollException(string message) : base(message) { }
    }
}
