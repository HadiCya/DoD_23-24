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
    public class Chandler : Basic2D
    {
        const int smileSpeed = 300;
        bool isPressed = false;
        int smileSize = 0;



        public Chandler(string PATH, Vector2 POS, Vector2 DIMS, bool shouldScale) : base(PATH, POS, DIMS, shouldScale)
        {

        }

        public override void Update(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();


            if (kstate.IsKeyDown(Keys.Up))
            {
                pos.Y -= smileSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Down))
            {
                pos.Y += smileSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Left))
            {
                pos.X -= smileSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Right))
            {
                pos.X += smileSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Space) && !isPressed)
            {
                isPressed = true;
                if (smileSize == 5)
                {
                    dims.X = dims.X / 32;
                    dims.Y = dims.Y / 32;
                    smileSize = 0;
                }
                else
                {
                    dims.X = dims.X * 2;
                    dims.Y = dims.Y * 2;
                    smileSize += 1;
                }
            }

            if (kstate.IsKeyUp(Keys.Space))
            {
                isPressed = false;
            }

            base.Update(gameTime);
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}


