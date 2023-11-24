using System;
using System.Collections.Generic;
using System.Linq;

namespace DoD_23_24
{
	public class Entity
	{
		List<Component> components = new List<Component>();

        public Entity() { }

        public T GetComponent<T>() where T : Component
        {
            return components.OfType<T>().FirstOrDefault();
        }

        public void AddComponent(Component component)
        {
            components.Add(component);
        }
    }
}

