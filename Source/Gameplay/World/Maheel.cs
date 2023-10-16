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
    public class Maheel : Basic2D
    {
        KeyboardState kstate;
        Vector2 maheelPos;
        float maheelSpeed = 200f;
        public Pellet PelletInstance { get; set; }
        public Maheel(string PATH, Vector2 POS, Vector2 DIMS, bool shouldScale) : base(PATH, POS, DIMS, shouldScale)
        {
            maheelPos = new Vector2(100, 100);
            this.pos = maheelPos;
        }

        public override void Update(GameTime gameTime)
        {
            kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.Up) && maheelPos.Y > 35)
            {
                maheelPos.Y -= maheelSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Down) && maheelPos.Y < Globals.HEIGHT - 20)
            {
                maheelPos.Y += maheelSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Left) && maheelPos.X > 35)
            {
                maheelPos.X -= maheelSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Right) && maheelPos.X < Globals.WIDTH - 30)
            {
                maheelPos.X += maheelSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Space) && PelletInstance == null)
            {
                PelletInstance = new Pellet("pellet", maheelPos, new Vector2(10, 10), true);
            }


            this.pos = maheelPos;
            base.Update(gameTime);

        }

        public override void Draw()
        {
            PelletInstance?.Draw();
            base.Draw();
        }
    }
}