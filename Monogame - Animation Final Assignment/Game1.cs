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

        Texture2D introScreenTexture, mainBgTexture, endScreenTexture, papaTexture, kyleTexture, tonyTexture, johnTexture, pizzaTexture, watermelonTexture;

        Rectangle backgroundRect, papaRect, kyleRect, tonyRect, johnRect, pizzaRect, watermelonRect;

        Vector2 pizzaSpeed, johnSpeed;
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

            johnSpeed = new Vector2(0, 0);
            pizzaSpeed = new Vector2(0, 0);

            backgroundRect = new Rectangle(0, 0, 800, 500);
            johnRect = new Rectangle(800, 300, 180, 190);
            papaRect = new Rectangle(0, 0, 140, 170);
            kyleRect = new Rectangle(180, 290, 200, 210);
            tonyRect = new Rectangle(0, 300, 130, 190);
            pizzaRect = new Rectangle(240, 400, 80, 80);
            

            introScreenTexture = Content.Load<Texture2D>("introScreen");
            mainBgTexture = Content.Load<Texture2D>("Pizzeria");
            pizzaTexture = Content.Load<Texture2D>("Pizza");
            endScreenTexture = Content.Load<Texture2D>("endScreen");
            papaTexture = Content.Load<Texture2D>("CustomerPapaLouie_A");
            kyleTexture = Content.Load<Texture2D>("Kyle");
            tonyTexture = Content.Load<Texture2D>("Tony");
            johnTexture = Content.Load<Texture2D>("John");
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

                _spriteBatch.Draw(kyleTexture, kyleRect, Color.White);
                _spriteBatch.Draw(tonyTexture, tonyRect, Color.White);

                if (seconds >= 2)
                {
                    _spriteBatch.Draw(pizzaTexture, pizzaRect, Color.White);
                }

                if (seconds >= 5)
                {
                    if (pizzaRect.X != tonyRect.Right - 100)
                    {
                        pizzaSpeed = new Vector2(-2, -1);
                        pizzaRect.X += (int)pizzaSpeed.X;
                        pizzaRect.Y += (int)pizzaSpeed.Y;
                    }

                }

                if (seconds >= 8)
                {
                    _spriteBatch.Draw(johnTexture, johnRect, Color.White);
                    if (johnRect.X > 600)
                    {
                        johnSpeed = new Vector2(-3, 0);
                        johnRect.X += (int)johnSpeed.X;
                    }

                    //_spriteBatch.Draw(papaTexture, papaRect, Color.White);
                    
                }
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
