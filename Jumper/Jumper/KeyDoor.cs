using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Jumper
{
    class KeyDoor
    {
        // Variables
        private Sprite doorSprite;
        private Texture2D keyTexture;
        public bool DoorOpen = false;

        public List<Sprite> Keys = new List<Sprite>();

        // Door position
        public Vector2 DoorPosition
        {
            get { return doorSprite.Position; }
            set { doorSprite.Position = value; }
        }

        // Door rectangle
        public Rectangle DoorRectangle
        {
            get { return doorSprite.Rectangle; }
        }

        // Constructor
        public KeyDoor(Texture2D doorTexture, Rectangle doorInitialFrame, Texture2D keyTexture)
        {
            this.keyTexture = keyTexture;
            // Create sprite of door
            doorSprite = new Sprite(Vector2.Zero, doorTexture, doorInitialFrame);
            // Add second frame for when door is open
            doorSprite.AddFrame(new Rectangle(doorInitialFrame.Width, 0, doorInitialFrame.Width, doorInitialFrame.Height));
            // Disable animation so door does not open and close continuously
            doorSprite.Animate = false;
        }

        // Function for spawning keys
        public void SpawnKey(Vector2 position)
        {
            Sprite key = new Sprite(position, keyTexture, new Rectangle(0, 0, keyTexture.Width, keyTexture.Height));
            Keys.Add(key);
        }

        // Function for removing (picking up) a key
        public void PickUpKey(Sprite key)
        {
            Keys.Remove(key);

            SoundManager.PickUp.Play();

            // Check if all keys have been taken and if so open door
            if (Keys.Count == 0)
                OpenDoor();
        }

        // Function for removing all keys
        public void Reset()
        {
            Keys.Clear();
            // Close door
            doorSprite.Frame = 0;
            DoorOpen = false;
        }

        // Function for opening door
        public void OpenDoor()
        {
            doorSprite.Frame = 1;
            DoorOpen = true;
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Sprite key in Keys)
            {
                key.Draw(spriteBatch);
            }
            doorSprite.Draw(spriteBatch);
        }
    }
}
