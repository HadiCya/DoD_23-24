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
using MonoGame.Extended.Timers;
#endregion
namespace DoD_23_24
{
	public class Player : Basic2D
	{
        float speed = 100f;

        Texture2D playerSprite;

        public Player(string PATH, Vector2 POS, Vector2 DIMS, bool shouldScale) : base(PATH, POS, DIMS, shouldScale)
		{
		}

        public override void Update(GameTime gameTime)
        {
            Movement(gameTime);

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
                pos.Y -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Down))
            {
                pos.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            
            if (kstate.IsKeyDown(Keys.Left))
            {
                pos.X -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Right))
            {
                pos.X += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            
        }
    }
}