using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Jumper
{
    class HeartManager
    {
        // Variables
        private PlayerManager player;
        private Texture2D texture;
        private Rectangle initialFrame;
        private int frameCount;

        public List<Sprite> Hearts = new List<Sprite>();

        // Constructor
        public HeartManager(PlayerManager player, Texture2D texture, Rectangle initialFrame, int frameCount)
        {
            this.player = player;
            this.texture = texture;
            this.initialFrame = initialFrame;
            this.frameCount = frameCount;
        }

        // Function for spawning heart
        public void SpawnHeart(Vector2 position)
        {
            Sprite heart = new Sprite(position, texture, initialFrame);
            Hearts.Add(heart);
        }

        // Function for removing (picking up) a key
        public void PickUpHeart(Sprite heart)
        {
            Hearts.Remove(heart);
            player.Lives++;
            SoundManager.PickUp.Play();
        }

        // Function for removing all heart
        public void Reset()
        {
            Hearts.Clear();
        }


        // Update
        public void Update(GameTime gameTime)
        {
            for (int i = Hearts.Count - 1; i >= 0; i--)
            {
                Hearts[i].Update(gameTime);
            }
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Sprite heart in Hearts)
            {
                heart.Draw(spriteBatch);
            }
        }
    }
}
