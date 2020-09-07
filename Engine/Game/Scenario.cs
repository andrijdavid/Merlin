using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin.Game
{
    public interface Scenario
    {
        void CreateActors(World world);
    }
}
