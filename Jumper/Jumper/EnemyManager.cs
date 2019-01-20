using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Jumper
{
    class EnemyManager
    {
        // Variables
        private Texture2D texture;
        private Rectangle initialFrame;
        private int frameCount;

        public List<Enemy> Enemies = new List<Enemy>();

       
        // Constructor for EnemyManager
        public EnemyManager(Texture2D texture, Rectangle initialFrame, int frameCount)
        {
            this.texture = texture;
            this.initialFrame = initialFrame;
            this.frameCount = frameCount;
        }

        // Function for spawning enemies
        public void SpawnEnemy(Vector2 position1, Vector2 position2, int speed)
        {
            Enemy thisEnemy = new Enemy(texture, position1, position2, speed, initialFrame, frameCount);
            Enemies.Add(thisEnemy);
        }

        // Function for removing all enemies and shots on screen
        public void Reset()
        {
            Enemies.Clear();
        }

       
        // Update
        public void Update(GameTime gameTime)
        {
            for (int i = Enemies.Count - 1; i >= 0; i--)
            {
                Enemies[i].Update(gameTime);
            }
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Enemy enemy in Enemies)
            {
                enemy.Draw(spriteBatch);
            }
        }
    }
}
