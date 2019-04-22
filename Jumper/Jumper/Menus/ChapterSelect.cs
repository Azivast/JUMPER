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
        private static Texture2D locked;
        private static Texture2D disabled;
        private static SpriteFont font;
        private static SpriteFont fontLarge;
        private static Vector2 titlePosition = new Vector2(400, 80);
        private static Vector2 iconPosition = new Vector2(210, 190);
        private static int SelectedChapter = 0;

        // Load all tiles for level
        public static void LoadContent(ContentManager Content, SpriteFont font, SpriteFont fontLarge)
        {
            ChapterSelect.font = font;
            ChapterSelect.fontLarge = fontLarge;

            Chapters.Add(Content.Load<Texture2D>(@"Chapter icons/Chapter1Icon"));
            Chapters.Add(Content.Load<Texture2D>(@"Chapter icons/Chapter2Icon"));
            Chapters.Add(Content.Load<Texture2D>(@"Chapter icons/Chapter3Icon"));

            // Load icon for locked chapters
            locked = Content.Load<Texture2D>(@"Chapter icons/lock");
            disabled = Content.Load<Texture2D>(@"Chapter icons/demo text");

            // Set up buttons
            //buttons = new ButtonManager(new Vector2(400, 410), font);
            //buttons.AddButton("BACK");

            // Calculate and save centered position of title
            Vector2 titleSize = fontLarge.MeasureString("CHOOSE CHAPTER");
            Vector2 titleCenteredPosition = new Vector2(titlePosition.X - (titleSize.X / 2), titlePosition.Y - (titleSize.Y / 2));
            titlePosition = titleCenteredPosition;
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
                switch (SelectedChapter)
                {
                    case 0:
                        SoundManager.Select.Play();
                        Game1.gameState = Game1.GameState.Playing;
                        Game1.Chapter = Game1.Chapters.Chapter1;
                        Game1.C1Level = Game1.Chapter1.PreLevel1;
                        break;
                    case 1:
                        if (Game1.Chapter2Unlocked)
                        {
                            SoundManager.Select.Play();
                            Game1.gameState = Game1.GameState.Playing;
                            Game1.Chapter = Game1.Chapters.Chapter2;
                            Game1.C2Level = Game1.Chapter2.PreLevel1;
                        }
                        else SoundManager.Unavailable.Play();
                        break;
                    case 2:
                        if (Game1.Chapter3Unlocked)
                        {
                            //SoundManager.Select.Play();
                            //Game1.gameState = Game1.GameState.Playing;
                            //Game1.Chapter = Game1.Chapters.Chapter2;
                            //Game1.C2Level = Game1.Chapter2.PreLevel1;
                        }
                        else SoundManager.Unavailable.Play();
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
            // Draw title
            spriteBatch.DrawString(fontLarge, "CHOOSE CHAPTER", titlePosition - new Vector2(+2, +2), new Color(34, 190, 171, 220));
            spriteBatch.DrawString(fontLarge, "CHOOSE CHAPTER", titlePosition - new Vector2(-2, -2), new Color(255, 33, 33, 150));
            spriteBatch.DrawString(fontLarge, "CHOOSE CHAPTER", titlePosition, new Color(36, 36, 36));

            for (int i = Chapters.Count - 1; i >= 0; i--)
            {
                if (i == SelectedChapter)
                {
                    spriteBatch.Draw(Chapters[i], new Rectangle((int)iconPosition.X + 150 * i, (int)iconPosition.Y, Chapters[i].Width, Chapters[i].Height), Color.White);
                    spriteBatch.DrawString(font, "Chapter " + (i + 1).ToString(), new Vector2((int)iconPosition.X - 15 + 150 * i, (int)iconPosition.Y + 90), new Color(36, 36, 36));

                    // Draw lock if locked
                    if (i == 1 && !Game1.Chapter2Unlocked)
                    {
                        spriteBatch.Draw(locked, new Rectangle((int)iconPosition.X + 150 * i, (int)iconPosition.Y, Chapters[i].Width, Chapters[i].Height), Color.White);
                    }
                    if (i == 2)
                    {
                        if (!Game1.Chapter3Unlocked)
                            spriteBatch.Draw(locked, new Rectangle((int)iconPosition.X + 150 * i, (int)iconPosition.Y, Chapters[i].Width, Chapters[i].Height), Color.White);
                        spriteBatch.Draw(disabled, new Rectangle((int)iconPosition.X + 150 * i, (int)iconPosition.Y, Chapters[i].Width, Chapters[i].Height), Color.White);
                    }
                }
                else
                {
                    spriteBatch.Draw(Chapters[i], new Rectangle((int)iconPosition.X + 150 * i, (int)iconPosition.Y, Chapters[i].Width, Chapters[i].Height), new Color(100, 100 ,100));
                    spriteBatch.DrawString(font, "Chapter " + (i + 1).ToString(), new Vector2((int)iconPosition.X - 15 + 150 * i, (int)iconPosition.Y + 90), new Color(36, 36, 36));

                    // Draw lock if locked
                    if (i == 1 && !Game1.Chapter2Unlocked)
                    {
                        spriteBatch.Draw(locked, new Rectangle((int)iconPosition.X + 150 * i, (int)iconPosition.Y, Chapters[i].Width, Chapters[i].Height), new Color(100, 100, 100));
                    }
                    if (i == 2)
                    {
                        if (!Game1.Chapter3Unlocked)
                            spriteBatch.Draw(locked, new Rectangle((int)iconPosition.X + 150 * i, (int)iconPosition.Y, Chapters[i].Width, Chapters[i].Height), new Color(36, 36, 36));
                        spriteBatch.Draw(disabled, new Rectangle((int)iconPosition.X + 150 * i, (int)iconPosition.Y, Chapters[i].Width, Chapters[i].Height), Color.White);
                    }
                }

            }
        }
    }
}
