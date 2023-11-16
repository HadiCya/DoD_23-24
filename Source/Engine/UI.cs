using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using System.Transactions;
using System.Reflection.Emit;

namespace DoD_23_24
{
    public class UI
    {
        private Texture2D texture;
        protected Vector2 position;
        private Vector2 dimensions;
        protected bool isActive;
        private bool freezePlayer;

        public Player player;

        public UI(string PATH, Vector2 POSITION, Vector2 DIMENSIONS, bool ACTIVE, bool FREEZE)
        {
            texture = Globals.content.Load<Texture2D>(PATH);
            position = POSITION;
            dimensions = DIMENSIONS;
            isActive = ACTIVE;
            freezePlayer = FREEZE;
        }
        public void Update(GameTime gameTime)
        {
            
        }

        public virtual void Draw()
        {
            if (texture != null && isActive)
            {
                Globals.spriteBatch.Draw(texture, new Rectangle(new Point((int)position.X, (int)position.Y), new Point((int)dimensions.X, (int)dimensions.Y)), Color.White);
            }
        }

        public void setActive(bool active)
        {
            isActive = active;
            Player.movementDisabled = freezePlayer;

            if (!isActive)
            {
                Player.movementDisabled = false;
            }
        }

        public bool Active()
        {
            return isActive;
        }
    }
}