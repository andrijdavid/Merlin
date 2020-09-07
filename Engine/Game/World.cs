using Merlin.Game.Actors;
using Merlin.Game.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin.Game
{
    public interface World
    {

        void AddActor(Actor actor);
        void RemoveActor(Actor actor);
        //IEnumerator<Actor> GetEnumerator();
        Boolean IntersectWithWall(Actor actor);
        List<Actor> GetActors();
        void ShowMessage(Message message);
        //    boolean isWall(int x, int y);
        void SetWall(int x, int y, Boolean wall);
        Actor GetActorByName(String name);

        int GetTileWidth();
        int GetTileHeight();

        void CenterOn(Actor actor);

        void ShowInventory(Inventory inventory);
        void SetFactory(Factory factory);
        void SetScenario(Scenario scenario);
        void SetMap(string path);
        void SetPhysics(Physics physics);
    }
}
