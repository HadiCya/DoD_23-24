using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace DoD_23_24
{
    internal class Dialogue
    {
        private Texture2D texture;
        private string text;
        private Texture2D face;
        private List<string> conversation;

        private SpriteFont font;
        private int currentText = 0;

        public Vector2 position = new Vector2(0, 300);

        private bool isPressed = false;
        private bool isShowing = false;

        public Dialogue(List<string> c)
        {
            conversation = c;
            text = c[currentText];
            font = Globals.content.Load<SpriteFont>("2D/UI/DefaultFont");
            texture = Globals.content.Load<Texture2D>("2D/Sprites/DialogueBox");
        }

        public string getText()
        {
            return text;
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !isPressed)
            {
                if(currentText == 0)
                {
                    isPressed = true;
                }
                else
                {
                    isShowing = true;
                    currentText++;
                    text = conversation[currentText];
                    isPressed = true;
                }
            }

            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                isPressed = false;
            }
        }

        public void Draw()
        {
            if(isShowing)
            {
                Globals.spriteBatch.Draw(texture, position, Color.White);
                WriteText();
            }
        }

        public void WriteText()
        {
            Globals.spriteBatch.DrawString(font, text, new Vector2(30, 330), Color.White);
        }
    }
}
