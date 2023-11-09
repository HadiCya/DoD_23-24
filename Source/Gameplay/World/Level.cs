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
using System.Numerics;

namespace DoD_23_24
{
	public class Level
	{
        TileMapManager mapManager;
        TmxMap map;
        private List<Rectangle> collisionObjects;

        public Level(String mapPath, String tileSetPath)
		{
            map = new TmxMap(mapPath);
            Texture2D tileSet = Globals.content.Load<Texture2D>(tileSetPath + map.Tilesets[0].Name.ToString());
            int tileWidth = map.Tilesets[0].TileWidth;
            int tileHeight = map.Tilesets[0].TileHeight;
            int tileSetTilesWide = tileSet.Width / tileWidth;
            mapManager = new TileMapManager(Globals.spriteBatch, map, tileSet, tileSetTilesWide, tileWidth, tileHeight);

            collisionObjects = new List<Rectangle>();
            foreach (var o in map.ObjectGroups["Collisions"].Objects)
            {
                collisionObjects.Add(new Rectangle((int)o.X, (int)o.Y, (int)o.Width, (int)o.Height));
            }
        }

        public bool CheckCollision(Rectangle playerBounds)
        {
            foreach (var rect in collisionObjects)
            {
                if (rect.Intersects(playerBounds))
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw()
        {
            mapManager.Draw();
        }
	}
}

