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

    public class Pellet : Basic2D
    {
        Vector2 pelletPos;
        float pelletSpeed = 300f;
        public Pellet(string PATH, Vector2 POS, Vector2 DIMS, bool shouldScale) : base(PATH, POS, DIMS, shouldScale)
        {
            this.pelletPos = POS;
        }

        public override void Update(GameTime gameTime)
        {
            pelletPos.X += pelletSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            this.pos = pelletPos;
            base.Update(gameTime);

        }

        public void Draw(Maheel maheel)
        {
            base.Draw();

        }
    }
}
