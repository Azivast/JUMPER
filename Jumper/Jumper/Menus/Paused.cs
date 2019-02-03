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
        private static SpriteFont fontLarge;
        private static Vector2 titlePosition = new Vector2(400, 130);
        private static PlayerManager player;

        // Load all tiles for level
        public static void LoadContent(SpriteFont font, SpriteFont fontLarge, PlayerManager player)
        {
            Paused.font = font;
            Paused.fontLarge = fontLarge;
            Paused.player = player;

            // Set up buttons
            buttons = new ButtonManager(new Vector2(400, 200), font);
            buttons.textColor = Color.White;

            buttons.AddButton("CONTINUE");
            buttons.AddButton("RESTART LEVEL");
            buttons.AddButton("MAIN MENU");
            buttons.AddButton("EXIT");

            // Calculate and save centered position of title
            Vector2 titleSize = fontLarge.MeasureString("PAUSED");
            Vector2 titleCenteredPosition = new Vector2(titlePosition.X - (titleSize.X / 2), titlePosition.Y - (titleSize.Y / 2));
            titlePosition = titleCenteredPosition;
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
                        // Kill the player to restart level
                        player.KillPlayer();

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

            // Draw title
            spriteBatch.DrawString(fontLarge, "PAUSED", titlePosition - new Vector2(+2, +2), new Color(34, 190, 171, 220));
            spriteBatch.DrawString(fontLarge, "PAUSED", titlePosition - new Vector2(-2, -2), new Color(255, 33, 33, 200));
            spriteBatch.DrawString(fontLarge, "PAUSED", titlePosition, Color.White);
        }
    }
}
