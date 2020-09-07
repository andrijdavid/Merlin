using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin.Game
{
    public class Animation : IDisposable
    {

        private Texture2D texture = Raylib.LoadTexture("resources/raylib-cs_logo.png");
        private String resource;
        private int width;
        private int height;
        private int duration;
        private int rotation;
        private Boolean looping = true;
        private Boolean pingPong = false;

        private Boolean isFlipped = false;
        private bool disposedValue;

        public Animation(String resource, int width, int height, int duration)
        {
            this.resource = resource;
            this.width = width;
            this.height = height;
            this.duration = duration;
        }

        public Animation(String resource, int width, int height) : this(resource, width, height, 10)
        {

        }

        public String GetResource()
        {
            return this.resource;
        }

        public int GetWidth()
        {
            return this.width;
        }

        public int GetHeight()
        {
            return this.height;
        }

        public int GetDuration()
        {
            return this.duration;
        }

        public int GetRotation()
        {
            return this.rotation;
        }

        public void Draw(int x, int y)
        {
            //getslickanimation().draw(x, y);
            throw new NotImplementedException();
        }

        public void Draw(int x, int y, int width, int height)
        {
            //getSlickAnimation().draw(x, y, width, height);
            throw new NotImplementedException();
        }

        //private org.newdawn.slick.Animation getSlickAnimation()
        //{
        //    if (this.slickAnimation == null)
        //    {
        //        this.slickAnimation = AnimationCache.getInstance().loadAnimation(this.resource, this.width, this.height, this.duration);
        //        getSlickAnimation().setPingPong(this.pingPong);
        //        getSlickAnimation().setLooping(this.looping);
        //    }
        //    return this.slickAnimation;
        //}

        public void Stop()
        {
            //getSlickAnimation();
            //if (this.slickAnimation != null)
            //{
            //    getSlickAnimation().stop();
            //}
        }

        public void Start()
        {
            //if (this.slickAnimation != null)
            //{
            //    getSlickAnimation().start();
            //}
        }

        public void SetPingPong(Boolean pingPong)
        {
            //this.pingPong = pingPong;
            //if (this.slickAnimation != null)
            //{
            //    this.slickAnimation.setPingPong(pingPong);
            //}
        }

        public void SetLooping(Boolean looping)
        {
            //this.looping = looping;
            //if (this.slickAnimation != null)
            //{
            //    this.slickAnimation.setLooping(looping);
            //}
        }

        public void StopAt(int frameIndex)
        {
            //if (this.slickAnimation != null)
            //{
            //    this.slickAnimation.stopAt(frameIndex);
            //}
        }

        public void SetCurrentFrame(int frameIndex)
        {
            //if (this.slickAnimation != null)
            //{
            //    this.slickAnimation.setCurrentFrame(frameIndex);
            //}
        }

        public int GetCurrentFrame()
        {
            //if (this.slickAnimation != null)
            //{
            //    return this.slickAnimation.getFrame();
            //}
            return -1;
        }

        public int GetFrameCount()
        {
            //if (this.slickAnimation != null)
            //{
            //    return this.slickAnimation.getFrameCount();
            //}
            return -1;
        }

        public void SetDuration(int duration)
        {
            //this.duration = duration;
            //if (this.slickAnimation != null)
            //{
            //    for (int i = 0; i < this.slickAnimation.getFrameCount(); i++)
            //    {
            //        this.slickAnimation.setDuration(i, duration);
            //    }
            //}
        }

        public void SetRotation(int angle)
        {
            //this.rotation = (angle % 360);
            //org.newdawn.slick.Animation newAnimation = new org.newdawn.slick.Animation();
            //for (int i = 0; i < getSlickAnimation().getFrameCount(); i++)
            //{
            //    Image image = this.slickAnimation.getImage(i);
            //    image.setRotation(angle);
            //    newAnimation.addFrame(image, this.slickAnimation.getDuration(i));
            //}
            //newAnimation.setLooping(this.looping);
            //newAnimation.setPingPong(this.pingPong);
            //setDuration(this.duration);

            //this.slickAnimation = newAnimation;
        }

        //private static class AnimationCache
        //{

        //    private static AnimationCache instance = new AnimationCache();
        //    private Map<String, SpriteSheet> cachedSpritesSheet = new HashMap<String, SpriteSheet>();

        //    static AnimationCache getInstance()
        //    {
        //        return instance;
        //    }

        //    SpriteSheet loadSpriteSheet(String resource, int tileWidth, int tileHeight)
        //    {
        //        try
        //        {
        //            SpriteSheet spriteSheet = (SpriteSheet)this.cachedSpritesSheet.get(resource);
        //            if (spriteSheet == null)
        //            {
        //                spriteSheet = new SpriteSheet(resource, tileWidth, tileHeight);
        //                this.cachedSpritesSheet.put(resource, spriteSheet);
        //            }
        //            return spriteSheet;
        //        }
        //        catch (Throwable e)
        //        {
        //            throw new RuntimeException(e);
        //        }
        //    }

        //    org.newdawn.slick.Animation loadAnimation(String resource, int tileWidth, int tileHeight, int duration)
        //    {
        //        return new org.newdawn.slick.Animation(loadSpriteSheet(resource, tileWidth, tileHeight), duration);
        //    }
        //}

        public void FlipAnimation()
        {
            //Raylib.
            //org.newdawn.slick.Animation slickAnimation = new org.newdawn.slick.Animation();
            //org.newdawn.slick.Animation oldAnimation = getSlickAnimation();
            //for (int i = 0; i < oldAnimation.getFrameCount(); i++)
            //{
            //    slickAnimation.addFrame(oldAnimation.getImage(i).getFlippedCopy(true, false), duration);
            //}

            ////this.slickAnimation = slickAnimation;
            //slickAnimation.restart();
            //slickAnimation.setCurrentFrame(oldAnimation.getFrame());
            //slickAnimation.update(0);

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                Raylib.UnloadTexture(texture);
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Animation()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
