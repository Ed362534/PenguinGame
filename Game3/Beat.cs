using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class Beat
    {
        public bool left;
        public bool right;
        public bool up;
        public bool down;

        public bool leftPressed;
        public bool rightPressed;
        public bool upPressed;
        public bool downPressed;

        Texture2D ArrowUp;
        Texture2D ArrowDown;
        Texture2D ArrowRight;
        Texture2D ArrowLeft;

        public Beat(bool left, bool right, bool up, bool down, Texture2D ArrowUp, Texture2D ArrowDown, Texture2D ArrowRight, Texture2D ArrowLeft)
        {
            this.left = left;
            this.right = right;
            this.up = up;
            this.down = down;

            this.ArrowDown = ArrowDown;
            this.ArrowLeft = ArrowLeft;
            this.ArrowRight = ArrowRight;
            this.ArrowUp = ArrowUp;
        }

        public void Draw(SpriteBatch spriteBatch, int offset)
        {
            if(left && !leftPressed) spriteBatch.Draw(ArrowLeft, new Vector2(50, offset + 25));
            if(right && !rightPressed) spriteBatch.Draw(ArrowRight, new Vector2(150, offset + 25));
            if(up && !upPressed) spriteBatch.Draw(ArrowUp, new Vector2(250, offset));
            if(down && !downPressed) spriteBatch.Draw(ArrowDown, new Vector2(330, offset));
        }
    }
}
