using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jumper
{
    class Sprite
    {
        // Variables
        public Texture2D Texture;

        private int frameWidth = 0;
        private int frameHeight = 0;
        private int currentFrame = 0;
        private float frameTime = 0.1f;
        private float timeForCurrentFrame = 0.0f;
        private bool animate = true;

        private Color tintColor = Color.White;
        private float rotation = 0.0f;
        // Point which sprite rotates around
        private Vector2 origin;

        public int CollisionRadius = 0;
        // Padding for collision
        public int BoundingXPadding = -3;
        public int BoundingYPadding = -3;

        public Vector2 Position = Vector2.Zero;
        public Vector2 Velocity = Vector2.Zero;
        // List for sprite frames
        protected List<Rectangle> frames = new List<Rectangle>();
  
        // Constructor
        public Sprite(
            Vector2 position,
            Texture2D texture,
            Rectangle initialFrame)
        {
            // Update internal variables to the ones supplied by the constructor
            this.Position = position;
            Texture = texture;

            // Add the frames
            frames.Add(initialFrame);
            frameWidth = initialFrame.Width;
            frameHeight = initialFrame.Height;
            // Sets the origin to the sprite's center by default
            origin = new Vector2(frameWidth / 2, frameHeight / 2);
        }
        
        // Get/set's

        public Color TintColor
        {
            get { return tintColor; }
            set { tintColor = value; }
        }

        public float Rotation
        {
            get { return rotation; }
            // Keep rotation between 0 and 2xPi
            set { rotation = value % MathHelper.TwoPi; }
        }

        public Vector2 Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        public int Frame
        {
            get { return currentFrame; }
            set
            {
                // Limit currentFrames to the total amount of frames
                currentFrame = (int)MathHelper.Clamp(value, 0, frames.Count - 1);
            }
        }

        public int FrameWidth
        {
            get { return frameWidth; }
        }
        public int FrameHeight
        {
            get { return frameHeight; }
        }

        // Function to get animation playback speed
        public float FrameTime
        {
            get { return frameTime; }
            set { frameTime = MathHelper.Max(0, value); }
        }
        // Function used in other classes for whether to animate the sprite or not
        public bool Animate
        {
            get { return animate; }
            set { animate = value; }
        }
        // Function which returnes rectangle of current frame
        public Rectangle Source
        {
            get { return frames[currentFrame]; }
        }
        // Function that returns rectangle of the sprites current position and size
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, frameWidth, frameHeight);
            }
        }

        public Vector2 Center
        {
            get
            {
                return Position + new Vector2(frameWidth / 2, frameHeight / 2);
            }
        }

        // Function used to determine whether sprite intersects a rectangle
        public bool IsBoxColliding(Rectangle OtherBox)
        {
            return Rectangle.Intersects(OtherBox);
        }
        // Function used to determine whether sprite intersects a sphere
        public bool IsCircleColliding(Vector2 otherCenter, float otherRadius)
        {
            if (Vector2.Distance(Center, otherCenter) < (CollisionRadius + otherRadius))
                return true;
            else
                return false;
        }

        // Function to add a frame to the sprite
        public void AddFrame(Rectangle frameRectangle)
        {
            frames.Add(frameRectangle);
        }

        // Update
        public virtual void Update(GameTime gameTime)
        {
            // Create float of elapsed time
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            // Increase the timeForCurrentFrame with elapsed time
            timeForCurrentFrame += elapsed;
            // Change to next frame once timeForCurrentFrame surpasses FrameTime, and then reset timeForCurrentFrame
            if (animate == true && timeForCurrentFrame >= FrameTime)
            {
                currentFrame = (currentFrame + 1) % (frames.Count);
                timeForCurrentFrame = 0.0f;
            }
            // Update the position of the sprite according to its velocity and elapsed time
            //Position += (Velocity * elapsed);
            Position += Velocity;
        }

        // Draw
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            // Draw the sprite
            spriteBatch.Draw(
                Texture,
                Center,
                Source,
                tintColor,
                rotation,
                origin,
                1.0f,
                SpriteEffects.None,
                0.0f);
        }
    }
}
