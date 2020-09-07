using Merlin.Game.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin.Game
{
    public interface Physics : Command
    {
        void SetWorld(World world);
    }
}
