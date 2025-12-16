using System;
using app.Models.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace app
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private static Rectangle screenDimensions;
        private static Texture2D whitePixel;
        public static MonogameWindow activeScene;

        // Propriétés de la classe...
        public static Rectangle ScreenDimensions { get => screenDimensions; }
        public static Texture2D WhitePixel { get => whitePixel; }
        public static ContentManager PublicContent { get; private set; }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.Window.Title = "Santa Clash";
            ChangeScreenDimensions(1024);
            activeScene = new GameScreen();

            base.Initialize();
        }

        private void ChangeScreenDimensions(int baseWidth = 640)
        {
            double ratio = 3.0 / 2.0;
            _graphics.PreferredBackBufferWidth = baseWidth;
            _graphics.PreferredBackBufferHeight = (int)(baseWidth / ratio);
            Game1.screenDimensions = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            _graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            whitePixel = new Texture2D(GraphicsDevice, 1, 1);
            whitePixel.SetData(new[] { Color.White });
            activeScene.LoadContent(Content);
            PublicContent = Content;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            activeScene.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            activeScene.Draw(_spriteBatch, gameTime);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
