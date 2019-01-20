using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Jumper
{
    class BreakableManager
    {
        // Variables
        private Texture2D texture;
        private Rectangle initialFrame;
        private int frameCount;

        public List<Breakable> Breakables = new List<Breakable>();

        // Constructor
        public BreakableManager(Texture2D texture, Rectangle initialFrame, int frameCount)
        {
            this.texture = texture;
            this.initialFrame = initialFrame;
            this.frameCount = frameCount;
        }

        // Function for spawning breakables
        public void SpawnBreakable(Vector2 position)
        {
            Breakable breakable = new Breakable(texture, position, initialFrame, frameCount);
            Breakables.Add(breakable);
        }

        // Function for removing all breakables
        public void Reset()
        {
            Breakables.Clear();
        }


        // Update
        public void Update(GameTime gameTime)
        {
            for (int i = Breakables.Count - 1; i >= 0; i--)
            {
                Breakables[i].Update(gameTime);
            }
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Breakable breakable in Breakables)
            {
                breakable.Draw(spriteBatch);
            }
        }
    }
}
