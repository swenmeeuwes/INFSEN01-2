using GUILibrary.Application.Controller;
using GUILibrary.AssetLoading;
using GUILibrary.Input;
using GUILibrary.UI.Drawing;
using GUILibrary.UI.Label;
using GUILibrary.UI.View;
using GUILibrary.UI.View.Decorators;
using GUILibrary.UI.Window;
using GUILibrary.Util.Observable;
using GUILibrary.Util.Structures;
using GUILibrary.Util.Visitor;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;

namespace GUILibrary
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MainGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        AbstractScreenFactory screenFactory;
        ScreenNavigator screenNavigator;

        IDrawManager drawManager;
        IInputAdapter inputAdapter;
        IApplicationAdapter applicationAdapter;

        IOnClickVisitor onClickVisitor;
        IUpdateVisitor updateVisitor;
        IDrawVisitor drawVisitor;

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
            // Initialization logic here
            screenFactory = new ScreenFactory();
            applicationAdapter = new MonoGameApplicationAdapter(this);
            screenNavigator = new ScreenNavigator(screenFactory, applicationAdapter);

            inputAdapter = new MonoGameInputAdapter();

            onClickVisitor = new OnClickVisitor(inputAdapter);
            updateVisitor = new DefaultUpdateVisitor(inputAdapter);

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

            drawManager = new DrawManager(new MonoGameDrawStrategy(spriteBatch, graphics, Content, inputAdapter));
            drawVisitor = new DefaultDrawVisitor(drawManager);

            // Goto main screen
            screenNavigator.OpenScreen(ScreenFactory.MAIN_SCREEN);
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Add your update logic here
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            onClickVisitor.UpdateMouseState();

            var screenIterator = screenNavigator.GetScreenIterator();
            while(screenIterator.HasNext())
            {
                var screen = screenIterator.Next();
                screen.HandleClick(onClickVisitor);
                screen.Update(updateVisitor, deltaTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.CornflowerBlue);

            spriteBatch.Begin();

            var screenIterator = screenNavigator.GetScreenIterator();
            while (screenIterator.HasNext())
            {
                var screen = screenIterator.Next();
                screen.Draw(drawVisitor);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
