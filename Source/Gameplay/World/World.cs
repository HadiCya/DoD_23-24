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

using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using System.Reflection.Metadata;

#endregion

namespace DoD_23_24
{
	public class World
	{
        TiledMap _tiledMap;
        TiledMapRenderer _tiledMapRenderer;

        public World()
		{
            _tiledMap = Globals.content.Load<TiledMap>("LevelTiles/samplemap");
            _tiledMapRenderer = new TiledMapRenderer(Globals.graphics, _tiledMap);

		Player playerInstance;
		NPC npcInstance;
		Dialogue dialogueInstance;

		List<string> conversation = new List<string> { "Hello", "I am book." };

        public World()
		{
            playerInstance = new Player("2D/Sprites/Item", new Vector2(500, 100), new Vector2(32, 32), true);
            npcInstance = new NPC("2D/Sprites/Special1", new Vector2(700, 100), new Vector2(32, 32), true, dialogueInstance);
            dialogueInstance = new Dialogue(conversation);
        }

        public virtual void Update(GameTime gameTime)
		{
            _tiledMapRenderer.Update(gameTime);
        }


		public virtual void Draw()
		{
            _tiledMapRenderer.Draw();
            playerInstance.Update(gameTime);
			dialogueInstance.Update(gameTime);
		}

		public virtual void Draw()
		{
			playerInstance.Draw();
            npcInstance.Draw();
			dialogueInstance.Draw();
		}
	}
}

