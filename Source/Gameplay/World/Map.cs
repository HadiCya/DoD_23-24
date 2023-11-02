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

using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.ViewportAdapters;
using System.Reflection.Metadata;
using MonoGame.Extended;

#endregion

namespace DoD_23_24
{
    public class Map
    {

        TiledMap _tiledMap;
        TiledMapRenderer _tiledMapRenderer;

        public Map()
        {
            _tiledMap = Globals.content.Load<TiledMap>("LevelTiles/samplemap");
            _tiledMapRenderer = new TiledMapRenderer(Globals.graphics, _tiledMap);
            Globals.collision = _tiledMap.GetLayer<TiledMapTileLayer>("Collision");
        }

        public virtual void Update(GameTime gameTime)
        {
            _tiledMapRenderer.Update(gameTime);
        }

        public virtual void Draw()
        {
            _tiledMapRenderer.Draw();
        }


    }
}

