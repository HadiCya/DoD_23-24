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
    public class CameraComponent : Component
    {
        TransformComponent transform;
        public float zoom = 2f;

        public CameraComponent(Player entity) : base(entity)
        {
            transform = entity.GetComponent<TransformComponent>();
        }

        public Matrix GetTranslation()
        {
            var dx = (Globals.WIDTH / (zoom * 2)) - transform.playerBounds.X;
            var dy = (Globals.HEIGHT / (zoom * 2)) - transform.playerBounds.Y;
            return Matrix.CreateTranslation(dx, dy, 0f) * Matrix.CreateScale(zoom);
        }
    }
}