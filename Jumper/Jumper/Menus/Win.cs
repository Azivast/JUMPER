using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jumper
{
    static class Win
    {
        private static ButtonManager buttons;
        private static SpriteFont font;
        private static SpriteFont fontLarge;
        private static Vector2 titlePosition = new Vector2(400, 100);
        private static String chapterUnlockedString = "";
        private static Vector2 chapterUnlockedStringPosition = new Vector2(400, 140);

        // Load all tiles for level
        public static void LoadContent(SpriteFont font, SpriteFont fontLarge)
        {
            Win.font = font;
            Win.fontLarge = fontLarge;

            // Set up buttons
            buttons = new ButtonManager(new Vector2(400, 350), font);

            buttons.AddButton("MAIN MENU");
            buttons.AddButton("EXIT");

            // Calculate and save centered position of title
            Vector2 titleSize = fontLarge.MeasureString("CHAPTER COMPLETED");
            Vector2 titleCenteredPosition = new Vector2(titlePosition.X - (titleSize.X / 2), titlePosition.Y - (titleSize.Y / 2));
            titlePosition = titleCenteredPosition;

            // Calculate and save centered position of "chapter unlocked" text
            Vector2 chapSize = font.MeasureString("CHAPTER X UNLOCKED!");
            Vector2 chapCenteredPosition = new Vector2(chapterUnlockedStringPosition.X - (chapSize.X / 2), chapterUnlockedStringPosition.Y - (chapSize.Y / 2));
            chapterUnlockedStringPosition = chapCenteredPosition;
        }

        // Update
        public static void Update(GameTime gameTime)
        {
            if (InputManager.IsTapped(Keys.Down))
            {
                buttons.NextButton();
            }
            else if (InputManager.IsTapped(Keys.Up))
            {
                buttons.PrevButton();
            }

            if (InputManager.IsTapped(Keys.Enter))
            {
                SoundManager.Select.Play();
                switch (buttons.SelectedButton)
                {
                    case 0:
                        // Reset music pitch
                        SoundManager.MusicInstance.Pitch = 0;

                        Game1.gameState = Game1.GameState.MainMenu;
                        break;
                    case 1:
                        Game1.self.Exit();
                        break;
                }
            }

            // Unlock next chapter and update the text accordingly
            if (Game1.Chapter == Game1.Chapters.Chapter1)
            {
                if (Game1.Chapter2Unlocked == false)
                {
                    Game1.Chapter2Unlocked = true;
                    chapterUnlockedString = "CHAPTER 2 UNLOCKED!";
                }
            }
            else if (Game1.Chapter == Game1.Chapters.Chapter2)
            {
                if (Game1.Chapter3Unlocked == false)
                {
                    Game1.Chapter3Unlocked = true;
                    chapterUnlockedString = "CHAPTER 3 UNLOCKED!";
                }
            }
        }


        // Draw
        public static void Draw(SpriteBatch spriteBatch)
        {
            buttons.Draw(spriteBatch);

            // Draw title
            spriteBatch.DrawString(fontLarge, "CHAPTER COMPLETED", titlePosition - new Vector2(+2, +2), new Color(34, 190, 171, 220));
            spriteBatch.DrawString(fontLarge, "CHAPTER COMPLETED", titlePosition - new Vector2(-2, -2), new Color(255, 33, 33, 200));
            spriteBatch.DrawString(fontLarge, "CHAPTER COMPLETED", titlePosition, new Color(36, 36, 36));

            // Draw chapter unlocked text
            spriteBatch.DrawString(font, chapterUnlockedString, chapterUnlockedStringPosition, new Color(36, 36, 36));
        }
    }
}
