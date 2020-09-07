using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin.Game.Actors
{
    public interface Actor
    {
        void SetName(String name);
        void SetAnimation(Animation animation);
        void SetPosition(int posX, int posY);
        String GetName();
        int GetX();
        int GetY();
        int GetWidth();
        int GetHeight();
        Animation GetAnimation();
        World GetWorld();
        void Update();
        void AddedToWorld(World world);
        Boolean IntersectsWithActor(Actor actor);
        Boolean IsAffectedByGravity();
        void SetGravity(Boolean isGravityEnabled);
        void RemoveFromWorld();
        Boolean RemovedFromWorld();
    }
}
