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

namespace DoD_23_24
{
    public class World
    {
        Level level;
        Player playerInstance;
        NPC book;

        public World()
        {
            level = new Level("Content/map.tmx", "Tiny Adventure Pack\\");
            playerInstance = new Player("2D/Sprites/Item", new Vector2(100, 100), new Vector2(16, 16), true, level);
            book = new NPC("2D/Sprites/Special1", new Vector2(100, 200), new Vector2(16, 16), true, "C:\\Users\\User\\Documents\\GitHub\\DoD_23-24\\Content\\NPCText\\TestNPC.txt", playerInstance);
        }

        public virtual void Update(GameTime gameTime)
        {
            playerInstance.Update(gameTime);
            book.Update(gameTime);
        }

        public virtual void Draw()
        {
            level.Draw();
            playerInstance.Draw();
            book.Draw();
        }

        public Player GetPlayer()
        {
            return playerInstance;
        }
    }
}