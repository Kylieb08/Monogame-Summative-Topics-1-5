using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Summative_Topics_1_5
{
    enum Screen
    {
        Intro,
        Thief,
        Drive,
        End
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Rectangle window, carRect;
        Texture2D introScreenTexture, endScreenTexture, carThiefTexture, carTexture, drivingScreenTexture;
        Screen screen;
        MouseState mouseState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            window = new Rectangle(0, 0, 800, 600);
            screen = Screen.Intro;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            introScreenTexture = Content.Load<Texture2D>("you wouldnt steal a car");
            carThiefTexture = Content.Load<Texture2D>("car thief with speech");
            drivingScreenTexture = Content.Load<Texture2D>("road");
            carTexture = Content.Load<Texture2D>("stolen car no bg");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mouseState = Mouse.GetState();

            // TODO: Add your update logic here

            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    screen = Screen.Thief;
                }
            }

            //Will record sound, thief screen will end when sound is over

            //else if (screen == Screen.Thief)
            //{
            //    if ()
            //    {
            //        screen = Screen.Drive;
            //    }
            //}

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(introScreenTexture, window, Color.White);
            }

            else if (screen == Screen.Thief)
            {
                _spriteBatch.Draw(carThiefTexture, window, Color.White);
            }

            else if (screen == Screen.Drive)
            {
                _spriteBatch.Draw(drivingScreenTexture, window, Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
