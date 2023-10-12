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
    public class RaymondDiDonato : Basic2D
    {
        const int ballSpeed = 300;
        int right = 1, down = -1;
        public RaymondDiDonato(string PATH, Vector2 POS, Vector2 DIMS, bool shouldScale) : base(PATH, POS, DIMS, shouldScale)
        {
        }

        public override void Update(GameTime gameTime)
        {
            pos.X += (int)(ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds) * right;
            pos.Y += (int)(ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds) * down;

            KeyboardState kstate = Keyboard.GetState();

            if (pos.X < 0 || pos.X + dims.X > Globals.WIDTH)
                right *= -1;
            else if (kstate.IsKeyDown(Keys.Right))
                right = 1;
            else if (kstate.IsKeyDown(Keys.Left))
                right = -1;

            if (pos.Y < 0 || pos.Y + dims.Y > Globals.HEIGHT)
                down *= -1;
            else if (kstate.IsKeyDown(Keys.Down))
                down = 1;
            else if (kstate.IsKeyDown(Keys.Up))
                down = -1;

            base.Update(gameTime);
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}

