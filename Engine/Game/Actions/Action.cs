using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin.Game.Actions
{
    public interface Action<T>
    {

        public String GetActionName();

        public void Execute(T t);

    }
}
