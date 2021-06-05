using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonogameLib.Classes
{
    public class ConstructorGame : Game
    {
        private protected GraphicsDeviceManager _graphics;
        private protected SpriteBatchTiled _spriteBatch;

        // Camera values initialize
        protected Camera _camera;
        protected Vector2 _windowSize = new Vector2(1920, 1080);
        protected Vector2 _middleScreen;

        protected Vector2 _backgroundSize = new Vector2(3840, 2160);
        protected Texture2D _layout;
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

        protected override void Initialize()
        {
            // Changing window size
            _graphics.PreferredBackBufferWidth = (int)_windowSize.X;
            _graphics.PreferredBackBufferHeight = (int)_windowSize.Y;
            _graphics.ApplyChanges();

            // Calc _middleScreen
            _middleScreen = new Vector2(_windowSize.X / 2, _windowSize.Y / 2);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatchTiled(GraphicsDevice);

            // Load camera
            _camera = new Camera();

            base.LoadContent();
        }

        protected Texture2D LoadTextrure(string path)
        {
            return Content.Load<Texture2D>(path);
        }

        protected SpriteFont LoadFont(string path)
        {
            return Content.Load<SpriteFont>(path);
        }

        protected delegate void SomeAction(Sprite target);

        protected void ForEach<T>(SomeAction someAction)
        {
            for (int i = 0; i < sprites.Count; i++)
            {
                if (sprites[i] is T)
                {
                    someAction((Sprite)sprites[i]);
                }
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

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
            _spriteBatch.DrawTiledBackground(_layout, new Vector2(_backgroundSize.X, _backgroundSize.Y),
                new Vector2(_layout.Width, _layout.Height), Color.White);

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
