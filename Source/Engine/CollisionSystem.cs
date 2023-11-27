﻿#region Includes
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
	public class CollisionSystem
	{
		List<Entity> entities;

		public CollisionSystem(List<Entity> entities)
		{
			this.entities = entities;
		}

		public void Update(GameTime gameTIme)
		{
			for (int i = 0; i < entities.Count; i++)
			{
				Entity entity = entities[i];
                CollisionComponent collision = entity.GetComponent<CollisionComponent>();

				if (collision != null)
				{
					for (int j = i+1; j < entities.Count; j++)
					{
						Entity otherEntity = entities[j];
						CollisionComponent otherCollision = otherEntity.GetComponent<CollisionComponent>();

                        if (otherCollision != null && !(entity.name.Substring(0, 5) == "Tile_" && otherEntity.name.Substring(0, 5) == "Tile_"))
				 		{
							if (otherCollision.CheckCollision(collision.GetBounds()))
							{
								Console.WriteLine(entity.name + " " + otherEntity.name);
                                collision.ReportCollision(otherEntity);
								otherCollision.ReportCollision(entity);
							}
						}
					}
				}
            }
		}
	}
}

