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

#endregion

namespace DoD_23_24
{
	public class World
	{
		Player playerInstance;
        public World(Player player)
		{
			playerInstance = player;
        }

		public virtual void Update(GameTime gameTime)
		{
            playerInstance.Update(gameTime);
		}

		public virtual void Draw()
		{
			playerInstance.Draw();
		}


	}
}

