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
using System.IO;

#endregion

namespace DoD_23_24
{
	public class World
	{
		Mahdi mahdi;

        public World()
        {
            mahdi = new Mahdi("merlin_172064805_d476abdd-f4da-4015-8ca3-8c45c92c61fa-articleLarge", new Vector2(50, 50), new Vector2(50, 50) ,true);
        }

        public virtual void Update(GameTime gameTime)
        {
            mahdi.Update(gameTime);
        }

		public virtual void Draw()
		{
			mahdi.Draw();
		}


	}
}

