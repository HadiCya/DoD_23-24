using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DoD_23_24;
public class Main : Game
{
    private GraphicsDeviceManager _graphics;
    Texture2D maheelTexture;
    Maheel maheel;
    Vector2 POS;

    World world;

    public Main()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = Globals.WIDTH;
        _graphics.PreferredBackBufferHeight = Globals.HEIGHT;
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here


        base.Initialize();

    }

    protected override void LoadContent()
    {
        Globals.content = this.Content;
        Globals.spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        maheel = new Maheel("megaman", POS = new Vector2(100,100), new Vector2(100, 100), true);

        world = new World();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        world.Update(gameTime, maheel);

        maheel.PelletInstance?.Update(gameTime);

        if (maheel.PelletInstance != null && maheel.PelletInstance.pos.X > Globals.WIDTH)
        {
            maheel.PelletInstance = null;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        

        // TODO: Add your drawing code here

        Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

        world.Draw(maheel);

        Globals.spriteBatch.End();

        base.Draw(gameTime);
    }
}