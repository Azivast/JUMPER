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
    static class Options
    {
        private static ButtonManager buttons;
        private static SpriteFont font;

        // Load all tiles for level
        public static void LoadContent(SpriteFont font)
        {
            Options.font = font;

            // Set up buttons
            buttons = new ButtonManager(new Vector2(400, 240), font);

            buttons.AddButton("TOGGLE FULLSCREEN");
            buttons.AddButton("TOGGLE SOUND");
            buttons.AddButton("TOGGLE MUSIC");
            buttons.AddButton("BACK");
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
                        Game1.graphics.IsFullScreen = !Game1.graphics.IsFullScreen;
                        Game1.graphics.ApplyChanges();
                        break;
                    case 1:
                        SoundManager.ToggleSound();
                        break;
                    case 2:
                        SoundManager.ToggleMusic();
                        break;

                    case 3:
                        Game1.gameState = Game1.GameState.MainMenu;
                        break;
                }
            }
        }


        // Draw
        public static void Draw(SpriteBatch spriteBatch)
        {
            buttons.Draw(spriteBatch);
        }
    }
}
