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
    static class ChapterSelect
    {
        public static List<Texture2D> Chapters = new List<Texture2D>();
        private static SpriteFont font;
        private static int SelectedChapter = 0;

        // Load all tiles for level
        public static void LoadContent(ContentManager Content, SpriteFont font)
        {
            ChapterSelect.font = font;

            Chapters.Add(Content.Load<Texture2D>(@"Chapter icons/Chapter1Icon"));
            Chapters.Add(Content.Load<Texture2D>(@"Chapter icons/Chapter2Icon"));

            // Set up buttons
            //buttons = new ButtonManager(new Vector2(400, 410), font);
            //buttons.AddButton("BACK");
        }

        // Update
        public static void Update(GameTime gameTime)
        {
            if (InputManager.IsTapped(Keys.Escape))
            {
                Game1.gameState = Game1.GameState.MainMenu;
            }
            if (InputManager.IsTapped(Keys.Left))
            {
                Previous();
            }
            else if (InputManager.IsTapped(Keys.Right))
            {
                Next();
            }

            if (InputManager.IsTapped(Keys.Enter))
            {
                SoundManager.Select.Play();
                switch (SelectedChapter)
                {
                    case 0:
                        Game1.gameState = Game1.GameState.Playing;
                        Game1.Chapter = Game1.Chapters.Chapter1;
                        Game1.C1Level = Game1.Chapter1.PreLevel1;
                        break;
                    case 1:
                        Game1.gameState = Game1.GameState.Playing;
                        Game1.Chapter = Game1.Chapters.Chapter2;
                        Game1.C2Level = Game1.Chapter2.PreLevel1;
                        break;
                }
            }
        }

        private static void Next()
        {
            if (SelectedChapter < Chapters.Count - 1)
            {
                SelectedChapter++;
                SoundManager.Select.Play();
            }
        }

        private static void Previous()
        {
            if (SelectedChapter > 0)
            {
                SelectedChapter--;
                SoundManager.Select.Play();
            }
        }


        // Draw
        public static void Draw(SpriteBatch spriteBatch)
        {
            for (int i = Chapters.Count - 1; i >= 0; i--)
            {
                if (i == SelectedChapter)
                {
                    spriteBatch.Draw(Chapters[i], new Rectangle(10 + 150 * i, 10, Chapters[i].Width, Chapters[i].Height), Color.White);
                }
                else
                {
                    spriteBatch.Draw(Chapters[i], new Rectangle(10 + 150 * i, 10, Chapters[i].Width, Chapters[i].Height), new Color(100, 100 ,100));
                }

                spriteBatch.DrawString(font, "Chapter " + (i+1).ToString(), new Vector2(0 + 150 * i, 90), new Color(36, 36, 36));
            }
        }
    }
}
