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

#endregion

namespace DoD_23_24
{
    public class World
    {
        public Player playerInstance;
        public Entity randomThing;

        public World()
        {
            playerInstance = new Player("2D/Sprites/Item", new Vector2(100, 100), 0.0f, new Vector2(16, 16));
            randomThing = new Entity();
            randomThing.AddComponent(new TransformComponent(randomThing,
                new Vector2(100, 100), 0.0f, new Vector2(16, 16)));
            randomThing.AddComponent(new RenderComponent(randomThing, "2D/Sprites/Item"));
        }

        public virtual void Update(GameTime gameTime)
        {
            playerInstance.Update(gameTime);
        }

        public virtual void Draw()
        {
            playerInstance.Draw();
            randomThing.GetComponent<RenderComponent>().Draw();
        }
    }
}