#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using System.Reflection.Metadata;

#endregion
using TiledSharp;

namespace DoD_23_24
{
    public class World
    {
        TileMapManager mapManager;
        TmxMap map;
        private List<Rectangle> collisionObjects;

        Player playerInstance;

        public World()
        {
            map = new TmxMap("Content/map.tmx");
            Texture2D tileSet = Globals.content.Load<Texture2D>("Tiny Adventure Pack\\" + map.Tilesets[0].Name.ToString());
            int tileWidth = map.Tilesets[0].TileWidth;
            int tileHeight = map.Tilesets[0].TileHeight;
            int tileSetTilesWide = tileSet.Width / tileWidth;
            mapManager = new TileMapManager(Globals.spriteBatch, map, tileSet, tileSetTilesWide, tileWidth, tileHeight);

            collisionObjects = new List<Rectangle>();
            foreach(var o in map.ObjectGroups["Collisions"].Objects)
            {
                collisionObjects.Add(new Rectangle((int)o.X, (int)o.Y, (int)o.Width, (int)o.Height));
            }

            playerInstance = new Player("2D/Sprites/Item", new Vector2(100, 100), new Vector2(16, 16), true);
        }

        public virtual void Update(GameTime gameTime)
        {
            var initPos = playerInstance.pos;
            playerInstance.Update(gameTime);
            foreach(var rect in collisionObjects)
            {
                if (rect.Intersects(playerInstance.playerBounds))
                {
                    playerInstance.pos = initPos;
                }
            }
        }

        public virtual void Draw()
        {
            mapManager.Draw();
            playerInstance.Draw();
        }

        public Player GetPlayer()
        {
            return playerInstance;
        }
    }
}

