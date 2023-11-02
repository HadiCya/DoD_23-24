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
        Player playerInstance;
        NPC npcInstance;
        Dialogue dialogueInstance;
        List<string> conversation = new List<string> { "Hello", "I am book." };

        public World()
        {
            map = new TmxMap("Content\\map.tmx");
            var tileSet = Globals.content.Load<Texture2D>("Tiny Adventure Pack\\" + map.Tilesets[0].Name.ToString());
            var tileWidth = map.Tilesets[0].TileWidth;
            var tileHeight = map.Tilesets[0].TileHeight;
            var tileSetTilesWide = tileSet.Width / tileWidth;
            mapManager = new TileMapManager(Globals.spriteBatch, map, tileSet, tileSetTilesWide, tileWidth, tileHeight);

            playerInstance = new Player("2D/Sprites/Item", new Vector2(100, 100), new Vector2(32, 32), true);
            npcInstance = new NPC("2D/Sprites/Special1", new Vector2(100, 200), new Vector2(32, 32), true, new Dialogue(conversation));
        }

        public virtual void Update(GameTime gameTime)
        {
            playerInstance.Update(gameTime);
            npcInstance.Update(gameTime);
        }

        public virtual void Draw()
        {
            mapManager.Draw();
            playerInstance.Draw();
            npcInstance.Draw();
        }

        public Player GetPlayer()
        {
            return playerInstance;
        }
    }
}

