using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading.Tasks;

namespace Monogame___Animation_Final_Assignment
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        enum Screen
        {
            start,
            main,
            end

        }

        Screen screen;

        MouseState mouseState;

        float seconds = 0f;

        bool timing = false;

        Texture2D introScreenTexture, mainBgTexture, endScreenTexture;

        Rectangle backgroundRect;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();

            screen = Screen.start;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            backgroundRect = new Rectangle(0, 0, 800, 500);

            introScreenTexture = Content.Load<Texture2D>("introScreen");
            mainBgTexture = Content.Load<Texture2D>("Pizzeria");
            endScreenTexture = Content.Load<Texture2D>("endScreen");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            this.Window.Title = $"x = {mouseState.X}, y = {mouseState.Y}" + "     " + seconds;
            // this.Window.Title = "The Food Fight";
            mouseState = Mouse.GetState();

            if (screen == Screen.start)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    screen = Screen.main;
                    timing = true;
                }
            }

            if (screen == Screen.main)
            {
                seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (seconds >= 18)
                {
                    screen = Screen.end;
                    timing = false;
                    seconds = 0;
                }

            }

            if (screen == Screen.end)
            {
                seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (seconds >= 6)
                {
                    Exit();
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Orange);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            if (screen == Screen.start)
            {
                _spriteBatch.Draw(introScreenTexture, backgroundRect, Color.White);
            }
            if (screen == Screen.main)
            {
                _spriteBatch.Draw(mainBgTexture, backgroundRect, Color.White);
            }

            if (screen == Screen.end)
            {
                _spriteBatch.Draw(endScreenTexture, backgroundRect, Color.White);
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
