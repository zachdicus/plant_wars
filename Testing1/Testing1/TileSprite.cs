using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Testing1
{
    abstract class TileSprite
    {
        Texture2D textureImage;
        protected Point frameSize;
        Point currentFrame;
        Point sheetSize;
        //int collisionOffset;
        int timeSinceLastFrame = 0;
        int millisecondsPerFrame;
        const int defaultMillisecondsPerFrame = 0;
        protected Vector2 speed;
        protected Vector2 position { get; set; }
        public TileSprite(Texture2D textureImage){
            this.textureImage = textureImage;
        }
        public TileSprite(Texture2D textureImage,Point frameSize, Point currentFrame, Point sheetSize,
            Vector2 speed)
            : this(textureImage, frameSize,currentFrame, sheetSize, speed, defaultMillisecondsPerFrame)
        {
        }
        public TileSprite(Texture2D textureImage, Point frameSize, Point currentFrame, Point sheetSize,
            Vector2 speed, int millisecondsPerFrame)
        {
            this.textureImage = textureImage;
            this.frameSize = frameSize;
            this.currentFrame = currentFrame;
            this.sheetSize = sheetSize;
            this.speed = speed;
            this.millisecondsPerFrame = millisecondsPerFrame;
        }
        public virtual void Update(GameTime gameTime, Rectangle clientBounds) {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                ++currentFrame.X;
                if (currentFrame.X > sheetSize.X)
                {
                    currentFrame.X = 0;
                }
            }

        }
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 posistion)
        {
            spriteBatch.Draw(textureImage, position, new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
        }
        public abstract Vector2 direction
        {
            get;
        }

       
    }

}
