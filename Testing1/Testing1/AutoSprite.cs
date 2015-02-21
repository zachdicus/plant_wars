using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Testing1
{
    class AutoSprite :Sprite
    {
        
        public AutoSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize,
            Vector2 speed)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed) { }
        public AutoSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize,
            Vector2 speed, int millisecondsPerFrame)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed, millisecondsPerFrame){        }

        
        public override Vector2 direction
        {
            get { return speed; }
        }
        public override void Update(GameTime gameTime, Rectangle clientBounds)
        { 
            position += direction;
            //if (position.X < 0)
            //    position.X = clientBounds.Width - frameSize.X;
            //if (position.Y < 0)
            //    position.Y = clientBounds.Height - frameSize.Y;
            //if (position.X > clientBounds.Width - frameSize.X)
            //    position.X = 0;
            //if (position.Y > clientBounds.Height - frameSize.Y)
            //    position.Y = 0;
            base.Update(gameTime, clientBounds);
        }
    }
}
