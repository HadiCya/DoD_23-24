using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DoD_23_24
{
    internal class NPC : Basic2D
    {
        string textFile;
        string path = "2D/Sprites/DialogueBox";
        bool isPressed = false;

        Player player;
        Rectangle rect;

        public NPC(string PATH, Vector2 POS, Vector2 DIMS, bool shouldScale, string FILE, Player PLAYER) : base(PATH, POS, DIMS, shouldScale)
        {
            textFile = FILE;
            player = PLAYER;
            rect = new Rectangle((int)pos.X - 16, (int)pos.Y - 16, 48, 48);
        }

        public override void Update(GameTime gameTime)
        {
            if(detectPlayer(player.getRectangle()) && Keyboard.GetState().IsKeyDown(Keys.Space) && !isPressed)
            {
                if(Canvas.dialogue.GetIndex() == 0)
                {
                    Canvas.dialogue.SetText(textFile);
                    Canvas.dialogue.setActive(true);
                    Canvas.dialogue.Speak();
                }
                else
                {
                    Canvas.dialogue.Speak();
                }
                isPressed = true;
            }

            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                isPressed = false;
            }

            base.Update(gameTime);

        }

        public override void Draw()
        {
            base.Draw();
        }

        public bool detectPlayer(Rectangle playerRect)
        {

            if(rect.Intersects(playerRect))
            {
                return true;
            }

            return false;
        }
    }
}
