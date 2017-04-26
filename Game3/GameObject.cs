using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
     class GameObject
    {
        int frameDuration = 200;
        int frameTotalTime = 0;
        int currentFrame = 0;
        int currentState = 0;
        int currentStateImageCount = 2;
        int yVelocity = 0;
        bool jumping = false;
        bool isDead = false;

        int spriteWidth = 64;
        int spriteHeight = 64;
        Texture2D texture;
        public Vector2 position;

        public GameObject(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
        }

        public void Update(GameTime gameTime)
        {
            frameTotalTime += gameTime.ElapsedGameTime.Milliseconds;
            if (frameTotalTime > frameDuration)
            {
                frameTotalTime = 0;

                if (currentFrame != 9)
                {
                    currentFrame++;
                    currentFrame %= currentStateImageCount;
                }

            }
            if (!isDead)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    position.X -= 4;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    position.X += 4;
                }
            }

            position.Y -= yVelocity;
            yVelocity--;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position,
                sourceRectangle: new Rectangle(
                                        currentFrame * spriteWidth,
                                        currentState * spriteHeight,
                                        spriteWidth,
                                        spriteHeight));
        }
    }
}