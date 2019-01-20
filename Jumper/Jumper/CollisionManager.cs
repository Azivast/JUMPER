using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Jumper
{
    class CollisionManager
    {
        private PlayerManager player;
        private EnemyManager enemyManager;
        private BreakableManager breakableManager;
        private SpikeManager spikeManager;
        private KeyDoor keyDoor;
        private HeartManager heartManager;

        public CollisionManager(
            PlayerManager player,
            EnemyManager enemyManager,
            BreakableManager breakableManager,
            SpikeManager spikeManager,
            KeyDoor keyDoor,
            HeartManager heartManager
            )
        {
            this.player = player;
            this.enemyManager = enemyManager;
            this.breakableManager = breakableManager;
            this.spikeManager = spikeManager;
            this.keyDoor = keyDoor;
            this.heartManager = heartManager;
        }

        private void checkPlayerToEnemyCollision()
        {
            foreach (Enemy enemy in enemyManager.Enemies)
                if (player.Sprite.IsBoxColliding(enemy.EnemySprite.Rectangle))
                {
                    player.KillPlayer();
                }                
        }

        // Check all breakable collisions
        private void checkPlayerToBreakableCollisions()
        {
            // Check collisions
            foreach (Breakable breakable in breakableManager.Breakables)
            {
                if (!breakable.IsBroken)
                {
                    if (playerCollidesBottom(breakable.Sprite) ||
                        playerCollidesTop(breakable.Sprite) ||
                        playerCollidesRight(breakable.Sprite) ||
                        playerCollidesLeft(breakable.Sprite))
                    {
                        breakable.Break();
                    }
                }
            }
        }

        // Check all spike collisions
        private void checkPlayerToSpikeCollisions()
        {
            // Bool used to prevent KillPlayer() below from being run twice at a time
            bool isColliding = false;

            // Check if player collides with any of the sprikes
            foreach (var spike in spikeManager.Spikes)
            {
                if (player.Sprite.IsBoxColliding(spike.Rectangle))
                {
                    isColliding = true;
                }
            }

            if (isColliding)
            {
                player.KillPlayer();
            }
        }

        // Check collisions to all keys
        private void checkPlayerToKeyCollisions()
        {
            for (int i = 0; i < keyDoor.Keys.Count; i++)
            {
                Sprite key = keyDoor.Keys[i];

                if (player.Sprite.IsBoxColliding(key.Rectangle))
                {
                    // Pick up the key
                    keyDoor.PickUpKey(key);
                    // Add additional time to player
                    player.LevelTimeLeft += 10;
                }
            }
        }

        // Check collisions to hearts
        private void checkPlayerToHeartCollisions()
        {
            for (int i = 0; i < heartManager.Hearts.Count; i++)
            {
                Sprite heart = heartManager.Hearts[i];

                if (player.Sprite.IsBoxColliding(heart.Rectangle))
                {
                    // Pick up the key
                    heartManager.PickUpHeart(heart);
                }
            }
        }

        // Check collisions to door
        private void checkPlayerToDoorCollision()
        {
            if (keyDoor.DoorOpen && player.Sprite.IsBoxColliding(keyDoor.DoorRectangle))
            {
                // Move to next level
                Game1.C1Level++;

                // Play sound
                SoundManager.NextLevel.Play();
            }
        }

        // Check all wall collisions
        private void checkPlayerToTilesCollisions(TileManager tileManager)
        {
            // Check collisions
            foreach (Sprite tile in tileManager.Tiles)
            {
                playerCollidesBottom(tile);
                playerCollidesTop(tile);
                playerCollidesRight(tile);
                playerCollidesLeft(tile);
            }
        }

        // Check if player collides with top of tile
        private bool playerCollidesBottom(Sprite tile)
        {
            if (player.Sprite.Rectangle.Bottom >= tile.Rectangle.Top - 2 &&
                    player.Sprite.Rectangle.Bottom <= tile.Rectangle.Top + (tile.Rectangle.Height / 2) &&
                    player.Sprite.Rectangle.Right >= tile.Rectangle.Left &&
                    player.Sprite.Rectangle.Left <= tile.Rectangle.Right)
            {
                player.CollidesBottom = true;
                return true;
            }
            return false;
        }
        // Check if player collides with bottom of tile
        private bool playerCollidesTop(Sprite tile)
        {
            if (player.Sprite.Rectangle.Top <= tile.Rectangle.Bottom &&
                player.Sprite.Rectangle.Top >= tile.Rectangle.Bottom - (tile.Rectangle.Height / 2) &&
                player.Sprite.Rectangle.Right >= tile.Rectangle.Left &&
                player.Sprite.Rectangle.Left <= tile.Rectangle.Right)
            {
                player.CollidesTop = true;
                return true;
            }
            return false;
        }
        // Check if player collides with left of tile
        private bool playerCollidesRight(Sprite tile)
        {
            if (player.Sprite.Rectangle.Bottom >= tile.Rectangle.Top + 2 &&
                player.Sprite.Rectangle.Top <= tile.Rectangle.Bottom - 2 &&
                player.Sprite.Rectangle.Right >= tile.Rectangle.Left - 2 &&
                player.Sprite.Rectangle.Right <= tile.Rectangle.Left + 5)
            {
                player.CollidesRight = true;
                return true;
            }
            return false;
        }
        // Check if player collides with right of tile
        private bool playerCollidesLeft(Sprite tile)
        {
            if (player.Sprite.Rectangle.Bottom >= tile.Rectangle.Top + 2 &&
                player.Sprite.Rectangle.Top <= tile.Rectangle.Bottom - 2 &&
                player.Sprite.Rectangle.Left <= tile.Rectangle.Right + 2 &&
                player.Sprite.Rectangle.Left >= tile.Rectangle.Right - 5)
            {
                player.CollidesLeft = true;
                return true;
            }
            return false;
        }

        // Update
        public void Update(GameTime gameTime, TileManager tileManager, KeyDoor keyDoor, SpikeManager spikeManager)
        {
            // Reset so player can move again
            player.CollidesTop = false;
            player.CollidesBottom = false;
            player.CollidesRight = false;
            player.CollidesLeft = false;

            // Check collisions
            checkPlayerToTilesCollisions(tileManager);
            checkPlayerToBreakableCollisions();
            checkPlayerToSpikeCollisions();
            checkPlayerToEnemyCollision();
            checkPlayerToKeyCollisions();
            checkPlayerToDoorCollision();
            checkPlayerToHeartCollisions();
        }
    }
}
