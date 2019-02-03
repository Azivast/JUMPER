using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jumper
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        // Version Number of Game
        public static string VersionNumber = "pre-2.0 Indev";

        public static GraphicsDeviceManager graphics;

        SpriteBatch spriteBatch;

        // Used to acces this.Exit() from other classes
        public static Game1 self;

        private PlayerManager player;
        private Sprite playerSprite;
        private EnemyManager enemyManager;
        private BreakableManager breakableManager;
        private CollisionManager collisionManager;
        private SpikeManager spikeManager;
        private KeyDoor keyDoor;
        private HeartManager heartManager;

        // Textures for backgrounds, menus etc
        private Texture2D bgLevel;
        private Texture2D bgMenu;
        private Texture2D bgMainMenu;
        private Texture2D bgWin;
        private Texture2D bgGameOver;
        private Texture2D crtOverlay;
        private Texture2D pausedOverlay;

        // Fonts
        private SpriteFont kongtextFont10;
        private SpriteFont kongtextFont18;


        // Which game state to start in
        public static GameState gameState = GameState.MainMenu;

        // Which chapter state to start in
        public static Chapters Chapter = Chapters.Chapter1;

        // Which level state to start in
        public static Chapter1 C1Level = Chapter1.PreLevel1;

        // Which level state to start in
        public static Chapter1 C2Level;

        // The different game states
        public enum GameState
        {
            MainMenu,
            Credits,
            Options,
            Playing,
            Paused,
            Win,
            GameOver
        };

        public enum Chapters
        {
            Chapter1,
            Chapter2
        };

        public enum Chapter1
        {
            PreLevel1,
            Level1,
            PreLevel2,
            Level2,
            PreLevel3,
            Level3,
            PreLevel4,
            Level4,
            PreLevel5,
            Level5,
            PreLevel6,
            Level6,
            PreLevel7,
            Level7,
            PreLevel8,
            Level8,
            PreLevel9,
            Level9,
            PreLevel10,
            Level10,
            PreLevelTest,
            LevelTest
        };

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            self = this;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Set windows name
            Window.Title = "./JUMPER/";

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            playerSprite = new Sprite(Vector2.Zero, Content.Load<Texture2D>(@"Sprites/Player"),
                new Rectangle(0, 0, 14, 25));
            // Add frames to playerSprite
            for (int i = 0; i < 8; i++)
            {
                playerSprite.AddFrame(new Rectangle((14 * i), 0, 14, 25));
            }

            player = new PlayerManager(playerSprite);
            enemyManager = new EnemyManager(Content.Load<Texture2D>(@"Sprites/Enemy"), new Rectangle(0, 0, 25, 25), 0);
            breakableManager = new BreakableManager(Content.Load<Texture2D>(@"Sprites/Breakable"),
                new Rectangle(0, 0, 25, 25), 0);
            spikeManager = new SpikeManager(Content.Load<Texture2D>(@"Sprites/Spike"), new Rectangle(0, 0, 25, 25), 0);
            keyDoor = new KeyDoor(Content.Load<Texture2D>(@"Sprites/Door"), new Rectangle(0, 0, 25, 36),
                Content.Load<Texture2D>(@"Sprites/Key"));
            heartManager = new HeartManager(player, Content.Load<Texture2D>(@"Sprites/Heart"),
                new Rectangle(0, 0, 11, 11), 0);
            collisionManager = new CollisionManager(player, enemyManager, breakableManager, spikeManager, keyDoor,
                heartManager);

            // Load content for each level
            Level1.LoadContent(Content, GraphicsDevice);
            Level2.LoadContent(Content, GraphicsDevice);
            Level3.LoadContent(Content, GraphicsDevice);
            Level4.LoadContent(Content, GraphicsDevice);
            Level5.LoadContent(Content, GraphicsDevice);
            Level6.LoadContent(Content, GraphicsDevice);
            Level7.LoadContent(Content, GraphicsDevice);
            Level8.LoadContent(Content, GraphicsDevice);
            //Level9.LoadContent(Content, GraphicsDevice);
            //Level10.LoadContent(Content, GraphicsDevice);
            LevelTest.LoadContent(Content, GraphicsDevice);

            // Load backgrounds
            bgLevel = Content.Load<Texture2D>(@"Backgrounds/levelbg");
            bgMenu = Content.Load<Texture2D>(@"Backgrounds/Menus");
            bgMainMenu = Content.Load<Texture2D>(@"Backgrounds/Menu bg");
            bgWin = Content.Load<Texture2D>(@"Backgrounds/Win");
            bgGameOver = Content.Load<Texture2D>(@"Backgrounds/Game over");
            crtOverlay = Content.Load<Texture2D>(@"Backgrounds/CRT overlay");
            pausedOverlay = Content.Load<Texture2D>(@"Backgrounds/Paused overlay");

            // Font
            kongtextFont10 = Content.Load<SpriteFont>(@"Fonts\kongtext");
            kongtextFont18 = Content.Load<SpriteFont>(@"Fonts\kongtext18");

            // Load contents in soundManager
            SoundManager.LoadContent(Content, GraphicsDevice);


            // Load Menus
            MainMenu.LoadContent(kongtextFont10);
            Credits.LoadContent(kongtextFont10, kongtextFont18);
            Options.LoadContent(kongtextFont10, kongtextFont18);
            GameOver.LoadContent(kongtextFont10);
            Paused.LoadContent(kongtextFont10, kongtextFont18, player);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Update input manager
            InputManager.Update(gameTime);

            //// Allows the game to return to menu
            //if (InputManager.IsTapped(Keys.Escape))
            //    gameState = GameState.MainMenu;

            //!!DEBUG CHANGE BEFORE RELEASE!!
            // Warp keys
            //if (InputManager.IsTapped(Keys.NumPad1))
            //    C1Level = Chapter1.PreLevel1;
            //if (InputManager.IsTapped(Keys.NumPad2))
            //    C1Level = Chapter1.PreLevel2;
            //if (InputManager.IsTapped(Keys.NumPad3))
            //    C1Level = Chapter1.PreLevel3;
            //if (InputManager.IsTapped(Keys.NumPad4))
            //    C1Level = Chapter1.PreLevel4;
            //if (InputManager.IsTapped(Keys.NumPad5))
            //    C1Level = Chapter1.PreLevel5;
            //if (InputManager.IsTapped(Keys.OemMinus))
            //    gameState = GameState.GameOver;
            //if (InputManager.IsTapped(Keys.NumPad6))
            //    C1Level = Chapter1.PreLevel6;
            //if (InputManager.IsTapped(Keys.NumPad7))
            //    C1Level = Chapter1.PreLevel7;
            //if (InputManager.IsTapped(Keys.NumPad8))
            //    C1Level = Chapter1.PreLevel8;
            //if (InputManager.IsTapped(Keys.NumPad0))
            //    C1Level = Chapter1.PreLevelTest;

            // Gamestate specific code
            switch (gameState)
            {
                case GameState.MainMenu:
                    MainMenu.Update(gameTime);
                    break;

                case GameState.Credits:
                    Credits.Update(gameTime);
                    break;

                case GameState.Options:
                    Options.Update(gameTime);
                    break;

                case GameState.Playing:
                    switch (Chapter)
                    {
                        // CHAPTER 1
                        case Chapters.Chapter1:
                            switch (C1Level)
                            {
                                case Chapter1.PreLevel1:
                                    // Reset player (Only run before level 1)
                                    player.Reset();
                                    // Reset classes from previous levels
                                    enemyManager.Reset();
                                    breakableManager.Reset();
                                    keyDoor.Reset();
                                    spikeManager.Reset();
                                    heartManager.Reset();

                                    player.LevelTimeLeft = Level1.LevelTime;
                                    Level1.PositionPlayer(player);
                                    Level1.SpawnDoorAndKeys(keyDoor);
                                    Level1.SpawnBreakables(breakableManager);
                                    Level1.SpawnEnemies(enemyManager);
                                    Level1.SpawnSpikes(spikeManager);
                                    Level1.SpawnHearts(heartManager);
                                    // Move to next level
                                    C1Level++;
                                    break;
                                case Chapter1.Level1:
                                    collisionManager.Update(gameTime, Level1.tileManager, keyDoor, spikeManager);

                                    // Update the player
                                    player.Update(gameTime);

                                    enemyManager.Update(gameTime);
                                    breakableManager.Update(gameTime);
                                    break;

                                case Chapter1.PreLevel2:
                                    // Reset classes from previous levels
                                    enemyManager.Reset();
                                    breakableManager.Reset();
                                    keyDoor.Reset();
                                    spikeManager.Reset();
                                    heartManager.Reset();

                                    player.LevelTimeLeft = Level2.LevelTime;
                                    Level2.PositionPlayer(player);
                                    Level2.SpawnDoorAndKeys(keyDoor);
                                    Level2.SpawnBreakables(breakableManager);
                                    Level2.SpawnEnemies(enemyManager);
                                    Level2.SpawnSpikes(spikeManager);
                                    Level2.SpawnHearts(heartManager);
                                    // Move to next level
                                    C1Level++;
                                    break;
                                case Chapter1.Level2:
                                    collisionManager.Update(gameTime, Level2.tileManager, keyDoor, spikeManager);

                                    // Update the player
                                    player.Update(gameTime);

                                    enemyManager.Update(gameTime);
                                    breakableManager.Update(gameTime);
                                    break;

                                case Chapter1.PreLevel3:
                                    // Reset classes from previous levels
                                    enemyManager.Reset();
                                    breakableManager.Reset();
                                    keyDoor.Reset();
                                    spikeManager.Reset();
                                    heartManager.Reset();

                                    player.LevelTimeLeft = Level3.LevelTime;
                                    Level3.PositionPlayer(player);
                                    Level3.SpawnDoorAndKeys(keyDoor);
                                    Level3.SpawnBreakables(breakableManager);
                                    Level3.SpawnEnemies(enemyManager);
                                    Level3.SpawnSpikes(spikeManager);
                                    Level3.SpawnHearts(heartManager);
                                    // Move to next level
                                    C1Level++;
                                    break;
                                case Chapter1.Level3:
                                    collisionManager.Update(gameTime, Level3.tileManager, keyDoor, spikeManager);

                                    // Update the player
                                    player.Update(gameTime);

                                    enemyManager.Update(gameTime);
                                    breakableManager.Update(gameTime);
                                    break;

                                case Chapter1.PreLevel4:
                                    // Reset classes from previous levels
                                    enemyManager.Reset();
                                    breakableManager.Reset();
                                    keyDoor.Reset();
                                    spikeManager.Reset();
                                    heartManager.Reset();

                                    player.LevelTimeLeft = Level4.LevelTime;
                                    Level4.PositionPlayer(player);
                                    Level4.SpawnDoorAndKeys(keyDoor);
                                    Level4.SpawnBreakables(breakableManager);
                                    Level4.SpawnEnemies(enemyManager);
                                    Level4.SpawnSpikes(spikeManager);
                                    Level4.SpawnHearts(heartManager);
                                    // Move to next level
                                    C1Level++;
                                    break;
                                case Chapter1.Level4:
                                    collisionManager.Update(gameTime, Level4.tileManager, keyDoor, spikeManager);

                                    // Update the player
                                    player.Update(gameTime);

                                    enemyManager.Update(gameTime);
                                    breakableManager.Update(gameTime);
                                    break;

                                case Chapter1.PreLevel5:
                                    // Reset classes from previous levels
                                    enemyManager.Reset();
                                    breakableManager.Reset();
                                    keyDoor.Reset();
                                    spikeManager.Reset();
                                    heartManager.Reset();

                                    player.LevelTimeLeft = Level5.LevelTime;
                                    Level5.PositionPlayer(player);
                                    Level5.SpawnDoorAndKeys(keyDoor);
                                    Level5.SpawnBreakables(breakableManager);
                                    Level5.SpawnEnemies(enemyManager);
                                    Level5.SpawnSpikes(spikeManager);
                                    Level5.SpawnHearts(heartManager);
                                    // Move to next level
                                    C1Level++;
                                    break;
                                case Chapter1.Level5:
                                    collisionManager.Update(gameTime, Level5.tileManager, keyDoor, spikeManager);

                                    // Update the player
                                    player.Update(gameTime);

                                    enemyManager.Update(gameTime);
                                    breakableManager.Update(gameTime);
                                    break;

                                case Chapter1.PreLevel6:
                                    // Reset classes from previous levels
                                    enemyManager.Reset();
                                    breakableManager.Reset();
                                    keyDoor.Reset();
                                    spikeManager.Reset();
                                    heartManager.Reset();

                                    player.LevelTimeLeft = Level6.LevelTime;
                                    Level6.PositionPlayer(player);
                                    Level6.SpawnDoorAndKeys(keyDoor);
                                    Level6.SpawnBreakables(breakableManager);
                                    Level6.SpawnEnemies(enemyManager);
                                    Level6.SpawnSpikes(spikeManager);
                                    Level6.SpawnHearts(heartManager);
                                    // Move to next level
                                    C1Level++;
                                    break;

                                case Chapter1.Level6:
                                    collisionManager.Update(gameTime, Level6.tileManager, keyDoor, spikeManager);

                                    // Update the player
                                    player.Update(gameTime);

                                    enemyManager.Update(gameTime);
                                    breakableManager.Update(gameTime);
                                    break;

                                case Chapter1.PreLevel7:
                                    // Reset classes from previous levels
                                    enemyManager.Reset();
                                    breakableManager.Reset();
                                    keyDoor.Reset();
                                    spikeManager.Reset();
                                    heartManager.Reset();

                                    player.LevelTimeLeft = Level7.LevelTime;
                                    Level7.PositionPlayer(player);
                                    Level7.SpawnDoorAndKeys(keyDoor);
                                    Level7.SpawnBreakables(breakableManager);
                                    Level7.SpawnEnemies(enemyManager);
                                    Level7.SpawnSpikes(spikeManager);
                                    Level7.SpawnHearts(heartManager);
                                    // Move to next level
                                    C1Level++;
                                    break;

                                case Chapter1.Level7:
                                    collisionManager.Update(gameTime, Level7.tileManager, keyDoor, spikeManager);

                                    // Update the player
                                    player.Update(gameTime);

                                    enemyManager.Update(gameTime);
                                    breakableManager.Update(gameTime);
                                    break;

                                case Chapter1.PreLevel8:
                                    // Reset classes from previous levels
                                    enemyManager.Reset();
                                    breakableManager.Reset();
                                    keyDoor.Reset();
                                    spikeManager.Reset();
                                    heartManager.Reset();

                                    player.LevelTimeLeft = Level8.LevelTime;
                                    Level8.PositionPlayer(player);
                                    Level8.SpawnDoorAndKeys(keyDoor);
                                    Level8.SpawnBreakables(breakableManager);
                                    Level8.SpawnEnemies(enemyManager);
                                    Level8.SpawnSpikes(spikeManager);
                                    Level8.SpawnHearts(heartManager);
                                    // Move to next level
                                    C1Level++;
                                    break;

                                case Chapter1.Level8:
                                    collisionManager.Update(gameTime, Level8.tileManager, keyDoor, spikeManager);

                                    // Update the player
                                    player.Update(gameTime);

                                    enemyManager.Update(gameTime);
                                    breakableManager.Update(gameTime);
                                    break;

                                case Chapter1.PreLevelTest:
                                    // Reset classes from previous levels
                                    enemyManager.Reset();
                                    breakableManager.Reset();
                                    keyDoor.Reset();
                                    spikeManager.Reset();
                                    heartManager.Reset();

                                    player.LevelTimeLeft = LevelTest.LevelTime;
                                    LevelTest.PositionPlayer(player);
                                    LevelTest.SpawnDoorAndKeys(keyDoor);
                                    LevelTest.SpawnBreakables(breakableManager);
                                    LevelTest.SpawnEnemies(enemyManager);
                                    LevelTest.SpawnSpikes(spikeManager);
                                    LevelTest.SpawnHearts(heartManager);
                                    // Move to next level
                                    C1Level++;
                                    break;
                                case Chapter1.LevelTest:
                                    collisionManager.Update(gameTime, LevelTest.tileManager, keyDoor, spikeManager);

                                    // Update the player
                                    player.Update(gameTime);

                                    enemyManager.Update(gameTime);
                                    breakableManager.Update(gameTime);
                                    break;
                            }

                            break;
                    }

                    // Pause the game when ESC is pressed
                    if (InputManager.IsTapped(Keys.Escape))
                    {
                        // Lower music volume
                        SoundManager.MusicInstance.Volume = 0.3f;
                        // Play select sound
                        // Lower music volume
                        SoundManager.Select.Play();
                        // Move to gamestate Paused
                        gameState = GameState.Paused;
                    }


                    break;

                case GameState.Paused:
                    Paused.Update(gameTime);

                    if (InputManager.IsTapped(Keys.Escape))
                    {
                        // Reset volume
                        SoundManager.MusicInstance.Volume = 1;
                        // Play select sound
                        SoundManager.Select.Play();
                        // Move to gamestate Playing
                        gameState = GameState.Playing;
                    }
                    break;

                case GameState.Win:
                    break;

                case GameState.GameOver:
                    GameOver.Update(gameTime);
                    break;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // Set render target to "target" to allow resolution scaling.
            SpriteBatch targetBatch = new SpriteBatch(GraphicsDevice);
            RenderTarget2D target = new RenderTarget2D(GraphicsDevice, 800, 480);
            GraphicsDevice.SetRenderTarget(target);

            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();


            // Gamestate specific code
            switch (gameState)
            {
                case GameState.MainMenu:
                    spriteBatch.Draw(bgMainMenu, Vector2.Zero, Color.White);
                    MainMenu.Draw(spriteBatch);
                    break;

                case GameState.Credits:
                    spriteBatch.Draw(bgMenu, Vector2.Zero, Color.White);
                    Credits.Draw(spriteBatch);
                    break;

                case GameState.Options:
                    spriteBatch.Draw(bgMenu, Vector2.Zero, Color.White);
                    Options.Draw(spriteBatch);
                    break;

                case GameState.Playing:
                    // Draw background
                    spriteBatch.Draw(bgLevel, Vector2.Zero, Color.White);

                    // Draw the actual content
                    DrawGameStatePlaying(spriteBatch);
                    break;

                case GameState.Paused:
                    // Draw background
                    spriteBatch.Draw(bgLevel, Vector2.Zero, Color.White);

                    // Draw everything from "Playing"
                    DrawGameStatePlaying(spriteBatch);

                    // Draw overlay which dims the screen
                    spriteBatch.Draw(pausedOverlay, Vector2.Zero, Color.White);

                    // Draw menu
                    Paused.Draw(spriteBatch);
                    break;

                case GameState.Win:
                    spriteBatch.Draw(bgWin, Vector2.Zero, Color.White);
                    break;

                case GameState.GameOver:
                    spriteBatch.Draw(bgGameOver, Vector2.Zero, Color.White);
                    GameOver.Draw(spriteBatch);
                    break;
            }

            // Draw crt overlay
            spriteBatch.Draw(crtOverlay, Vector2.Zero, Color.White);
            spriteBatch.End();

            //set rendering back to the back buffer
            GraphicsDevice.SetRenderTarget(null);

            //render target to back buffer
            targetBatch.Begin();
            targetBatch.Draw(target, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height),
                Color.White);
            targetBatch.End();

            //base.Draw(gameTime);
        }

        // Function to center a text on a specific position
        public Vector2 CenterText(Vector2 position, string text)
        {
            Vector2 centered = position;
            Vector2 textSize = kongtextFont10.MeasureString(text);
            centered.X -= (textSize.X / 2);
            //centered.Y -= (textSize.Y / 2);

            return centered;
        }

        // Function for drawing the Gamestate "Playing". Seperated so it can be reused for drawing gamestate "Paused"
        private void DrawGameStatePlaying(SpriteBatch spriteBatch)
        {
            // Create a string of the level name
            string levelName = "Level: " + (((int)C1Level/2)+1);

            switch (C1Level)
            {
                case Chapter1.Level1:
                    // Draw managers, player etc
                    keyDoor.Draw(spriteBatch);
                    player.Draw(spriteBatch);
                    enemyManager.Draw(spriteBatch);
                    breakableManager.Draw(spriteBatch);
                    spikeManager.Draw(spriteBatch);
                    heartManager.Draw(spriteBatch);

                    // Draw all tiles for level
                    Level1.tileManager.Draw(spriteBatch);

                    // Draw lives and time left
                    spriteBatch.DrawString(kongtextFont10, "Lives: " + player.Lives, new Vector2(25, 10), Color.White);
                    spriteBatch.DrawString(kongtextFont10, "Time left: " + ((int)player.LevelTimeLeft), new Vector2(630, 10), Color.White);
                    // Draw the level name centered
                    spriteBatch.DrawString(kongtextFont10, levelName, CenterText(new Vector2(400, 10), levelName), Color.White);
                    break;
                case Chapter1.Level2:
                    // Draw managers, player etc
                    keyDoor.Draw(spriteBatch);
                    player.Draw(spriteBatch);
                    enemyManager.Draw(spriteBatch);
                    breakableManager.Draw(spriteBatch);
                    spikeManager.Draw(spriteBatch);
                    heartManager.Draw(spriteBatch);

                    // Draw all tiles for level
                    Level2.tileManager.Draw(spriteBatch);

                    // Draw lives and time left
                    spriteBatch.DrawString(kongtextFont10, "Lives: " + player.Lives, new Vector2(25, 10), Color.White);
                    spriteBatch.DrawString(kongtextFont10, "Time left: " + ((int)player.LevelTimeLeft), new Vector2(630, 10), Color.White);
                    // Draw the level name centered
                    spriteBatch.DrawString(kongtextFont10, levelName, CenterText(new Vector2(400, 10), levelName), Color.White);
                    break;
                case Chapter1.Level3:
                    // Draw managers, player etc
                    keyDoor.Draw(spriteBatch);
                    player.Draw(spriteBatch);
                    enemyManager.Draw(spriteBatch);
                    breakableManager.Draw(spriteBatch);
                    spikeManager.Draw(spriteBatch);
                    heartManager.Draw(spriteBatch);

                    // Draw all tiles for level
                    Level3.tileManager.Draw(spriteBatch);

                    // Draw lives and time left
                    spriteBatch.DrawString(kongtextFont10, "Lives: " + player.Lives, new Vector2(25, 10), Color.White);
                    spriteBatch.DrawString(kongtextFont10, "Time left: " + ((int)player.LevelTimeLeft), new Vector2(630, 10), Color.White);
                    // Draw the level name centered
                    spriteBatch.DrawString(kongtextFont10, levelName, CenterText(new Vector2(400, 10), levelName), Color.White);
                    break;
                case Chapter1.Level4:
                    // Draw managers, player etc
                    keyDoor.Draw(spriteBatch);
                    player.Draw(spriteBatch);
                    enemyManager.Draw(spriteBatch);
                    breakableManager.Draw(spriteBatch);
                    spikeManager.Draw(spriteBatch);
                    heartManager.Draw(spriteBatch);

                    // Draw all tiles for level
                    Level4.tileManager.Draw(spriteBatch);

                    // Draw lives and time left
                    spriteBatch.DrawString(kongtextFont10, "Lives: " + player.Lives, new Vector2(25, 10), Color.White);
                    spriteBatch.DrawString(kongtextFont10, "Time left: " + ((int)player.LevelTimeLeft), new Vector2(630, 10), Color.White);
                    // Draw the level name centered
                    spriteBatch.DrawString(kongtextFont10, levelName, CenterText(new Vector2(400, 10), levelName), Color.White);
                    break;
                case Chapter1.Level5:
                    // Draw managers, player etc
                    keyDoor.Draw(spriteBatch);
                    player.Draw(spriteBatch);
                    enemyManager.Draw(spriteBatch);
                    breakableManager.Draw(spriteBatch);
                    spikeManager.Draw(spriteBatch);
                    heartManager.Draw(spriteBatch);

                    // Draw all tiles for level
                    Level5.tileManager.Draw(spriteBatch);

                    // Draw lives and time left
                    spriteBatch.DrawString(kongtextFont10, "Lives: " + player.Lives, new Vector2(25, 10), Color.White);
                    spriteBatch.DrawString(kongtextFont10, "Time left: " + ((int)player.LevelTimeLeft), new Vector2(630, 10), Color.White);
                    // Draw the level name centered
                    spriteBatch.DrawString(kongtextFont10, levelName, CenterText(new Vector2(400, 10), levelName), Color.White);
                    break;
                case Chapter1.Level6:
                    // Draw managers, player etc
                    keyDoor.Draw(spriteBatch);
                    player.Draw(spriteBatch);
                    enemyManager.Draw(spriteBatch);
                    breakableManager.Draw(spriteBatch);
                    spikeManager.Draw(spriteBatch);
                    heartManager.Draw(spriteBatch);

                    // Draw all tiles for level
                    Level6.tileManager.Draw(spriteBatch);

                    // Draw lives and time left
                    spriteBatch.DrawString(kongtextFont10, "Lives: " + player.Lives, new Vector2(25, 10), Color.White);
                    spriteBatch.DrawString(kongtextFont10, "Time left: " + ((int)player.LevelTimeLeft), new Vector2(630, 10), Color.White);
                    // Draw the level name centered
                    spriteBatch.DrawString(kongtextFont10, levelName, CenterText(new Vector2(400, 10), levelName), Color.White);
                    break;
                case Chapter1.Level7:
                    // Draw managers, player etc
                    keyDoor.Draw(spriteBatch);
                    player.Draw(spriteBatch);
                    enemyManager.Draw(spriteBatch);
                    breakableManager.Draw(spriteBatch);
                    spikeManager.Draw(spriteBatch);
                    heartManager.Draw(spriteBatch);

                    // Draw all tiles for level
                    Level7.tileManager.Draw(spriteBatch);

                    // Draw lives and time left
                    spriteBatch.DrawString(kongtextFont10, "Lives: " + player.Lives, new Vector2(25, 10), Color.White);
                    spriteBatch.DrawString(kongtextFont10, "Time left: " + ((int)player.LevelTimeLeft), new Vector2(630, 10), Color.White);
                    // Draw the level name centered
                    spriteBatch.DrawString(kongtextFont10, levelName, CenterText(new Vector2(400, 10), levelName), Color.White);
                    break;
                case Chapter1.Level8:
                    // Draw managers, player etc
                    keyDoor.Draw(spriteBatch);
                    player.Draw(spriteBatch);
                    enemyManager.Draw(spriteBatch);
                    breakableManager.Draw(spriteBatch);
                    spikeManager.Draw(spriteBatch);
                    heartManager.Draw(spriteBatch);

                    // Draw all tiles for level
                    Level8.tileManager.Draw(spriteBatch);

                    // Draw lives and time left
                    spriteBatch.DrawString(kongtextFont10, "Lives: " + player.Lives, new Vector2(25, 10), Color.White);
                    spriteBatch.DrawString(kongtextFont10, "Time left: " + ((int)player.LevelTimeLeft), new Vector2(630, 10), Color.White);
                    // Draw the level name centered
                    spriteBatch.DrawString(kongtextFont10, levelName, CenterText(new Vector2(400, 10), levelName), Color.White);
                    break;

                case Chapter1.LevelTest:
                    // Draw managers, player etc
                    keyDoor.Draw(spriteBatch);
                    player.Draw(spriteBatch);
                    enemyManager.Draw(spriteBatch);
                    breakableManager.Draw(spriteBatch);
                    spikeManager.Draw(spriteBatch);
                    heartManager.Draw(spriteBatch);

                    // Draw all tiles for level
                    LevelTest.tileManager.Draw(spriteBatch);

                    // Draw lives and time left
                    spriteBatch.DrawString(kongtextFont10, "Lives: " + player.Lives, new Vector2(25, 10), Color.White);
                    spriteBatch.DrawString(kongtextFont10, "Time left: " + ((int)player.LevelTimeLeft), new Vector2(630, 10), Color.White);
                    // Draw the level name centered
                    spriteBatch.DrawString(kongtextFont10, levelName, CenterText(new Vector2(400, 10), levelName), Color.White);
                    break;
            }

        }
    }
}

