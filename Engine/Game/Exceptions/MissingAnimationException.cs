using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin.Game.Exceptions
{
    public class MissingAnimationException : Exception
    {
        public MissingAnimationException(string message) : base(message)
        {
        }
    }
}
