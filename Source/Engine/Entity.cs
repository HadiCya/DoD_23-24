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
using System.Reflection.Emit;
#endregion

namespace DoD_23_24
{
	public class Entity
	{
        public string name;
        public Layer layer;
		List<Component> components = new List<Component>();

        public Entity(string name, Layer layer) { this.name = name; this.layer = layer;  }

        public Component GetComponent<Component>()
        {
            return components.OfType<Component>().FirstOrDefault();
        }

        public Component AddComponent(Component component)
        {
            components.Add(component);
            return component;
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (Component component in components)
            {
                component.Update(gameTime);
            }
        }

        public virtual void Draw()
        {
            foreach (Component component in components)
            {
                component.Draw();
            }
        }

        public virtual void OnCollision(Entity otherEntity) { }
    }
}

