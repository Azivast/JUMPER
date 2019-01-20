using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jumper
{
    class Breakable
    {
        public Sprite Sprite;
        private int breakTime = 70;
        private int respawnTime = 400;
        private int timer;
        public bool Breaking;
        public bool IsBroken;

        // Constructor
        public Breakable(Texture2D texture, Vector2 position, Rectangle initialFrame, int frameCount)
        {
            // Create the sprite
            Sprite = new Sprite(position, texture, initialFrame);

            Sprite.Animate = false;

            // Add the frames to the sprite
            for (int i = 1; i < frameCount; i++)
            {
                Sprite.AddFrame(new Rectangle(initialFrame.X = (initialFrame.Width * i), initialFrame.Y, initialFrame.Width, initialFrame.Height));
            }

            // Set timer to correct length
            timer = breakTime;
        }

        // Update
        public void Update(GameTime gameTime)
        {
            if (Breaking)
            {
                timer--;

                if (timer <= 0)
                {
                    IsBroken = true;
                    Breaking = true;
                }
            }

            // Respawn after respawnTime has been reached
            if (timer <= -400)
            {
                Breaking = false;
                IsBroken = false;
                timer = breakTime;
            }
        }
        // Breaks and removes the block
        public void Break()
        {
            Breaking = true;
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!IsBroken)
            {
                Sprite.Draw(spriteBatch);
            }
        }
    }
}
