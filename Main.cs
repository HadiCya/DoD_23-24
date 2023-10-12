using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DoD_23_24;
public class Main : Game
{
    private GraphicsDeviceManager _graphics;

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

        world = new World();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        world.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        

        // TODO: Add your drawing code here

        Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

        world.Draw();

        Globals.spriteBatch.End();

        base.Draw(gameTime);
    }
}