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
        // Variables.
        Texture2D playerSprite;
        float timer = 0f;
        float interval = 200f;
        int currentFrame = 0;
        int spriteWidth = 29;
        int spriteHeight = 47;
        int spriteSpeed = 2;
        Rectangle sourceRect;
        Vector2 position;
        Vector2 velocity;
        bool Airborne = false;

        // Defines get/sets.
        public Vector2 Poisition
        {
            get { return position; }
            set { position = value; }
        }

        public Vector2 Velocity
        {
            get { return velocity;  }
            set { velocity = value; }
        }

        public Texture2D Texture
        {
            get { return playerSprite; }
            set { playerSprite = value; }
        }
        
        public Rectangle SourceRect
        {
            get { return sourceRect; }
            set { sourceRect = value; }
        }

        // Constructor; Specifies what is needed to create an object using this class.
        public PlayerManager(Texture2D texture, int currentFrame, int spriteWidth, int spriteHeight)
        {
            this.playerSprite = texture;
            this.currentFrame = currentFrame;
            this.spriteWidth = spriteWidth;
            this.spriteHeight = spriteHeight;
        }

        // Variables for the current and prevous keyboardstate.
        KeyboardState currentKBState;
        KeyboardState previousKBState;

        // HandleSpriteMovement
        public void HandleSpriteMovement(GameTime gameTime)
        {
            // Sets the previous keyboard state to the current and then updates the current one.
            previousKBState = currentKBState;
            currentKBState = Keyboard.GetState();

            // Create rectangle from current playing frame.
            sourceRect = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);

            // Gravity
            if (Airborne && velocity.Y < 4)
            {
                velocity.Y += 0.15f;
            }
            else if (Airborne == false)
            {
                velocity.Y = 0;
            }

            // Animate if keys are pressed
            if (currentKBState.GetPressedKeys().Length == 0)
            {
                // Start at the first frame when pressing down.
                if (currentFrame > 0 && currentFrame < 4)
                {
                    currentFrame = 0;
                }
                // Start at the fourth frame when pressing left.
                if (currentFrame > 4 && currentFrame < 8)
                {
                    currentFrame = 4;
                }
            }

            // Animates the player Right and creates a boundry to confine the player within the Right side of the window.
            if (currentKBState.IsKeyDown(Keys.Right))
            {
                AnimateRight(gameTime);
                if (position.X < 780)
                {
                    velocity.X = spriteSpeed;
                }
            }

            // Animates the player Left and creates a boundry to confine the player within the Left side of the window.
            else if (currentKBState.IsKeyDown(Keys.Left))
            {
                AnimateLeft(gameTime);
                if (position.X > 20)
                {
                    velocity.X = spriteSpeed*-1;
                }
            }
            else
            {
                velocity.X = 0;
            }
            // Check if player should jump
            if (currentKBState.IsKeyDown(Keys.Up) && Airborne == false)
            {
                // Increase player's velocity upwards.
                velocity.Y -= 5f;
                // Move player one pixel up to avoid collision with platform.
                position.Y--;
                // Set playerAirborne to true to prevent flying.
                Airborne = true;
            }

            // DEBUG REMOVE BEFORE RELEASE
            if (currentKBState.IsKeyDown(Keys.Space))
            {
                Airborne = false;
            }

            // Apply velocity to player
            position += velocity;
        }


        public void AnimateRight(GameTime gameTime)
        {
            // Resets to the first "right frame" if Right is released.
            if (currentKBState != previousKBState)
            {
                currentFrame = 0;
            }

            // Creates a timer that counts upwards in milliseconds.
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            // Changes frame and resets the timer once it reaches the value of "interval".
            if (timer > interval)
            {
                currentFrame++;
                // Loops back to the "first" frame once the "last" one is reached.
                if (currentFrame > 3)
                {
                    currentFrame = 0;
                }
                timer = 0f;
            }
        }

        public void AnimateLeft(GameTime gameTime)
        {
            // Resets to the first "right frame" if Right is released.
            if (currentKBState != previousKBState)
            {
                currentFrame = 4;
            }
            // Creates a timer that counts upwards in milliseconds.
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            // Changes frame and resets the timer once it reaches the value of "interval".
            if (timer > interval)
            {
                currentFrame++;
                // Loops back to the "first" frame once the "last" one is reached.
                if (currentFrame > 6)
                {
                    currentFrame = 4;
                }
                timer = 0f;
            }
        }
    }
}
