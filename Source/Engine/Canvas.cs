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

using System.Reflection.Metadata;
using System.Reflection.Emit;

#endregion

namespace DoD_23_24
{
    public class Canvas
    {
        public static Dialogue dialogue;

        public Canvas()
        {
            dialogue = new Dialogue("2D/Sprites/DialogueBox", new Vector2(100, 400), new Vector2(400, 200), false, true);
        }

        public virtual void Update(GameTime gameTime)
        {
            dialogue.Update(gameTime);
        }

        public virtual void Draw()
        {
           dialogue.Draw();

            if (dialogue.getText() != null && dialogue.Active())
            {
                dialogue.WriteText();
            }
        }
    }
}
