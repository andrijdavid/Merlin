using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiledSharp;

namespace Merlin.Game
{
    public class Map
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int TileWidth { get; private set; }
        public int TileHeight { get; private set; }

        private int[,] walls;
        private int[,] background;

        private Texture2D[] textures;

        public Map(string mapResource)
        {
            TmxMap tiledMap = new TmxMap(mapResource);
            Width = tiledMap.Width;
            Height = tiledMap.Height;
            //TileWidth = tiledMap.Width;
            //TileHeight = tiledMap.Height;
            TileWidth = 16;
            TileHeight = 16;
            LoadWalls(tiledMap);
            //LoadBackground(tiledMap);
            //Image image = Raylib.LoadImage("");
            //image.
            //Raylib.drawtextu
            //textures[0] = Raylib.LoadTextureFromImage(image);
        }

        private void LoadWalls(TmxMap tiledMap)
        {
            walls = new int[tiledMap.Width, tiledMap.Height];

            for (int x = 0; x < tiledMap.Width; x++)
            {
                for (int y = 0; y < tiledMap.Height; y++)
                {
                    walls[x,y] = tiledMap.Layers["walls"].Tiles.Single(tile => tile.X == x && tile.Y == y).Gid;
                }
            }
        }

        private void LoadBackground(TmxMap tiledMap)
        {
            background = new int[tiledMap.Width, tiledMap.Height];

            for (int x = 0; x < tiledMap.Width; x++)
            {
                for (int y = 0; y < tiledMap.Height; y++)
                {
                    walls[x, y] = tiledMap.Layers["background"].Tiles.Single(tile => tile.X == x && tile.Y == y).Gid;

                }
            }
        }

        public bool IsWall(int x, int y)
        {
            return walls[x, y] != 0;
        }

        public void SetWall(int x, int y, bool wall)
        {
            walls[x, y] = wall ? 1 : 0;
        }


    }
}
