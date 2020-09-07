using Merlin.Game.Actors;
using Merlin.Game.Exceptions;
using Merlin.Game.Items;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiledSharp;

namespace Merlin.Game
{
    public class GameWorld : World
    {
        private static String WALL_LAYER = "walls";
        private static String BACKGROUND_LAYER = "background";
        private static int BORDER = 2;
        private String mapResource = null;
        private Map tiledMap = null;
        private Factory factory = null;
        private Scenario scenario = null;
        private List<Actor> actors = new List<Actor>();
        private List<Actor> actorsToAdd = new List<Actor>();
        private List<Actor> triggers = new List<Actor>();
        private Actor centeredOn;
        private Message message;
        private Inventory inventory;
        private Boolean debugGraphics = false;
        //private Class<? extends Actor>[] renderOrder;
        //private SlickWorld slickWorld;
        private Physics gameLevelPhysics;
        //private int ID;

        //public GameWorld(SlickWorld slickWorld)
        //{
        //    this();
        //    this.slickWorld = slickWorld;

        //}

        public GameWorld()
        {

        }


        //public int getID()
        //{
        //    return ID;
        //}


        //public void Initialize(GameContainer gc, StateBasedGame sbg)
        //{

        //}

        public void SetMap(String resource)
        {
            this.mapResource = resource;
            LoadMap();
        }

        protected void LoadMap()
        {
            //try
            //{
            //    this.actors.clear();
            //    TiledMapFixer.fixTiledMap(this.mapResource);
            //    this.tiledMap = new TiledMap(this.mapResource);

            //    loadActors();
            //    for (Actor actor : this.actors)
            //    {
            //        actor.addedToWorld(this);
            //    }
            //}
            //catch (SlickException ex)
            //{
            //    throw new GameException(ex);
            //}
            this.actors.Clear();
            tiledMap = new Map(this.mapResource);
            //var version = tiledMap.Version;
        }

        //    protected void LoadActors()
        //    {
        //        for (int groupID = 0; groupID < this.tiledMap.getObjectGroupCount(); groupID++) {
        //            for (int objectID = 0; objectID < this.tiledMap.getObjectCount(groupID); objectID++)
        //            {
        //                String type = this.tiledMap.getObjectType(groupID, objectID);
        //                String name = this.tiledMap.getObjectName(groupID, objectID);
        //                if (this.factory != null)
        //                {
        //                    Actor actor = this.factory.create(type, name);
        //                    if (actor != null)
        //                    {
        //                        actor.SetPosition(this.tiledMap.getObjectX(groupID, objectID), this.tiledMap.getObjectY(groupID, objectID));
        //                        addActor(actor);
        //                    }
        //                }

        //            }
        //        }

        //        if (this.scenario != null) {
        //            scenario.CreateActors(this);
        //        }
        //    }

        public void SetFactory(Factory factory)
        {
            this.factory = factory;
        }

        public void SetScenario(Scenario scenario)
        {
            this.scenario = scenario;
        }

        public void SetPhysics(Physics physics)
        {
            this.gameLevelPhysics = physics;
            if (physics != null)
            {
                physics.SetWorld(this);
            }
        }

        public void CenterOn(Actor actor)
        {
            this.centeredOn = actor;
        }


        private bool IsWall(int x, int y)
        {
            return tiledMap.IsWall(x, y);
        }

        public void SetWall(int x, int y, bool wall)
        {
            tiledMap.SetWall(x, y, wall);
        }

