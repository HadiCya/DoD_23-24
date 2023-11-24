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
	public class Player : Entity
	{
        public Player(string PATH, Vector2 POS, float ROT, Vector2 DIMS)
		{
            this.AddComponent(new TransformComponent(this, POS, ROT, DIMS));
            this.AddComponent(new RenderComponent(this, PATH));
            this.AddComponent(new CameraComponent(this));
            this.AddComponent(new InputComponent(this));
        }

        public void Update(GameTime gameTime)
        {
            this.GetComponent<InputComponent>().Movement(gameTime);
        }

        public void Draw()
        {
            GetComponent<RenderComponent>().Draw();
        }
    }
}