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
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteManager manager;
        TileMap myMap;
        public static int squaresAcross =30;
        public static int squaresDown = 30;
        float scroll = .20f;
        public static int firstX { get; set; }
        public static int firstY { get; set; }
        public static int offsetX { get; set; }
        public static int offsetY { get; set; }
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            myMap = new TileMap(Path.Combine(Content.RootDirectory, "Map/map1.txt"));
            myMap.Rows[5].Columns[5].sprite = new UserSprite(Content.Load<Texture2D>("Animation/dragon"), new Point(75, 70), new Point(0, 1), new Point(8, 10), new Vector2(1,1));
            manager = new SpriteManager(this);
            Components.Add(manager);
            
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

            Tile.TileSetTexture = Content.Load<Texture2D>("Animation/part2_tileset");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }
            MouseState ms = Mouse.GetState();

            if (ms.X < Window.ClientBounds.Width * scroll)
            {
                Camera.Location.X = MathHelper.Clamp(Camera.Location.X - 4, 0,
                    (myMap.MapWidth - squaresAcross) * Tile.TileWidth);
            }

            if (ms.X > Window.ClientBounds.Width * (1 - scroll))
            {
                Camera.Location.X = MathHelper.Clamp(Camera.Location.X + 4, 0,
                    (myMap.MapWidth - squaresAcross) * Tile.TileWidth);
            }

            if (ms.Y < Window.ClientBounds.Height * scroll)
            {
                Camera.Location.Y = MathHelper.Clamp(Camera.Location.Y - 4, 0,
                    (myMap.MapHeight - squaresDown) * Tile.TileHeight);
            }

            if (ms.Y > Window.ClientBounds.Height * (1 - scroll))
            {
                Camera.Location.Y = MathHelper.Clamp(Camera.Location.Y + 4, 0,
                    (myMap.MapHeight - squaresDown) * Tile.TileHeight);
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            Vector2 firstSquare = new Vector2(Camera.Location.X / Tile.TileWidth, Camera.Location.Y / Tile.TileHeight);
            firstX = (int)firstSquare.X;
            firstY = (int)firstSquare.Y;

            Vector2 squareOffset = new Vector2(Camera.Location.X % Tile.TileWidth, Camera.Location.Y % Tile.TileHeight);
            offsetX = (int)squareOffset.X;
            offsetY = (int)squareOffset.Y;
            //Debug.Print("CAMERA LOC"+Camera.Location.X+ "  " +Camera.Location.Y+ "First X"+firstX+"      First Y"+firstY+"    "+offsetX + "   OFset y" + offsetY);
            for (int y = 0; y < squaresDown; y++)
            {
                for (int x = 0; x < squaresAcross; x++)
                {
                    foreach (int tileID in myMap.Rows[y + firstY].Columns[x + firstX].BaseTiles)
                    {
                        spriteBatch.Draw(
                            Tile.TileSetTexture,
                            new Rectangle(
                                (x * Tile.TileWidth) - offsetX, (y * Tile.TileHeight) - offsetY,
                                Tile.TileWidth, Tile.TileHeight),
                            Tile.GetSourceRectangle(tileID),
                            Color.White);
                        
                    }
                }
            }

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
