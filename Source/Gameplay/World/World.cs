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
        public List<Entity> entities = new List<Entity>();

        CollisionSystem collisionSystem;
        
        public World()
        {
            Entity playerInstance = new Player("Player", "2D/Sprites/Item", new Vector2(100, 100), 0.0f, new Vector2(16, 16));
            Entity randomThing = new Entity("RandomThing");
            randomThing.AddComponent(new TransformComponent(randomThing,
                new Vector2(-50, -50), 0.0f, new Vector2(16, 16)));
            randomThing.AddComponent(new RenderComponent(randomThing, "2D/Sprites/Item"));
            randomThing.AddComponent(new CollisionComponent(randomThing, true, true));
            Entity camera = new Entity("Camera");
            camera.AddComponent(new CameraComponent(camera, playerInstance));

            TileMapGenerator tileMapGenerator = new TileMapGenerator("Content/map.tmx", "Tiny Adventure Pack\\");
            List<Entity> tiles = tileMapGenerator.GetTiles();
            entities.AddRange(tiles);
            entities.Add(playerInstance);
            entities.Add(randomThing);
            entities.Add(camera);

            List<Entity> collisionObjects = new List<Entity>();
            foreach (Entity entity in entities)
            {
                if (entity.GetComponent<CollisionComponent>() != null)
                {
                    collisionObjects.Add(entity);
                }
            }

            collisionSystem = new CollisionSystem(collisionObjects);
        }

        public void Update(GameTime gameTime)
        {
            foreach (Entity entity in entities)
            {
                entity.Update(gameTime);
            }

            collisionSystem.Update(gameTime);
        }

        public void Draw()
        {
            foreach (Entity entity in entities)
            {
                entity.Draw();
            }
        }

        public Entity GetCamera()
        {
            foreach (Entity entity in entities)
            {
                if (entity.name == "Camera")
                {
                    return entity;
                }
            }
            return null;
        }
    }
}