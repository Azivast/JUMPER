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

        // List of all tiles to check collision against
        List<Sprite> Tiles = new List<Sprite>();

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
            // Calculate a smaller player  hitbox
            Rectangle playerRect = player.Sprite.Rectangle;
            playerRect.Inflate(-1, -1);
            foreach (Enemy enemy in enemyManager.Enemies)
                if (playerRect.Intersects(enemy.EnemySprite.Rectangle))
                {
                    player.KillPlayer();
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
                    player.LevelTimeLeft += 5;
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
                Game1.C2Level++;

                // Play sound
                SoundManager.NextLevel.Play();
            }
        }

        // Check all breakable collisions
        private void checkPlayerToBreakableCollisions()
        {
            // Calculate rectangle for player
            Rectangle playerRect = new Rectangle(player.WantedPosRect.X, player.WantedPosRect.Y, player.WantedPosRect.Width, player.WantedPosRect.Height + 1);
            // Check collisions
            foreach (Breakable breakable in breakableManager.Breakables)
            {
                if (!breakable.IsBroken)
                {
                    if (playerRect.Intersects(breakable.Sprite.Rectangle))
                    {
                        breakable.Break();
                    }
                }
            }
        }

        // Check if Rectangle will collide with a tile
        private bool RectangleCollidesWithTile(Rectangle rectangle, List<Sprite> Tiles)
        {
            //player.WillCollide = false;
            foreach (Sprite tile in Tiles)
            {
                if (rectangle.Intersects(tile.Rectangle))
                    return true;
            }

            return false;
        }

        // Creates a rectangle at given position
        private Rectangle CreateRectangleAtPosition(Vector2 positionToTry, int width, int height)
        {
            return new Rectangle((int)positionToTry.X, (int)positionToTry.Y, width, height);
        }

        // Determine where a function can travel without getting stuck in a tile
        public Vector2 WhereCanPlayerGo(Vector2 originalPosition, Vector2 destination, Rectangle boundingRectangle, TileManager tileManager)
        {
            // Clear list of tiles
            Tiles.Clear();

            // Add tiles to list
            Tiles.AddRange(tileManager.Tiles);
            // Add active breakables to the list
            foreach (Breakable breakable in breakableManager.Breakables)
            {
                if (!breakable.IsBroken)
                {
                    Tiles.Add(breakable.Sprite);
                    //Console.Write("add");
                }
            }
            //Console.Write(Tiles.Count);

            Vector2 movementToTry = destination - originalPosition;
            Vector2 furthestAvailableLocationSoFar = originalPosition;
            int numberOfStepsToBreakMovementInto = (int)(movementToTry.Length() * 2) + 1;
            Vector2 oneStep = movementToTry / numberOfStepsToBreakMovementInto;

            // Check every possible step
            for (int i = 1; i <= numberOfStepsToBreakMovementInto; i++)
            {
                Vector2 positionToTry = originalPosition + oneStep * i;
                Rectangle newBoundary = CreateRectangleAtPosition(positionToTry, boundingRectangle.Width, boundingRectangle.Height);

                // Check if player collides with tile
                if (!RectangleCollidesWithTile(newBoundary, Tiles))
                {
                    furthestAvailableLocationSoFar = positionToTry;
                }

                // If player does collide
                else
                {
                    // Check if movement is  diagonal
                    bool isDiagonalMove = movementToTry.X != 0 && movementToTry.Y != 0;
                    // If it is, check if player can move in any direction of the left over diagonal movement
                    if (isDiagonalMove)
                    {
                        int stepsLeft = numberOfStepsToBreakMovementInto - (i - 1);

                        Vector2 remainingHorizontalMovement = oneStep.X * Vector2.UnitX * stepsLeft;
                        Vector2 finalPositionIfMovingHorizontally = furthestAvailableLocationSoFar + remainingHorizontalMovement;
                        furthestAvailableLocationSoFar =
                            WhereCanPlayerGo(furthestAvailableLocationSoFar, finalPositionIfMovingHorizontally, boundingRectangle, tileManager);

                        Vector2 remainingVerticalMovement = oneStep.Y * Vector2.UnitY * stepsLeft;
                        Vector2 finalPositionIfMovingVertically = furthestAvailableLocationSoFar + remainingVerticalMovement;
                        furthestAvailableLocationSoFar =
                            WhereCanPlayerGo(furthestAvailableLocationSoFar, finalPositionIfMovingVertically, boundingRectangle, tileManager);
                    }
                    break;
                }
            }
            return furthestAvailableLocationSoFar;
        }

        public void MovePlayerWherePossible(TileManager tileManager)
        {
            // Update position to where player can move
            player.NextPos = WhereCanPlayerGo(player.Position, player.WantedPos, player.Sprite.Rectangle, tileManager);

            // Check if player is falling
            if (RectangleCollidesWithTile(
                new Rectangle((int)player.NextPos.X, (int)player.NextPos.Y + 1, player.Rectangle.Width, player.Rectangle.Height),
                Tiles))
            {
                player.Airborne = false;
                player.Sprite.Velocity.Y = 0;
            }
            else
                player.Airborne = true;

            // Check if player hit its head
            if (RectangleCollidesWithTile(
                new Rectangle((int)player.NextPos.X, (int)player.NextPos.Y - 1, player.Rectangle.Width, player.Rectangle.Height),
                Tiles))
            {
                // if so stop player and move downwards
                player.Sprite.Velocity.Y = 0.6f;
                //player.Airborne = true;
            }
        }


        // Update
        public void Update(GameTime gameTime, TileManager tileManager, KeyDoor keyDoor, SpikeManager spikeManager)
        {
            // Check collisions
            checkPlayerToBreakableCollisions();
            MovePlayerWherePossible(tileManager);
            checkPlayerToSpikeCollisions();
            checkPlayerToEnemyCollision();
            checkPlayerToKeyCollisions();
            checkPlayerToDoorCollision();
            checkPlayerToHeartCollisions();
        }
    }
}
