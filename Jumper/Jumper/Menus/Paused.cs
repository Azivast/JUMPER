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
    static class Paused
    {
        private static ButtonManager buttons;
        private static SpriteFont font;

        // Load all tiles for level
        public static void LoadContent(SpriteFont font)
        {
            Paused.font = font;

            // Set up buttons
            buttons = new ButtonManager(new Vector2(400, 220), font);
            buttons.textColor = Color.White;

            buttons.AddButton("CONTINUE");
            buttons.AddButton("RESTART LEVEL");
            buttons.AddButton("MAIN MENU");
            buttons.AddButton("EXIT");
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

                // Reset volume
                SoundManager.MusicInstance.Volume = 1;

                switch (buttons.SelectedButton)
                {
                    case 0:
                        Game1.gameState = Game1.GameState.Playing;
                        break;
                    case 1:
                        // Go back one level (On all chapters since current chapter cant be determined)
                        Game1.C1Level--;
                        Game1.C2Level--;
                        // Change to playing
                        Game1.gameState = Game1.GameState.Playing;
                        break;
                    case 2:
                        Game1.gameState = Game1.GameState.MainMenu;
                        break;
                    case 3:
                        Game1.self.Exit();
                        break;
                }
            }
        }


        // Draw
        public static void Draw(SpriteBatch spriteBatch)
        {
            buttons.Draw(spriteBatch);
            spriteBatch.DrawString(font, "", new Vector2(540, 455), Color.White);
        }
    }
}
