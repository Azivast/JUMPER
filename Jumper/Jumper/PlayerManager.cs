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
        public float LevelTime;

        public bool CollidesTop;
        public bool CollidesBottom;
        public bool CollidesRight;
        public bool CollidesLeft;

        // Defines get/sets
        public Vector2 Position
        {
            get { return Sprite.Position; }
            set { Sprite.Position = value; }
        }

        public bool Airborne => !CollidesBottom;

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
            // Gravity
            if (Airborne && Sprite.Velocity.Y < 4)
            {
                Sprite.Velocity.Y += gravity;
            }
            if (Airborne == false)
            {
                Sprite.Velocity.Y = 0;
            }

            if (CollidesTop)
            {
                Sprite.Velocity.Y = 0;
                // Move player down one pixel to avoid getting stuck as long as not standing on ground
                if (!CollidesBottom)
                    Sprite.Position.Y++;
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

            // Animates the player Right and creates a boundry to confine the player within the Right side of the window
            if (InputManager.KBState.IsKeyDown(Keys.Right) && !CollidesRight)
            {
                AnimateRight(gameTime);
                    Sprite.Velocity.X = spriteSpeed;
            }

            // Animates the player Left and creates a boundry to confine the player within the Left side of the window
            else if (InputManager.KBState.IsKeyDown(Keys.Left) && !CollidesLeft)
            {
                AnimateLeft(gameTime);
                    Sprite.Velocity.X = spriteSpeed*-1;
            }
            else
            {
                Sprite.Velocity.X = 0;
            }
            // Check if player should jump
            if (InputManager.KBState.IsKeyDown(Keys.Up) && Airborne == false && !CollidesTop)
            {
                // Increase player's Velocity upwards
                Sprite.Velocity.Y -= 4.1f;
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
            //else if (Sprite.Position.Y >= 480 - Sprite.FrameHeight && Sprite.Velocity.Y > 0)
            else if (Sprite.Position.Y >= 480)
            {
                KillPlayer();
            }
            Sprite.Update(gameTime);

            // Update time
            LevelTimeLeft -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            // Kill player if time runs out
            if (LevelTimeLeft < LevelTime)
            {
                KillPlayer();
            }
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
