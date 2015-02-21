using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;
using System.Diagnostics;


namespace Testing1
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class SpriteManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        UserControlledSprite player;
        //TileMap myMap;
        List<Sprite> spriteList = new List<Sprite>();
        //int squaresAcross = 40;
        //int squaresDown = 40;
        
        //String content;
        public SpriteManager(Game game)     
            : base(game)
        {
            
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>

        public override void Initialize()
        {
            
            
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            player = new UserControlledSprite(Game.Content.Load<Texture2D>("Animation/dragon"),new Vector2(50,50), new Point(75,70), 20, new Point(0,0),new Point(8,10), new Vector2(10,10));
            spriteList.Add(new AutoSprite(Game.Content.Load<Texture2D>("Animation/dragon"), new Vector2(500, 650), new Point(75, 70), 20, new Point(0, 1), new Point(8, 10), new Vector2(1,1)));
            spriteList.Add(new AutoSprite(Game.Content.Load<Texture2D>("Animation/dragon"), new Vector2(250, 150), new Point(75, 70), 20, new Point(0, 1), new Point(8, 10), new Vector2(1,1)));
            spriteList.Add(new AutoSprite(Game.Content.Load<Texture2D>("Animation/dragon"), new Vector2(450, 300), new Point(75, 70), 20, new Point(0, 1), new Point(8, 10), new Vector2(1,1)));
            spriteList.Add(new AutoSprite(Game.Content.Load<Texture2D>("Animation/dragon"), new Vector2(600, 400), new Point(75, 70), 20, new Point(0, 1), new Point(8, 10), new Vector2(1,1)));
            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
           
            
            player.Update(gameTime, Game.Window.ClientBounds);
            foreach (Sprite s in spriteList)
            {
                s.Update(gameTime, Game.Window.ClientBounds);
            }
            
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            if (player.position.X < (Camera.Location.X + Game1.squaresAcross * Tile.TileWidth - Game1.offsetX) && player.position.X > (Camera.Location.X - Game1.offsetX) && player.position.Y > (Camera.Location.Y - Game1.offsetY) && player.position.Y < (Camera.Location.Y + Game1.squaresDown * Tile.TileHeight - Game1.offsetY))
            {
                player.Draw(gameTime, spriteBatch);
            }
            foreach (Sprite s in spriteList)
            {
                if (s.position.X < (Camera.Location.X + Game1.squaresAcross * Tile.TileWidth) && s.position.X > (Camera.Location.X) && s.position.Y > (Camera.Location.Y) && s.position.Y < (Camera.Location.Y + Game1.squaresDown * Tile.TileHeight))
                {
                    s.Draw(gameTime, spriteBatch);
                }
                
                if (s.collisionRect.Intersects(player.collisionRect))
                {
                    //collisions++;
                    //Game.Exit();
                }
            }
            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
