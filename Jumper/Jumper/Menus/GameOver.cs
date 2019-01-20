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
    static class GameOver
    {
        private static ButtonManager buttons;
        private static SpriteFont font;

        // Load all tiles for level
        public static void LoadContent(SpriteFont font)
        {
            GameOver.font = font;

            // Set up buttons
            buttons = new ButtonManager(new Vector2(400, 350), font);
            buttons.textColor = Color.White;

            buttons.AddButton("MAIN MENU");
            buttons.AddButton("EXIT");
        }

        // Update
        public static void Update(GameTime gameTime)
        {
            // Slow down music
            SoundManager.MusicInstance.Pitch = -1F;

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
        }


        // Draw
        public static void Draw(SpriteBatch spriteBatch)
        {
            buttons.Draw(spriteBatch);
            spriteBatch.DrawString(font, "", new Vector2(540, 455), Color.White);
        }
    }
}
