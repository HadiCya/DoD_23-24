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
    public class TileMapComponent : Component
    {
        TileMapManager mapManager;
        TmxMap map;
        private List<Entity> collisionObjects;

        public TileMapComponent(Entity entity, String mapPath, String tileSetPath) : base(entity)
        {
            map = new TmxMap(mapPath);
            Texture2D tileSet = Globals.content.Load<Texture2D>(tileSetPath + map.Tilesets[0].Name.ToString());
            int tileWidth = map.Tilesets[0].TileWidth;
            int tileHeight = map.Tilesets[0].TileHeight;
            int tileSetTilesWide = tileSet.Width / tileWidth;
            mapManager = new TileMapManager(map, tileSet, tileSetTilesWide, tileWidth, tileHeight);
            collisionObjects = mapManager.CreateTiles();
            //collisionObjects = new List<Entity>();
            //foreach (TmxObject o in map.ObjectGroups["Collisions"].Objects)
            //{
            //    Entity collisionEntity = new Entity("Tile");
            //    var transform = new TransformComponent(collisionEntity, new Vector2((float)o.X, (float)o.Y), 0.0f, new Vector2((float)o.Width, (float)o.Height));
            //    collisionEntity.AddComponent(transform);
            //    collisionEntity.AddComponent(new CollisionComponent(collisionEntity, true));
            //    collisionObjects.Add(collisionEntity);
            //}
        }

        //public override void Update(GameTime gameTime)
        //{
        //    foreach (Entity tiles in collisionObjects)
        //    {
        //        tiles.Update(gameTime);
        //    }
        //}

        public override void Draw()
        {
            foreach (Entity tiles in collisionObjects)
            {
                tiles.Draw();
            }
        }
    }
}
