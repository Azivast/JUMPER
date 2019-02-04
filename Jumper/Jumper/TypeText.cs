using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jumper
{
    class TypeText
    {
        private SpriteFont font;

        private string text;
        private string typedCharacters = "";

        private int typeSpeed;
        private int typeTimer = 0;
        private int typePauseLength = 10;

        private int currentChar;
        private Vector2 position;

        private bool showText = false;

        public TypeText(string text,int typeSpeed, Vector2 position, SpriteFont font)
        {
            this.text = text;
            this.typeSpeed = typeSpeed;
            this.font = font;
            this.position = position;
        }

        // Function for starting the typing
        public void ShowText()
        {
            showText = true;
        }

        // Type next character
        public void TypeCharacter()
        {
            typedCharacters += text[currentChar];
            SoundManager.Text.Play();

            // Check if end of sentence and if so make a pause
            if (text[currentChar] == '.')
                typeTimer = -typePauseLength;

            currentChar++;
        }

        // Update
        public void Update(GameTime gameTime)
        {
            // Check if text should be shown and if so type it out
            if (showText &&
                typeTimer >= typeSpeed &&
                typedCharacters.Length < text.Length)
            {
                // Reset timer
                typeTimer = 0;

                // Add a character
                TypeCharacter();
            }
            typeTimer++;
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {
                spriteBatch.DrawString(font, typedCharacters, position, Color.Gray);
        }
    }
}
