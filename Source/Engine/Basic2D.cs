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
	public class Basic2D
	{
		public Vector2 pos, dims;

		public Texture2D myModel;

		public Basic2D(string PATH, Vector2 POS, Vector2 DIMS, bool shouldScale)
		{
			pos = POS;
			myModel = Globals.content.Load<Texture2D>(PATH);    
			float scale = Math.Min(DIMS.X / myModel.Width, DIMS.Y / myModel.Height);
			dims = new Vector2(myModel.Width * (shouldScale ? scale : 1.0f), myModel.Height * (shouldScale ? scale : 1.0f));
        }

        public virtual void Update(GameTime gameTime)
		{

		}

		public virtual void Draw()
		{
			if(myModel != null)
			{
				Globals.spriteBatch.Draw(myModel, new Rectangle((int)(pos.X), (int)(pos.Y), (int)dims.X, (int)dims.Y), null, Color.White, 0.0f, new Vector2(myModel.Bounds.Width / 2, myModel.Bounds.Height / 2), new SpriteEffects(), 0);
			}
		}
	}
}

