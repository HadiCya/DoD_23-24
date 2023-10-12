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
    public class JohnA : Basic2D
    {
        int dashSpeed = 1;

        public JohnA(string PATH, Vector2 POS, Vector2 DIMS, bool shouldScale) : base(PATH, POS, DIMS, shouldScale)
        {
        }

        public override void Update(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.Up))
            {
                pos.Y -= 1 * dashSpeed;
            }
            else if (kstate.IsKeyDown(Keys.Down))
            {
                pos.Y += 1 * dashSpeed;
            }
            if (kstate.IsKeyDown(Keys.Right))
            {
                pos.X += 1 * dashSpeed;
            }
            else if (kstate.IsKeyDown(Keys.Left))
            {
                pos.X -= 1 * dashSpeed;
            }

            if (kstate.IsKeyDown(Keys.Space))
            {
                dashSpeed = 10;
            }
            else if (kstate.IsKeyUp(Keys.Space))
            {
                dashSpeed = 1;
            }

            base.Update(gameTime);
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}

