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
    class Control
    {
        public Keys actionKey;
        Texture2D texture;
        Vector2 position;
        public Control(Texture2D texture, Vector2 position, Keys actionKey)
        {
            this.actionKey = actionKey;
            this.texture = texture;
            this.position = position;
        }

        public bool IsPressed()
        {
            return Keyboard.GetState().IsKeyDown(actionKey);
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Keyboard.GetState().IsKeyDown(actionKey))
            {
                spriteBatch.Draw(texture, position, Color.DarkGray);
            }
            else
            {
                spriteBatch.Draw(texture, position, Color.White);
            }
        }
    }
}