        public bool IntersectWithWall(Actor actor)
        {
            if (this.tiledMap == null)
            {
                return false;
            }
            int tileWidth = this.tiledMap.TileWidth;
            int tileHeight = this.tiledMap.TileHeight;

            int tileXStart = (actor.GetX() + 2) / tileWidth;
            int tileXEnd = (actor.GetX() + actor.GetWidth() - 4) / tileWidth;
            int tileYStart = (actor.GetY() + 2) / tileHeight;
            int tileYEnd = (actor.GetY() + actor.GetHeight() - 4) / tileHeight;
            for (int tileX = tileXStart; tileX <= tileXEnd; tileX++)
            {
                for (int tileY = tileYStart; tileY <= tileYEnd; tileY++)
                {
                    if (IsWall(tileX, tileY))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void AddActor(Actor actor)
        {
            actorsToAdd.Add(actor);
        }

        private void AddActors()
        {
            if (!(actorsToAdd.Count == 0))
            {
                actorsToAdd.ForEach(actor =>
                {
                    this.actors.Add(actor);
                    actor.AddedToWorld(this);
                });
                actorsToAdd.Clear();
            }
        }


        public void RemoveActor(Actor actor)
        {
            actor.RemoveFromWorld();
        }

        //public Iterator<Actor> iterator()
        //{
        //    return this.actors.iterator();
        //}

        public void ShowMessage(Message message)
        {
            this.message = message;
        }

        public void ShowInventory(Inventory inventory)
        {
            this.inventory = inventory;
        }

        private int GetXOffset(GameContainer gc)
        {
            if (this.centeredOn != null)
            {
                return (gc.GetWidth() - this.centeredOn.GetWidth()) / 2 - this.centeredOn.GetX();
            }
            return 0;
        }

        private int GetYOffset(GameContainer gc)
        {
            if (this.centeredOn != null)
            {
                return (gc.GetHeight() - this.centeredOn.GetHeight()) / 2 - this.centeredOn.GetY();
            }
            return 0;
        }

        public void Update(int i)
        {
            //if (Input.GetInstance().IsKeyPressed(1))
            //{
            //    gc.getInput().clearControlPressedRecord();
            //    ((SlickWorld)sbg).setCurrentGameID(this.ID);
            //    sbg.enterState(0);
            //}

            AddActors();
            List<Actor> listOfActors = new List<Actor>();

            triggers.ForEach(trigger => trigger.Update());

            foreach (Actor actor in actors)
            {
                actor.Update();
            }
            actors.RemoveAll(actor => actor.RemovedFromWorld());
            if (gameLevelPhysics != null)
            {
                gameLevelPhysics.Execute();
            }

        }

        //public void setRenderOrder(Class<? extends Actor>...actorClasses)
        //{
        //    this.renderOrder = actorClasses;
        //}

        public void Render(GameContainer gc)
        {
            //graphics.drawString("Current game state: " + String.valueOf(ID), 10, 30);
            if (this.centeredOn != null)
            {
                throw new NotImplementedException();
                //graphics.translate(getXOffset(gc), getYOffset(gc));
            }
            RenderMap();
            if (this.debugGraphics)
            {
                //graphics.setColor(org.newdawn.slick.Color.green);

                int width = this.tiledMap.Width;
                int height = this.tiledMap.Height;
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        if (IsWall(x, y))
                        {
                            throw new NotImplementedException();
                            //graphics.fillRect(x * this.tiledMap.getTileWidth(), y * this.tiledMap.getTileHeight(), this.tiledMap.getTileWidth(), this.tiledMap.getTileHeight());
                        }
                    }
                }
            }
            RenderActors(this.actors);
            RenderActors(this.triggers);
            if (this.centeredOn != null)
            {
                //graphics.translate(-GetXOffset(gc), -getYOffset(gc));
                throw new NotImplementedException();
            }
            RenderInventory(gc);

            RenderMessage();
        }

        private void RenderMap()
        {
            int width = this.tiledMap.Width;
            int height = this.tiledMap.Height;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (IsWall(x, y))
                    {
                        //throw new NotImplementedException();

                        //graphics.fillRect(x * this.tiledMap.getTileWidth(), y * this.tiledMap.getTileHeight(), this.tiledMap.getTileWidth(), this.tiledMap.getTileHeight());
                        Raylib.DrawRectangle(x * this.tiledMap.TileWidth, y * this.tiledMap.TileHeight,
                            this.tiledMap.TileWidth, this.tiledMap.TileHeight, Raylib_cs.Color.WHITE);
                    }
                }
            }
        }


        private void RenderActors(List<Actor> listOfActors)
        {
            //if (this.renderOrder == null)
            //{
            foreach (Actor actor in listOfActors)
            {
                Animation animation = actor.GetAnimation();
                if (animation != null)
                {
                    animation.Draw(actor.GetX(), actor.GetY());
                }
                else
                {
                    throw new MissingAnimationException("Animation missing for" + actor.GetType().ToString());
                }
            }
            if (this.centeredOn != null)
            {
                throw new NotImplementedException();
                //this.centeredOn.getAnimation().draw(this.centeredOn.getX(), this.centeredOn.getY());
            }
            //}
            //else
            //{
            //    for (Class actorClass : this.renderOrder)
            //    {
            //        renderActorsOfType(graphics, actorClass);
            //    }
            //}
        }

        //    private void renderActorsOfType(Graphics graphics, Class<? extends Actor> type)
        //{
        //    for (Actor actor : this.actors) {
        //    if (type.isInstance(actor))
        //    {
        //        Animation animation = actor.getAnimation();
        //        if (animation != null)
        //        {
        //            animation.draw(actor.getX(), actor.getY());
        //        }
        //        else
        //        {
        //            throw new IllegalStateException("Animation missing for" + actor.getClass().getName());
        //        }
        //    }
        //}
        //    }

        private void RenderInventory(GameContainer gc)
        {
            int x;
            if (this.inventory != null)
            {
                x = 4;


                throw new NotImplementedException();
                //graphics.setColor(Color.BLACK);
                //graphics.fillRect(0.0F, gc.GetHeight() - 24, gc.GetWidth(), gc.GetHeight());
                foreach (Item item in this.inventory)
                {
                    item.GetAnimation().Draw(x, gc.GetHeight() - 20, 16, 16);
                    x += item.GetWidth() + 4;
                }

                //graphics.setColor(color);
                //        }
                //    }
            }
        }

        private void RenderMessage()
        {
            if (this.message != null)
            {
                Raylib.DrawText(message.GetText(), message.GetX(), message.GetY(),
                                message.GetFontSize(), message.GetColor());
            }
        }

        public List<Actor> GetActors()
        {
            return actors;
        }

        public Actor GetActorByName(String name)
        {
            return actors.FirstOrDefault(actor => actor.GetName().Equals(name));
        }


        public int GetTileWidth()
        {
            return this.tiledMap.TileWidth;
        }


        public int GetTileHeight()
        {
            return this.tiledMap.TileHeight;
        }
    }
}
