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

namespace DoD_23_24
{
    public class Dialogue: UI
    {
        private string text;
        private List<string> conversation = new List<string> { };
        private SpriteFont font;
        private int currentText = 0;

        private bool isPressed = false;

        public Dialogue(string PATH, Vector2 POSITION, Vector2 DIMENSIONS, bool ACTIVE, bool FREEZE): base(PATH, POSITION, DIMENSIONS, ACTIVE, FREEZE)
        {
            font = Globals.content.Load<SpriteFont>("2D/UI/DefaultFont");
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void SetText(string c)
        {
            StreamReader sr = new StreamReader(c);
            String line = sr.ReadLine();
            while (line != null)
            {
                conversation.Add(line);
                line = sr.ReadLine();
            }
            text = conversation[currentText];
        }

        public void WriteText()
        {
            Globals.spriteBatch.DrawString(font, text, new Vector2(position.X + 30, position.Y + 30), Color.White);
        }

        public void Speak()
        {
            if (currentText >= conversation.Count)
            {
                setActive(false);
                currentText = 0;
                conversation.Clear();
            }
            else
            {
                text = conversation[currentText];
                currentText++;
            }
        }

        public string getText()
        {
            return text;
        }

        public int GetIndex()
        {
            return currentText;
        }
    }
}