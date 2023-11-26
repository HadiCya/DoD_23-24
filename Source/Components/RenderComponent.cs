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
	public class RenderComponent : Component
	{
		public Texture2D myModel;

		TransformComponent transform;

		Rectangle? destinationRectangle;

		public RenderComponent(Entity entity, string PATH) : base(entity)
		{
			destinationRectangle = null;
            transform = entity.GetComponent<TransformComponent>();
			myModel = Globals.content.Load<Texture2D>(PATH);
        }

		public RenderComponent(Entity entity, Texture2D myModel, Rectangle destinationRectangle) : base(entity)
		{
			transform = entity.GetComponent<TransformComponent>();
			this.destinationRectangle = destinationRectangle;
			this.myModel = myModel;
		}

		public override void Draw()
		{
			if(myModel != null)
			{
				Globals.spriteBatch.Draw(myModel,
					new Rectangle((int)transform.pos.X, (int)transform.pos.Y, (int)transform.dims.X, (int)transform.dims.Y),
					destinationRectangle, Color.White, transform.rot, new Vector2(myModel.Bounds.Width / 2, myModel.Bounds.Height / 2),
					new SpriteEffects(), 0);
			}
		}
	}
}

