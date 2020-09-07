using Merlin.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin.Game
{
    public interface Factory
    {

        Actor create(String actorType, String actorName);
    }
}
