using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class Level
    {
        List<Beat> list = new List<Beat>();

        int Offset = 0;

        public Level(string filepath, Texture2D ArrowUp, Texture2D ArrowDown, Texture2D ArrowRight, Texture2D ArrowLeft)
        {
            using (StreamReader reader = new StreamReader(filepath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    bool left = line.Contains("1");
                    bool right = line.Contains("2");
                    bool up = line.Contains("3");
                    bool down = line.Contains("4");

                    Beat beat = new Game3.Beat(left, right, up, down, ArrowUp, ArrowDown, ArrowRight, ArrowLeft);
                    list.Add(beat);
                    //create beat object
                    //add to list of beats for level
                }
            }
        }

        public Beat CurrentBeat()
        {
            int index = (Offset - 350) / 80;

            if (index >= 0 && index < list.Count)
            {
                return list[list.Count - index - 1];
            }
            else
            {
                return null;
            }
            //return index >= 0 && index < list.Count ? list[index] : null;
        }

        public void Update(GameTime gameTime)
        {
            Offset += 3;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i=0; i<list.Count; i++)
            {
                int currentBeatOffset = Offset + (list.Count - i - 1) * -80;
                list[i].Draw(spriteBatch, currentBeatOffset);
            }
        }
    }
}
