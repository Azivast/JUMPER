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
    static class MainMenu
    {
        private static ButtonManager buttons;
        private static SpriteFont font;

        // Load all tiles for level
        public static void LoadContent(SpriteFont font)
        {
            MainMenu.font = font;

            // Set up buttons
            buttons = new ButtonManager(new Vector2(400, 240), font);

            buttons.AddButton("PLAY");
            buttons.AddButton("CREDITS");
            buttons.AddButton("OPTIONS");
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
                switch (buttons.SelectedButton)
                {
                    case 0:
                        Game1.gameState = Game1.GameState.ChapterSelect;
                        break;
                    case 1:
                        Game1.gameState = Game1.GameState.Credits;
                        break;
                    case 2:
                        Game1.gameState = Game1.GameState.Options;
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

            // new Vector2(655, 455) <- Cords for 2 digit version number
            spriteBatch.DrawString(font, "VERSION " + Game1.VersionNumber, new Vector2(540, 455), new Color(36, 36, 36));
        }
    }
}
