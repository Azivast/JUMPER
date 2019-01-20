using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jumper
{
    class ButtonManager
    {
        private Sprite buttonSprite;
        //public List<Sprite> Buttons = new List<Sprite>();
        public List<string> Buttons = new List<string>();
        private Texture2D texture;
        private Vector2 centerPosition;
        private Rectangle initialFrame;
        private int frameCount;
        private SpriteFont font;
        public int buttonMargin = 40;
        public Color textColor = new Color(36, 36, 36);

        public int SelectedButton = 0;


        // Constructor
        public ButtonManager(
            //Texture2D texture, 
            Vector2 centerPosition,
            //Rectangle initialFrame, 
            //int frameCount, 
            SpriteFont font)
        {
            //this.texture = texture;
            this.centerPosition = centerPosition;
            //this.initialFrame = initialFrame;
            //this.frameCount = frameCount;
            this.font = font;


        }

        public void NextButton()
        {
            if (SelectedButton < Buttons.Count - 1)
            {
                SelectedButton++;
                SoundManager.Select.Play();
            }
            else if (SelectedButton == Buttons.Count - 1)
            {
                SelectedButton = 0;
                SoundManager.Select.Play();
            }
        }

        public void PrevButton()
        {
            if (SelectedButton > 0)
            {
                SelectedButton--;
                SoundManager.Select.Play();
            }
            else if (SelectedButton == 0)
            {
                SelectedButton = Buttons.Count - 1;
                SoundManager.Select.Play();
            }
        }

        // Function for adding buttons
        public void AddButton(string text)
        {
            //Sprite button = new Sprite(centerPosition, texture, initialFrame);

            //// Create the frames for the button.
            //for (int i = 1; i < frameCount; i++)
            //{
            //    buttonSprite.AddFrame(new Rectangle(initialFrame.X = (initialFrame.Width * i), initialFrame.Y, initialFrame.Width, initialFrame.Height));
            //}
            //// Disable animations
            //button.Animate = false;

            //Buttons.Add(button);
            Buttons.Add(text);
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = Buttons.Count - 1; i >= 0; i--)
            {
                // String size
                Vector2 textSize = font.MeasureString(Buttons[i]);
                // Position of text centered on centerPosition
                Vector2 textPos = new Vector2(centerPosition.X - (textSize.X / 2), centerPosition.Y - (textSize.Y / 2) + (buttonMargin * i));

                if (i == SelectedButton)
                {
                    // Move text shadows a random amount of each draw
                    Random rand = new Random();
                    Vector2 bluePos;
                    bluePos.X = rand.Next((int)textPos.X - 2, (int)textPos.X );
                    bluePos.Y = rand.Next((int)textPos.Y - 2, (int)textPos.Y );
                    Vector2 redPos;
                    redPos.X = rand.Next((int)textPos.X + 1, (int)textPos.X + 3);
                    redPos.Y = rand.Next((int)textPos.Y + 1, (int)textPos.Y + 3);

                    //Buttons[i].Draw(spriteBatch);
                    spriteBatch.DrawString(font, Buttons[i], bluePos, new Color(34, 190, 171, 220));
                    spriteBatch.DrawString(font, Buttons[i], redPos, new Color(255, 33, 33, 200));
                    spriteBatch.DrawString(font, Buttons[i], textPos, textColor);
                }
                else
                {
                    //Buttons[i].Draw(spriteBatch);
                    spriteBatch.DrawString(font, Buttons[i], textPos, textColor);
                }
            }
        }
    }
}
