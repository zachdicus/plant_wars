using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Testing1
{
    class UserSprite : TileSprite
    {
        public UserSprite(Texture2D textureImage,  Point frameSize,Point currentFrame, Point sheetSize,
            Vector2 speed)
            : base(textureImage, frameSize, currentFrame, sheetSize, speed) { }
        public UserSprite(Texture2D textureImage,Point frameSize, Point currentFrame, Point sheetSize,
            Vector2 speed, int millisecondsPerFrame)
            : base(textureImage, frameSize,  currentFrame, sheetSize, speed, millisecondsPerFrame){        }
        public override Vector2 direction
        {
            get
            {
                Vector2 inputDirection = Vector2.Zero;
                KeyboardState kbs = Keyboard.GetState();
                if (kbs.IsKeyDown(Keys.Left))
                    inputDirection.X -= 1;
                if (kbs.IsKeyDown(Keys.Right))
                    inputDirection.X += 1;
                if (kbs.IsKeyDown(Keys.Up))
                    inputDirection.Y -= 1;
                if (kbs.IsKeyDown(Keys.Down))
                    inputDirection.Y += 1;
                return inputDirection * speed;
            }
        }
        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
           
            base.Update(gameTime, clientBounds);
        }
    }
}
