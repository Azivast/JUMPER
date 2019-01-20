using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Jumper
{
    class SpikeManager
    {
        // Variables
        private Texture2D texture;
        private Rectangle initialFrame;
        private int frameCount;

        public List<Sprite> Spikes = new List<Sprite>();

        // Constructor
        public SpikeManager(Texture2D texture, Rectangle initialFrame, int frameCount)
        {
            this.texture = texture;
            this.initialFrame = initialFrame;
            this.frameCount = frameCount;
        }

        // Function for spawning spike
        public void SpawnSpike(Vector2 position)
        {
            Sprite spike = new Sprite(position, texture, initialFrame);
            Spikes.Add(spike);
        }

        // Function for removing all spikes
        public void Reset()
        {
            Spikes.Clear();
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Sprite spike in Spikes)
            {
                spike.Draw(spriteBatch);
            }
        }
    }
}
