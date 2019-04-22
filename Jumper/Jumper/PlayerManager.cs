using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jumper
{
    class PlayerManager
    {
        // Variables
        public Sprite Sprite;
        private float timer = 0f;
        private float interval = 150f;
        private int currentFrame = 0;
        private int spriteSpeed = 3;
        private float gravity = 0.15f;
        private int startLives = 3;
        public int Lives;
        public float LevelTimeLeft;

        // Defines get/sets
        public Vector2 Position
        {
            get { return Sprite.Position; }
            set { Sprite.Position = value; }
        }

        // Vector2of where the player wants to be
        public Vector2 WantedPos =>
            new Vector2(Sprite.Rectangle.X + (int)Sprite.Velocity.X, Sprite.Rectangle.Y + (int)Sprite.Velocity.Y);
        // Rectangle of where the player wants to be
        public Rectangle WantedPosRect =>
            new Rectangle(Sprite.Rectangle.X + (int)Sprite.Velocity.X, Sprite.Rectangle.Y + (int)Sprite.Velocity.Y, Rectangle.Width, Rectangle.Height);

        // Vector2 of where the player will be after next move
        public Vector2 NextPos;

        public bool Airborne = true;

        public Rectangle Rectangle => Sprite.Rectangle;

        // Constructor
        public PlayerManager(Sprite sprite)
        {
            this.Sprite = sprite;
            Lives = startLives;

            // Disable sprite class' animation so that animation can be handled here instead
            Sprite.Animate = false;
        }

        // Function to kill player
        public void KillPlayer()
        {
            SoundManager.Hurt.Play();
            if (Lives > 1)
            {
                Lives--;
                Game1.C1Level--;
                Game1.C2Level--;
            }
            else
            {
                Game1.gameState = Game1.GameState.GameOver;
            }
        }

        // Reset player
        public void Reset()
        {
            Lives = startLives;
        }

        // Update player
        public void Update(GameTime gameTime)
        {
            // Update time
            LevelTimeLeft -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            // Kill player if time runs out
            if (LevelTimeLeft < 0)
            {
                KillPlayer();
            }

            // Reset to idle frame if movement keys are released 
            if (InputManager.KBState.IsKeyUp(Keys.Left) && InputManager.PrevKBState.IsKeyDown(Keys.Left))
            {
                Sprite.Frame = 5;
            }
            else if (InputManager.KBState.IsKeyUp(Keys.Right) && InputManager.PrevKBState.IsKeyDown(Keys.Right))
            {
                Sprite.Frame = 0;
            }


            CheckKeyboardAndUpdateVelocity(gameTime);
            Gravity();
            // Run MovePlayerIfNoCollision() from game1.cs after collisionsmanager has been updated
        }

        private void Gravity()
        {
            if (Sprite.Velocity.Y < 4)
            {
                Sprite.Velocity.Y += gravity;

                // Make player stay still in air shorter
                if (Sprite.Velocity.Y < 1 && Sprite.Velocity.Y > 0)
                {
                    Sprite.Velocity.Y += 0.5f;
                }
            }
        }

        private void CheckKeyboardAndUpdateVelocity(GameTime gameTime)
        {
            // Reset velocity
            Sprite.Velocity.X = 0;

            // Right
            if (InputManager.KBState.IsKeyDown(Keys.Right))
            {
                AnimateRight(gameTime);
                Sprite.Velocity.X += spriteSpeed;
            }

            // Left
            else if (InputManager.KBState.IsKeyDown(Keys.Left))
            {
                AnimateLeft(gameTime);
                Sprite.Velocity.X -= spriteSpeed;
            }

            // Jump
            if (InputManager.KBState.IsKeyDown(Keys.Up) && !Airborne)
            {
                // Increase player's Velocity upwards
                Sprite.Velocity.Y -= 4.9f;

                Airborne = true;
            }



            // Stop player from moving outside window
            if (Sprite.Position.X <= 0 && Sprite.Velocity.X < 0)
            {
                Sprite.Velocity.X = 0;
            }
            else if (Sprite.Position.X >= 800 - Sprite.FrameWidth && Sprite.Velocity.X > 0)
            {
                Sprite.Velocity.X = 0;
            }
            else if (Sprite.Position.Y <= 0 && Sprite.Velocity.Y < 0)
            {
                Sprite.Velocity.Y = 0;
            }
            // Kill player is falling below screen
            else if (Sprite.Position.Y >= 480)
            {
                KillPlayer();
            }
        }

        public void MovePlayerIfNoCollision()
        {
            // Move player
            Sprite.Position = NextPos;
        }

        public void AnimateRight(GameTime gameTime)
        {
            // Resets to the first "right frame" if right was not previously pressed
            if (InputManager.PrevKBState.IsKeyUp(Keys.Right))
            {
                Sprite.Frame = 0;
            }

            // Creates a timer that counts upwards in milliseconds
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            // Changes frame and resets the timer once it reaches the value of "interval"
            if (timer > interval)
            {
                //Loops back to the "first" frame once the "last" one is reached
                if (Sprite.Frame >= 4)
                {
                    Sprite.Frame = 0;
                }
                Sprite.Frame++;
                timer = 0f;
            }
        }

        public void AnimateLeft(GameTime gameTime)
        {
            // Resets to the first "right frame" if Right is released
            if (InputManager.PrevKBState.IsKeyUp(Keys.Left))
            {
                Sprite.Frame = 4;
            }
            // Creates a timer that counts upwards in milliseconds.
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            // Changes frame and resets the timer once it reaches the value of "interval"
            if (timer > interval)
            {
                // Loops back to the "first" frame once the "last" one is reached
                if (Sprite.Frame >= 8)
                {
                    Sprite.Frame = 4;
                }
                Sprite.Frame++;
                timer = 0f;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }
    }
}
