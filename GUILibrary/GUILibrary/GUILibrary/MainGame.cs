using GUILibrary.AssetLoading;
using GUILibrary.UI.Button;
using GUILibrary.UI.Label;
using GUILibrary.UI.Window;
using GUILibrary.Util.Observable;
using GUILibrary.Util.Visitor;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GUILibrary
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MainGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        IUpdateVisitor updateVisitor;
        IDrawVisitor drawVisitor;

        GUIWindow mainWindow;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Add your initialization logic here
            updateVisitor = new DefaultUpdateVisitor();

            // Configuration
            this.IsMouseVisible = true;

            //
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load your game content here  
            AssetLoadService.Instance.LoadAssets(Content);

            var aButton = new Button("This be a button", new Vector2(100, 100));
            var printObserver = new ActionObserver(e => { Console.WriteLine(((Button)e.Target).Label.Text + " " + e.Type); });
            aButton.RegisterObserver(printObserver);

            // Todo: Implement mediators ... 
            mainWindow = new GUIWindow("main",
                aButton,
                new Label("0", new Vector2(GraphicsDevice.Viewport.Bounds.Width - 5, 5)) { Align = TextAlign.RIGHT }
            );

            drawVisitor = new DefaultDrawVisitor(spriteBatch);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Add your update logic here
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            mainWindow.Update(updateVisitor, deltaTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp); // SamplerState.PointClamp disables smooth/ blurry stretching of textures

            mainWindow.Draw(drawVisitor);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
