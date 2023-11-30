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
#endregion
namespace DoD_23_24
{
	public class Player : Entity
	{
        TransformComponent transform;
        CollisionComponent collision;
        bool isPressed = false;
        bool isFrozen = false;


        public Player(string name, string PATH, Vector2 POS, float ROT, Vector2 DIMS) : base(name, Layer.Player)
		{
            transform = (TransformComponent)AddComponent(new TransformComponent(this, POS, ROT, DIMS));
            AddComponent(new RenderComponent(this, PATH));
            collision = (CollisionComponent)AddComponent(new CollisionComponent(this, true, true));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Movement(gameTime);
        }

        public void Movement(GameTime gameTime)
        {
            if(isFrozen)
            {
                return;
            }

            KeyboardState kstate = Keyboard.GetState();

            //Left
            if (kstate.IsKeyDown(Keys.Left))
            {
                transform.xSpeed = -transform.speed;
            }

            if (kstate.IsKeyUp(Keys.Left))
            {
                transform.xSpeed = 0f;
                collision.leftCollisionForce = 0f;
            }

            //Right
            if (kstate.IsKeyDown(Keys.Right))
            {
                transform.xSpeed = transform.speed;
            }

            if (kstate.IsKeyUp(Keys.Right))
            {
                collision.rightCollisionForce = 0f;
            }

            //Up
            if (kstate.IsKeyDown(Keys.Up))
            {
                transform.ySpeed = -transform.speed;
            }

            if (kstate.IsKeyUp(Keys.Up))
            {
                transform.ySpeed = 0f;
                collision.upCollisionForce = 0f;
            }

            //Down
            if (kstate.IsKeyDown(Keys.Down))
            {
                transform.ySpeed = transform.speed;
            }

            if (kstate.IsKeyUp(Keys.Down))
            {
                collision.downCollisionForce = 0f;
            }

            transform.pos.X += (transform.xSpeed + collision.leftCollisionForce + collision.rightCollisionForce) * (float)gameTime.ElapsedGameTime.TotalSeconds;
            transform.pos.Y += (transform.ySpeed + collision.upCollisionForce + collision.downCollisionForce) * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public override void OnCollision(Entity otherEntity)
        {
            Console.WriteLine("I'm Colliding!");

            if(otherEntity.name == "OverlapZone")
            {
                InteractWithNPC(otherEntity);
            }
        }

        public void InteractWithNPC(Entity overlapZone)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !isPressed)
            {
                overlapZone.GetComponent<OverlapZoneComponent>().GetParentNPC().Speak();
                isFrozen = overlapZone.GetComponent<OverlapZoneComponent>().GetParentNPC().CheckIfPlayerFrozen();
                isPressed = true;
            }

            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                isPressed = false;
            }
        }
    }
}