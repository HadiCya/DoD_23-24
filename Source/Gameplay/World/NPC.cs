using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoD_23_24
{
    internal class NPC : Basic2D
    {
        Texture2D npcSprite;
        Dialogue dialogue;

        string path = "2D/Sprites/DialogueBox";

        public NPC(string PATH, Vector2 POS, Vector2 DIMS, bool shouldScale, Dialogue dialogue) : base(PATH, POS, DIMS, shouldScale)
        {
            this.dialogue = dialogue;
            PATH = path;
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public override void Draw()
        {

            base.Draw();
        }
    }
}
