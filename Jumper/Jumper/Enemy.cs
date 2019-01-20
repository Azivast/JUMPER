using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jumper
{
    class Enemy
    {
        public Sprite EnemySprite;
        // Speed at which enemies move
        private int speed;
        private int heading;

        // Points which enemy moves between
        private Vector2 position1;
        private Vector2 position2;

        // Constructor
        public Enemy(Texture2D texture, Vector2 position1, Vector2 position2, int speed, Rectangle initialFrame, int frameCount)
        {
            // Create the sprite
            EnemySprite = new Sprite(position1, texture, initialFrame);

            // Add the frames to the sprite
            for (int i = 1; i < frameCount; i++)
            {
                EnemySprite.AddFrame(new Rectangle(initialFrame.X = (initialFrame.Width * i), initialFrame.Y, initialFrame.Width, initialFrame.Height));
            }

            // Update internal variables
            this.position1 = position1;
            this.position2 = position2;

            // Set movement speed
            this.speed = speed;
        }
        // Update
        public void Update(GameTime gameTime)
        {
            // Adjust heading so enemy always walks between the positions
            if (EnemySprite.Position.X <= position1.X)
            {
                heading = speed;
            }
            else if (EnemySprite.Position.X >= position2.X)
            {
                heading = speed * -1;
            }

            // Update position
            EnemySprite.Position.X += heading;

            // Update the enemy sprite
            EnemySprite.Update(gameTime);
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            EnemySprite.Draw(spriteBatch); 
        }
    }
}
