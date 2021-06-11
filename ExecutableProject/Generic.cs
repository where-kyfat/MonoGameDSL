using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameLib.Behaviours;
using MonogameLib.Classes;
using System;

namespace TestProject
{

    public class Player : Sprite 
    {
        public Int32 speed; public Camera camera; public Int32 windowSizeX; public Int32 windowSizeY; public Int32 layoutSizeX; public Int32 layoutSizeY; public Boolean IsEdge; 
        public Player (Texture2D texture, int positionX, int positionY ) : base(texture, positionX, positionY)
        {
            
            Behaviours.Add(new _8Directions( speed));

            Behaviours.Add(new ScrollTo( camera, windowSizeX, windowSizeY, layoutSizeX, layoutSizeY));

            Behaviours.Add(new BoundToLayout( layoutSizeX, layoutSizeY, IsEdge));

        }

        public override void Update(GameTime gameTime) 
        {
            for (int i = 0; i < Behaviours.Count; i++) 
            {
                
            if (Behaviours[i] is _8Directions)
                Behaviours[i] = new _8Directions( speed);

            if (Behaviours[i] is ScrollTo)
                Behaviours[i] = new ScrollTo( camera, windowSizeX, windowSizeY, layoutSizeX, layoutSizeY);

            if (Behaviours[i] is BoundToLayout)
                Behaviours[i] = new BoundToLayout( layoutSizeX, layoutSizeY, IsEdge);

            }
            base.Update(gameTime);
        }
    }

    public class Bullet : Sprite 
    {
        public Int32 speed; public Int32 layoutSizeX; public Int32 layoutSizeY; 
        public Bullet (Texture2D texture, int positionX, int positionY ) : base(texture, positionX, positionY)
        {
            
            Behaviours.Add(new BulletMovement( speed));

            Behaviours.Add(new DestroyOutSideLayout( layoutSizeX, layoutSizeY));

        }

        public override void Update(GameTime gameTime) 
        {
            for (int i = 0; i < Behaviours.Count; i++) 
            {
                
            if (Behaviours[i] is BulletMovement)
                Behaviours[i] = new BulletMovement( speed);

            if (Behaviours[i] is DestroyOutSideLayout)
                Behaviours[i] = new DestroyOutSideLayout( layoutSizeX, layoutSizeY);

            }
            base.Update(gameTime);
        }
    }

	
    class GameTest : ConstructorGame
    {
	
		Texture2D playerTexture;
		Texture2D bulletTexture;

        // Player values initialize
        Player _player;

		
        protected override void Initialize()
        {
            base.Initialize();

			windowSizeX = 1920;
			windowSizeY = 1080;
			layoutSizeX = 3840;
			layoutSizeY = 2160;
			
			
			_player = new Player(playerTexture,10,10);  sprites.Add(_player);
			_player.speed = 4;
			_player.camera = _camera;
			_player.windowSizeX = windowSizeX;
			_player.windowSizeY = windowSizeY;
			_player.layoutSizeX = layoutSizeX;
			_player.layoutSizeY = layoutSizeY;
			_player.IsEdge = true;
 

            ApplyWindowChanges();
        }

        protected override void LoadContent()
        {
			playerTexture = LoadTextrure("player");
			bulletTexture = LoadTextrure("bullet");
			layoutTexture = LoadTextrure("TiledBackground");


            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {

        // Every tick
        if (Conditions.EveryTick())
        {
            // Player rotates to Mouse
            Actions.SetAngleForward(_player, Mouse.X, Mouse.Y, false);
        }

        // Create new Bullet when Mouse.LeftButton clicked
        if (Conditions.OnMouseXButtonClicked(Conditions.MouseButton.Left, gameTime))
        {
            Bullet bullet = new Bullet(bulletTexture, _player.PositionX, _player.PositionY);
            bullet.speed = 10;
            bullet.layoutSizeX = layoutSizeX;
            bullet.layoutSizeY = layoutSizeY;
            bullet.Rotation = _player.Rotation;
            AddSprite(bullet);
        }


            base.Update(gameTime);
        }
    }
}

