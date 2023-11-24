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
using System.Reflection.Emit;
#endregion
namespace DoD_23_24
{
	public class InputComponent : Component
	{
        TransformComponent transform;
        CameraComponent camera;
        public float speed = 50f;

        public InputComponent(Entity entity) : base(entity)
		{
            transform = entity.GetComponent<TransformComponent>();
            camera = entity.GetComponent<CameraComponent>();
        }

        public void Movement(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();

            //Vector2 initPos = transform.pos;

            if (kstate.IsKeyDown(Keys.Left))
            {
                transform.pos.X -= speed * camera.zoom * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Right))
            {
                transform.pos.X += speed * camera.zoom * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            transform.playerBounds.X = (int)transform.pos.X - (int)(transform.dims.X / 2);
            //if (level.CheckCollision(playerBounds)) pos.X = initPos.X;

            if (kstate.IsKeyDown(Keys.Up))
            {
                transform.pos.Y -= speed * camera.zoom * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Down))
            {
                transform.pos.Y += speed * camera.zoom * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            transform.playerBounds.Y = (int)transform.pos.Y - (int)(transform.dims.Y / 2);
            //if (level.CheckCollision(transform.playerBounds)) pos.Y = initPos.Y;
        }
    }
}

