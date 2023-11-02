﻿#region Includes
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
	public class Player : Basic2D
	{
        float speed = 50f;
        Matrix translation;
        public Rectangle playerBounds;
        private float zoom = 2.0f;

        public Player(string PATH, Vector2 POS, Vector2 DIMS, bool shouldScale) : base(PATH, POS, DIMS, shouldScale)
		{
            playerBounds = new Rectangle((int)pos.X - (int)(dims.X/2), (int)pos.Y - (int)(dims.Y / 2), (int)dims.X, (int)dims.Y);
		}

        public override void Update(GameTime gameTime)
        {
            Movement(gameTime);
            CalculateTranslation();

            base.Update(gameTime);
        }

        public override void Draw()
        {
            base.Draw();
        }

        public void Movement(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
            {
                pos.Y -= speed * zoom * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Down))
            {
                pos.Y += speed * zoom * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            
            if (kstate.IsKeyDown(Keys.Left))
            {
                pos.X -= speed * zoom * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Right))
            {
                pos.X += speed * zoom * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            playerBounds.X = (int)pos.X - (int)(dims.X / 2);
            playerBounds.Y = (int)pos.Y - (int)(dims.Y / 2);
        }

        private void CalculateTranslation()
        {
            var dx = (Globals.WIDTH / (zoom*2)) - playerBounds.X;
            var dy = (Globals.HEIGHT / (zoom*2)) - playerBounds.Y;
            translation = Matrix.CreateTranslation(dx, dy, 0f) * Matrix.CreateScale(zoom);
        }

        public Matrix GetTranslation()
        {
            return translation;
        }
    }
}