using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonogameLib.Classes
{
    public struct Mouse
    {
        public int X;
        public int Y;
    }

    public class ConstructorGame : Game
    {
        private protected GraphicsDeviceManager _graphics;
        private protected SpriteBatchTiled _spriteBatch;

        // Camera values initialize
        protected Camera _camera;
        protected int windowSizeX = 1920;
        protected int windowSizeY = 1080;
        protected int middleScreenX;
        protected int middleScreenY;

        protected int layoutSizeX = 3840;
        protected int layoutSizeY = 2160;

        protected Mouse Mouse;

        protected Texture2D layoutTexture;
        public List<GraphObject> sprites;
        protected float timer;
        protected Random random;

        protected SpriteFont font;

        public ConstructorGame()
        {
            //Monogame initialize area
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            sprites = new List<GraphObject>();
            random = new Random();
        }

        public int getRandom(int max)
        {
            return random.Next(max);
        }

        protected override void Initialize()
        {
            ApplyWindowChanges();

            base.Initialize();
        }

        protected void ApplyWindowChanges()
        {
            // Changing window size
            _graphics.PreferredBackBufferWidth = windowSizeX;
            _graphics.PreferredBackBufferHeight = windowSizeY;
            _graphics.ApplyChanges();

            // Calc middleScreenX
            middleScreenX = windowSizeX / 2;
            middleScreenY = windowSizeY / 2;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatchTiled(GraphicsDevice);

            // Load camera
            _camera = new Camera();
            font = LoadFont("font");

            base.LoadContent();
        }

        protected Texture2D LoadTextrure(string name)
        {
            return Content.Load<Texture2D>("Sprites/" + name);
        }

        protected SpriteFont LoadFont(string name)
        {
            return Content.Load<SpriteFont>("Sprites/" + name);
        }

        protected delegate void SomeAction<T>(T target);



        protected void ForEach<T>(SomeAction<T> someAction)
        {
            for (int i = 0; i < sprites.Count; i++)
            {
                if (sprites[i] is T)
                {
                    T curSprite = (T)((object)sprites[i]);
                    someAction(curSprite);
                    sprites[i] = (GraphObject)(object)curSprite;
                }
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Mouse.X = Microsoft.Xna.Framework.Input.Mouse.GetState().X;
            Mouse.Y = Microsoft.Xna.Framework.Input.Mouse.GetState().Y;

            for (int i = 0; i < sprites.Count; i++)
            {
                if (sprites[i] is Sprite)
                {
                    if (!((Sprite)sprites[i]).IsRemove)
                    {
                        sprites[i].Update(gameTime);
                    }
                    else
                    {
                        sprites.RemoveAt(i);
                    }
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(transformMatrix: _camera.Transform);

            //Drawing layout
            _spriteBatch.DrawTiledBackground(layoutTexture, layoutSizeX, layoutSizeY,
                layoutTexture.Width, layoutTexture.Height, Color.White);

            //Drawing sprites
            foreach (var sprite in sprites)
            {
                if (sprite is Sprite)
                {
                    ((Sprite)sprite).transformMatrix = _camera.Transform;
                }
                else if (sprite is TextBox)
                {
                    ((TextBox)sprite).transformMatrix = _camera.Transform;
                }
                sprite.Draw(_spriteBatch);
            }
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public Sprite AddSprite(Sprite sprite)
        {
            sprites.Add(sprite);
            return sprite;
        }

        public TextBox AddTextBox(TextBox sprite)
        {
            sprites.Add(sprite);
            return sprite;
        }
    }
}
