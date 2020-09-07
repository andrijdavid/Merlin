using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin.Game.Exceptions
{
    public class GameException : Exception
    {

        public GameException(String message) : base(message)
        {

        }
    }
}
