using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jumper
{
    static class Credits
    {
        private static ButtonManager buttons;
        private static List<string> Texts = new List<string>();
        private static SpriteFont font;
        private static Vector2 centerPosition = new Vector2(400, 50);
        private static int textMargin = 20;

        // Load all tiles for level
        public static void LoadContent(SpriteFont font)
        {
            Credits.font = font;

            // Set up buttons
            buttons = new ButtonManager(new Vector2(400, 410), font);
            buttons.AddButton("BACK");

            // Text to be shown
            Texts.Add("CREDITS");
            Texts.Add("");
            Texts.Add("PROGRAMMED BY:");
            Texts.Add("OLLE ASTR}");
            Texts.Add("");
            Texts.Add("GRAPHICS BY:");
            Texts.Add("OLLE ASTR}");
            Texts.Add("");
            Texts.Add("SFX BY:");
            Texts.Add("OLLE ASTR}");
            Texts.Add("");
            Texts.Add("MUSIC BY:");
            Texts.Add("OZZED");
            Texts.Add("(ozzed.net, LICENSED UNDER CC BY-SA 3.0)");
            Texts.Add("");
            Texts.Add("SPECIAL THANKS:");
            Texts.Add("LBS TROLLH{TTAN");
        }

        // Update
        public static void Update(GameTime gameTime)
        {
            if (InputManager.IsTapped(Keys.Enter))
            {
                SoundManager.Select.Play();
                Game1.gameState = Game1.GameState.MainMenu;
            }
        }


        // Draw
        public static void Draw(SpriteBatch spriteBatch)
        {
            buttons.Draw(spriteBatch);

            for (int i = 0; i < Texts.Count; i++)
            {
                // String size
                Vector2 textSize = font.MeasureString(Texts[i]);
                // Position of text centered on centerPosition
                Vector2 textPos = new Vector2(centerPosition.X - (textSize.X / 2), centerPosition.Y - (textSize.Y / 2) + (textMargin * i));

                // Move text shadows a random amount of each draw
                Vector2 bluePos = new Vector2(textPos.X - 2, textPos.Y - 2);
                Vector2 redPos = new Vector2(textPos.X + 2, textPos.Y + 2);
                //spriteBatch.DrawString(font, Texts[i], bluePos, new Color(34, 190, 171, 220));
                //spriteBatch.DrawString(font, Texts[i], redPos, new Color(255, 33, 33, 200));
                spriteBatch.DrawString(font, Texts[i], textPos, new Color(36, 36, 36));
            }
        }
    }
}
