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
        public static Chapter2 C2Level = Chapter2.PreLevel1;

        // Which chapters are unlocked. Chapter 1 is allways accessible
        public static bool Chapter2Unlocked = true;
        public static bool Chapter3Unlocked = false;


        // The different game states
        public enum GameState
        {
            MainMenu,
            ChapterSelect,
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
            Win,
        };

        public enum Chapter2
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
            Win,
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

            // Font
            kongtextFont10 = Content.Load<SpriteFont>(@"Fonts\kongtext10");
            kongtextFont18 = Content.Load<SpriteFont>(@"Fonts\kongtext18");

            // Load content for each level in chapter 1
            C1Level1.LoadContent(Content, GraphicsDevice);
            C1Level2.LoadContent(Content, GraphicsDevice);
            C1Level3.LoadContent(Content, GraphicsDevice);
            C1Level4.LoadContent(Content, GraphicsDevice);
            C1Level5.LoadContent(Content, GraphicsDevice);
            C1Level6.LoadContent(Content, GraphicsDevice);
            C1Level7.LoadContent(Content, GraphicsDevice);
            C1Level8.LoadContent(Content, GraphicsDevice);
            //Level9.LoadContent(Content, GraphicsDevice);
            //Level10.LoadContent(Content, GraphicsDevice);
            C1LevelTest.LoadContent(Content, GraphicsDevice);

            // Load content for each level in chapter 2
            C2Level1.LoadContent(Content, GraphicsDevice);
            C2Level2.LoadContent(Content, GraphicsDevice);
            C2Level3.LoadContent(Content, GraphicsDevice);
            C2Level4.LoadContent(Content, GraphicsDevice);
            C2Level5.LoadContent(Content, GraphicsDevice);
            C2Level6.LoadContent(Content, GraphicsDevice);
            C2Level7.LoadContent(Content, GraphicsDevice);
            C2Level8.LoadContent(Content, GraphicsDevice);
            //C2Level9.LoadContent(Content, GraphicsDevice);
            //C2Level10.LoadContent(Content, GraphicsDevice);

            // Load backgrounds
            bgLevel = Content.Load<Texture2D>(@"Backgrounds/levelbg");
            bgMenu = Content.Load<Texture2D>(@"Backgrounds/Menus");
            bgMainMenu = Content.Load<Texture2D>(@"Backgrounds/Menu bg");
            bgWin = Content.Load<Texture2D>(@"Backgrounds/Win");
            bgGameOver = Content.Load<Texture2D>(@"Backgrounds/Game over");
            crtOverlay = Content.Load<Texture2D>(@"Backgrounds/CRT overlay");
            pausedOverlay = Content.Load<Texture2D>(@"Backgrounds/Paused overlay");

            // Load contents in soundManager
            SoundManager.LoadContent(Content, GraphicsDevice);


            // Load Menus
            MainMenu.LoadContent(kongtextFont10);
            ChapterSelect.LoadContent(Content, kongtextFont10, kongtextFont18);
            Credits.LoadContent(kongtextFont10, kongtextFont18);
            Options.LoadContent(kongtextFont10, kongtextFont18);
            GameOver.LoadContent(kongtextFont10);
            Win.LoadContent(kongtextFont10, kongtextFont18);
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
            if (InputManager.IsTapped(Keys.NumPad2))
            {
                C1Level++;
                C2Level++;
            }
            else if (InputManager.IsTapped(Keys.NumPad1))
            {
                C1Level -= 3;
                C2Level -= 3;
            }


            // Gamestate specific code
            switch (gameState)
            {
                case GameState.MainMenu:
                    MainMenu.Update(gameTime);
                    break;

                case GameState.ChapterSelect:
                    ChapterSelect.Update(gameTime);
                    break;

                case GameState.Credits:
                    Credits.Update(gameTime);
                    break;

                case GameState.Options:
                    Options.Update(gameTime);
                    break;

                case GameState.Playing:
                    // Selected chapter
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

                                    player.LevelTimeLeft = C1Level1.LevelTime;
                                    C1Level1.PositionPlayer(player);
                                    C1Level1.SpawnDoorAndKeys(keyDoor);
                                    C1Level1.SpawnBreakables(breakableManager);
                                    C1Level1.SpawnEnemies(enemyManager);
                                    C1Level1.SpawnSpikes(spikeManager);
                                    C1Level1.SpawnHearts(heartManager);
                                    C1Level1.SetupText(kongtextFont10);
                                    C1Level1.TutorialText.ShowText();
                                    // Move to next level
                                    C1Level++;
                                    break;
                                case Chapter1.Level1:
                                    collisionManager.Update(gameTime, C1Level1.tileManager, keyDoor, spikeManager);

                                    // Update the player
                                    player.Update(gameTime);

                                    enemyManager.Update(gameTime);
                                    breakableManager.Update(gameTime);

                                    C1Level1.TutorialText.Update(gameTime);
                                    break;

                                case Chapter1.PreLevel2:
                                    // Reset classes from previous levels
                                    enemyManager.Reset();
                                    breakableManager.Reset();
                                    keyDoor.Reset();
                                    spikeManager.Reset();
                                    heartManager.Reset();

                                    player.LevelTimeLeft = C1Level2.LevelTime;
                                    C1Level2.PositionPlayer(player);
                                    C1Level2.SpawnDoorAndKeys(keyDoor);
                                    C1Level2.SpawnBreakables(breakableManager);
                                    C1Level2.SpawnEnemies(enemyManager);
                                    C1Level2.SpawnSpikes(spikeManager);
                                    C1Level2.SpawnHearts(heartManager);
                                    C1Level2.SetupText(kongtextFont10);
                                    C1Level2.TutorialText.ShowText();
                                    // Move to next level
                                    C1Level++;
                                    break;
                                case Chapter1.Level2:
                                    collisionManager.Update(gameTime, C1Level2.tileManager, keyDoor, spikeManager);

                                    // Update the player
                                    player.Update(gameTime);

                                    enemyManager.Update(gameTime);
                                    breakableManager.Update(gameTime);

                                    C1Level2.TutorialText.Update(gameTime);
                                    break;

                                case Chapter1.PreLevel3:
                                    // Reset classes from previous levels
                                    enemyManager.Reset();
                                    breakableManager.Reset();
                                    keyDoor.Reset();
                                    spikeManager.Reset();
                                    heartManager.Reset();

                                    player.LevelTimeLeft = C1Level3.LevelTime;
                                    C1Level3.PositionPlayer(player);
                                    C1Level3.SpawnDoorAndKeys(keyDoor);
                                    C1Level3.SpawnBreakables(breakableManager);
                                    C1Level3.SpawnEnemies(enemyManager);
                                    C1Level3.SpawnSpikes(spikeManager);
                                    C1Level3.SpawnHearts(heartManager);
                                    // Move to next level
                                    C1Level++;
                                    break;
                                case Chapter1.Level3:
                                    collisionManager.Update(gameTime, C1Level3.tileManager, keyDoor, spikeManager);

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

                                    player.LevelTimeLeft = C1Level4.LevelTime;
                                    C1Level4.PositionPlayer(player);
                                    C1Level4.SpawnDoorAndKeys(keyDoor);
                                    C1Level4.SpawnBreakables(breakableManager);
                                    C1Level4.SpawnEnemies(enemyManager);
                                    C1Level4.SpawnSpikes(spikeManager);
                                    C1Level4.SpawnHearts(heartManager);
                                    // Move to next level
                                    C1Level++;
                                    break;
                                case Chapter1.Level4:
                                    collisionManager.Update(gameTime, C1Level4.tileManager, keyDoor, spikeManager);

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

                                    player.LevelTimeLeft = C1Level5.LevelTime;
                                    C1Level5.PositionPlayer(player);
                                    C1Level5.SpawnDoorAndKeys(keyDoor);
                                    C1Level5.SpawnBreakables(breakableManager);
                                    C1Level5.SpawnEnemies(enemyManager);
                                    C1Level5.SpawnSpikes(spikeManager);
                                    C1Level5.SpawnHearts(heartManager);
                                    // Move to next level
                                    C1Level++;
                                    break;
                                case Chapter1.Level5:
                                    collisionManager.Update(gameTime, C1Level5.tileManager, keyDoor, spikeManager);

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

                                    player.LevelTimeLeft = C1Level6.LevelTime;
                                    C1Level6.PositionPlayer(player);
                                    C1Level6.SpawnDoorAndKeys(keyDoor);
                                    C1Level6.SpawnBreakables(breakableManager);
                                    C1Level6.SpawnEnemies(enemyManager);
                                    C1Level6.SpawnSpikes(spikeManager);
                                    C1Level6.SpawnHearts(heartManager);
                                    // Move to next level
                                    C1Level++;
                                    break;

                                case Chapter1.Level6:
                                    collisionManager.Update(gameTime, C1Level6.tileManager, keyDoor, spikeManager);

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

                                    player.LevelTimeLeft = C1Level7.LevelTime;
                                    C1Level7.PositionPlayer(player);
                                    C1Level7.SpawnDoorAndKeys(keyDoor);
                                    C1Level7.SpawnBreakables(breakableManager);
                                    C1Level7.SpawnEnemies(enemyManager);
                                    C1Level7.SpawnSpikes(spikeManager);
                                    C1Level7.SpawnHearts(heartManager);
                                    // Move to next level
                                    C1Level++;
                                    break;

                                case Chapter1.Level7:
                                    collisionManager.Update(gameTime, C1Level7.tileManager, keyDoor, spikeManager);

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

                                    player.LevelTimeLeft = C1Level8.LevelTime;
                                    C1Level8.PositionPlayer(player);
                                    C1Level8.SpawnDoorAndKeys(keyDoor);
                                    C1Level8.SpawnBreakables(breakableManager);
                                    C1Level8.SpawnEnemies(enemyManager);
                                    C1Level8.SpawnSpikes(spikeManager);
                                    C1Level8.SpawnHearts(heartManager);
                                    // Move to next level
                                    C1Level++;
                                    break;

                                case Chapter1.Level8:
                                    collisionManager.Update(gameTime, C1Level8.tileManager, keyDoor, spikeManager);

                                    // Update the player
                                    player.Update(gameTime);

                                    enemyManager.Update(gameTime);
                                    breakableManager.Update(gameTime);
                                    break;

                                case Chapter1.Win:
                                    // Move to win screen
                                    gameState = GameState.Win;
                                    break;
                            }

                            break;

                        // CHAPTER 2
                        case Chapters.Chapter2:
                            switch (C2Level)
                            {
                                case Chapter2.PreLevel1:
                                    // Reset player (Only run before level 1)
                                    player.Reset();
                                    // Reset classes from previous levels
                                    enemyManager.Reset();
                                    breakableManager.Reset();
                                    keyDoor.Reset();
                                    spikeManager.Reset();
                                    heartManager.Reset();

                                    player.LevelTimeLeft = C2Level1.LevelTime;
                                    C2Level1.PositionPlayer(player);
                                    C2Level1.SpawnDoorAndKeys(keyDoor);
                                    C2Level1.SpawnBreakables(breakableManager);
                                    C2Level1.SpawnEnemies(enemyManager);
                                    C2Level1.SpawnSpikes(spikeManager);
                                    C2Level1.SpawnHearts(heartManager);
                                    // Move to next level
                                    C2Level++;
                                    break;
                                case Chapter2.Level1:
                                    collisionManager.Update(gameTime, C2Level1.tileManager, keyDoor, spikeManager);

                                    // Update the player
                                    player.Update(gameTime);

                                    enemyManager.Update(gameTime);
                                    breakableManager.Update(gameTime);

                                    break;

                                case Chapter2.PreLevel2:
                                    // Reset classes from previous levels
                                    enemyManager.Reset();
                                    breakableManager.Reset();
                                    keyDoor.Reset();
                                    spikeManager.Reset();
                                    heartManager.Reset();

                                    player.LevelTimeLeft = C2Level2.LevelTime;
                                    C2Level2.PositionPlayer(player);
                                    C2Level2.SpawnDoorAndKeys(keyDoor);
                                    C2Level2.SpawnBreakables(breakableManager);
                                    C2Level2.SpawnEnemies(enemyManager);
                                    C2Level2.SpawnSpikes(spikeManager);
                                    C2Level2.SpawnHearts(heartManager);
                                    // Move to next level
                                    C2Level++;
                                    break;
                                case Chapter2.Level2:
                                    collisionManager.Update(gameTime, C2Level2.tileManager, keyDoor, spikeManager);

                                    // Update the player
                                    player.Update(gameTime);

                                    enemyManager.Update(gameTime);
                                    breakableManager.Update(gameTime);
                                    break;

                                case Chapter2.PreLevel3:
                                    // Reset classes from previous levels
                                    enemyManager.Reset();
                                    breakableManager.Reset();
                                    keyDoor.Reset();
                                    spikeManager.Reset();
                                    heartManager.Reset();

                                    player.LevelTimeLeft = C2Level3.LevelTime;
                                    C2Level3.PositionPlayer(player);
                                    C2Level3.SpawnDoorAndKeys(keyDoor);
                                    C2Level3.SpawnBreakables(breakableManager);
                                    C2Level3.SpawnEnemies(enemyManager);
                                    C2Level3.SpawnSpikes(spikeManager);
                                    C2Level3.SpawnHearts(heartManager);
                                    // Move to next level
                                    C2Level++;
                                    break;
                                case Chapter2.Level3:
                                    collisionManager.Update(gameTime, C2Level3.tileManager, keyDoor, spikeManager);

                                    // Update the player
                                    player.Update(gameTime);

                                    enemyManager.Update(gameTime);
                                    breakableManager.Update(gameTime);
                                    break;

                                case Chapter2.PreLevel4:
                                    // Reset classes from previous levels
                                    enemyManager.Reset();
                                    breakableManager.Reset();
                                    keyDoor.Reset();
                                    spikeManager.Reset();
                                    heartManager.Reset();

                                    player.LevelTimeLeft = C2Level4.LevelTime;
                                    C2Level4.PositionPlayer(player);
                                    C2Level4.SpawnDoorAndKeys(keyDoor);
                                    C2Level4.SpawnBreakables(breakableManager);
                                    C2Level4.SpawnEnemies(enemyManager);
                                    C2Level4.SpawnSpikes(spikeManager);
                                    C2Level4.SpawnHearts(heartManager);
                                    // Move to next level
                                    C2Level++;
                                    break;
                                case Chapter2.Level4:
                                    collisionManager.Update(gameTime, C2Level4.tileManager, keyDoor, spikeManager);

                                    // Update the player
                                    player.Update(gameTime);

                                    enemyManager.Update(gameTime);
                                    breakableManager.Update(gameTime);
                                    break;

                                case Chapter2.PreLevel5:
                                    // Reset classes from previous levels
                                    enemyManager.Reset();
                                    breakableManager.Reset();
                                    keyDoor.Reset();
                                    spikeManager.Reset();
                                    heartManager.Reset();

                                    player.LevelTimeLeft = C2Level5.LevelTime;
                                    C2Level5.PositionPlayer(player);
                                    C2Level5.SpawnDoorAndKeys(keyDoor);
                                    C2Level5.SpawnBreakables(breakableManager);
                                    C2Level5.SpawnEnemies(enemyManager);
                                    C2Level5.SpawnSpikes(spikeManager);
                                    C2Level5.SpawnHearts(heartManager);
                                    // Move to next level
                                    C2Level++;
                                    break;
                                case Chapter2.Level5:
                                    collisionManager.Update(gameTime, C2Level5.tileManager, keyDoor, spikeManager);

                                    // Update the player
                                    player.Update(gameTime);

                                    enemyManager.Update(gameTime);
                                    breakableManager.Update(gameTime);
                                    break;

                                case Chapter2.PreLevel6:
                                    // Reset classes from previous levels
                                    enemyManager.Reset();
                                    breakableManager.Reset();
                                    keyDoor.Reset();
                                    spikeManager.Reset();
                                    heartManager.Reset();

                                    player.LevelTimeLeft = C2Level6.LevelTime;
                                    C2Level6.PositionPlayer(player);
                                    C2Level6.SpawnDoorAndKeys(keyDoor);
                                    C2Level6.SpawnBreakables(breakableManager);
                                    C2Level6.SpawnEnemies(enemyManager);
                                    C2Level6.SpawnSpikes(spikeManager);
                                    C2Level6.SpawnHearts(heartManager);
                                    // Move to next level
                                    C2Level++;
                                    break;

                                case Chapter2.Level6:
                                    collisionManager.Update(gameTime, C2Level6.tileManager, keyDoor, spikeManager);

                                    // Update the player
                                    player.Update(gameTime);

                                    enemyManager.Update(gameTime);
                                    breakableManager.Update(gameTime);
                                    break;

                                case Chapter2.PreLevel7:
                                    // Reset classes from previous levels
                                    enemyManager.Reset();
                                    breakableManager.Reset();
                                    keyDoor.Reset();
                                    spikeManager.Reset();
                                    heartManager.Reset();

                                    player.LevelTimeLeft = C2Level7.LevelTime;
                                    C2Level7.PositionPlayer(player);
                                    C2Level7.SpawnDoorAndKeys(keyDoor);
                                    C2Level7.SpawnBreakables(breakableManager);
                                    C2Level7.SpawnEnemies(enemyManager);
                                    C2Level7.SpawnSpikes(spikeManager);
                                    C2Level7.SpawnHearts(heartManager);
                                    // Move to next level
                                    C2Level++;
                                    break;

                                case Chapter2.Level7:
                                    collisionManager.Update(gameTime, C2Level7.tileManager, keyDoor, spikeManager);

                                    // Update the player
                                    player.Update(gameTime);

                                    enemyManager.Update(gameTime);
                                    breakableManager.Update(gameTime);
                                    break;

                                case Chapter2.PreLevel8:
                                    // Reset classes from previous levels
                                    enemyManager.Reset();
                                    breakableManager.Reset();
                                    keyDoor.Reset();
                                    spikeManager.Reset();
                                    heartManager.Reset();

                                    player.LevelTimeLeft = C2Level8.LevelTime;
                                    C2Level8.PositionPlayer(player);
                                    C2Level8.SpawnDoorAndKeys(keyDoor);
                                    C2Level8.SpawnBreakables(breakableManager);
                                    C2Level8.SpawnEnemies(enemyManager);
                                    C2Level8.SpawnSpikes(spikeManager);
                                    C2Level8.SpawnHearts(heartManager);
                                    // Move to next level
                                    C2Level++;
                                    break;

                                case Chapter2.Level8:
                                    collisionManager.Update(gameTime, C2Level8.tileManager, keyDoor, spikeManager);

                                    // Update the player
                                    player.Update(gameTime);

                                    enemyManager.Update(gameTime);
                                    breakableManager.Update(gameTime);
                                    break;
                                case Chapter2.Win:
                                    // Move to win screen
                                    gameState = GameState.Win;
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
                    Win.Update(gameTime);
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

                case GameState.ChapterSelect:
                    spriteBatch.Draw(bgMenu, Vector2.Zero, Color.White);
                    ChapterSelect.Draw(spriteBatch);
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
                    Win.Draw(spriteBatch);
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
            // Name of the level
            string levelName;

            // Selected chapter
            switch (Chapter)
            {
                // CHAPTER 1
                case Chapters.Chapter1:
                    // Create a string of the level name
                    levelName = "Level: " + (((int) C1Level / 2) + 1);

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
                            C1Level1.tileManager.Draw(spriteBatch);

                            // Draw tutorial text
                            C1Level1.TutorialText.Draw(spriteBatch);

                            // Draw lives and time left
                            spriteBatch.DrawString(kongtextFont10, "Lives: " + player.Lives, new Vector2(25, 10),
                                Color.White);
                            spriteBatch.DrawString(kongtextFont10, "Time left: " + ((int) player.LevelTimeLeft),
                                new Vector2(630, 10), Color.White);
                            // Draw the level name centered
                            spriteBatch.DrawString(kongtextFont10, levelName,
                                CenterText(new Vector2(400, 10), levelName), Color.White);
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
                            C1Level2.tileManager.Draw(spriteBatch);

                            // Draw tutorial text
                            C1Level2.TutorialText.Draw(spriteBatch);

                            // Draw lives and time left
                            spriteBatch.DrawString(kongtextFont10, "Lives: " + player.Lives, new Vector2(25, 10),
                                Color.White);
                            spriteBatch.DrawString(kongtextFont10, "Time left: " + ((int) player.LevelTimeLeft),
                                new Vector2(630, 10), Color.White);
                            // Draw the level name centered
                            spriteBatch.DrawString(kongtextFont10, levelName,
                                CenterText(new Vector2(400, 10), levelName), Color.White);
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
                            C1Level3.tileManager.Draw(spriteBatch);

                            // Draw lives and time left
                            spriteBatch.DrawString(kongtextFont10, "Lives: " + player.Lives, new Vector2(25, 10),
                                Color.White);
                            spriteBatch.DrawString(kongtextFont10, "Time left: " + ((int) player.LevelTimeLeft),
                                new Vector2(630, 10), Color.White);
                            // Draw the level name centered
                            spriteBatch.DrawString(kongtextFont10, levelName,
                                CenterText(new Vector2(400, 10), levelName), Color.White);
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
                            C1Level4.tileManager.Draw(spriteBatch);

                            // Draw lives and time left
                            spriteBatch.DrawString(kongtextFont10, "Lives: " + player.Lives, new Vector2(25, 10),
                                Color.White);
                            spriteBatch.DrawString(kongtextFont10, "Time left: " + ((int) player.LevelTimeLeft),
                                new Vector2(630, 10), Color.White);
                            // Draw the level name centered
                            spriteBatch.DrawString(kongtextFont10, levelName,
                                CenterText(new Vector2(400, 10), levelName), Color.White);
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
                            C1Level5.tileManager.Draw(spriteBatch);

                            // Draw lives and time left
                            spriteBatch.DrawString(kongtextFont10, "Lives: " + player.Lives, new Vector2(25, 10),
                                Color.White);
                            spriteBatch.DrawString(kongtextFont10, "Time left: " + ((int) player.LevelTimeLeft),
                                new Vector2(630, 10), Color.White);
                            // Draw the level name centered
                            spriteBatch.DrawString(kongtextFont10, levelName,
                                CenterText(new Vector2(400, 10), levelName), Color.White);
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
                            C1Level6.tileManager.Draw(spriteBatch);

                            // Draw lives and time left
                            spriteBatch.DrawString(kongtextFont10, "Lives: " + player.Lives, new Vector2(25, 10),
                                Color.White);
                            spriteBatch.DrawString(kongtextFont10, "Time left: " + ((int) player.LevelTimeLeft),
                                new Vector2(630, 10), Color.White);
                            // Draw the level name centered
                            spriteBatch.DrawString(kongtextFont10, levelName,
                                CenterText(new Vector2(400, 10), levelName), Color.White);
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
                            C1Level7.tileManager.Draw(spriteBatch);

                            // Draw lives and time left
                            spriteBatch.DrawString(kongtextFont10, "Lives: " + player.Lives, new Vector2(25, 10),
                                Color.White);
                            spriteBatch.DrawString(kongtextFont10, "Time left: " + ((int) player.LevelTimeLeft),
                                new Vector2(630, 10), Color.White);
                            // Draw the level name centered
                            spriteBatch.DrawString(kongtextFont10, levelName,
                                CenterText(new Vector2(400, 10), levelName), Color.White);
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
                            C1Level8.tileManager.Draw(spriteBatch);

                            // Draw lives and time left
                            spriteBatch.DrawString(kongtextFont10, "Lives: " + player.Lives, new Vector2(25, 10),
                                Color.White);
                            spriteBatch.DrawString(kongtextFont10, "Time left: " + ((int) player.LevelTimeLeft),
                                new Vector2(630, 10), Color.White);
                            // Draw the level name centered
                            spriteBatch.DrawString(kongtextFont10, levelName,
                                CenterText(new Vector2(400, 10), levelName), Color.White);
                            break;
                    }

                    break;

                // CHAPTER 2
                case Chapters.Chapter2:
                    // Create a string of the level name
                    levelName = "Level: " + (((int) C2Level / 2) + 1);

                    switch (C2Level)
                    {
                        case Chapter2.Level1:
                            // Draw managers, player etc
                            keyDoor.Draw(spriteBatch);
                            player.Draw(spriteBatch);
                            enemyManager.Draw(spriteBatch);
                            breakableManager.Draw(spriteBatch);
                            spikeManager.Draw(spriteBatch);
                            heartManager.Draw(spriteBatch);

                            // Draw all tiles for level
                            C2Level1.tileManager.Draw(spriteBatch);

                            // Draw lives and time left
                            spriteBatch.DrawString(kongtextFont10, "Lives: " + player.Lives, new Vector2(25, 10),
                                Color.White);
                            spriteBatch.DrawString(kongtextFont10, "Time left: " + ((int) player.LevelTimeLeft),
                                new Vector2(630, 10), Color.White);
                            // Draw the level name centered
                            spriteBatch.DrawString(kongtextFont10, levelName,
                                CenterText(new Vector2(400, 10), levelName), Color.White);
                            break;
                        case Chapter2.Level2:
                            // Draw managers, player etc
                            keyDoor.Draw(spriteBatch);
                            player.Draw(spriteBatch);
                            enemyManager.Draw(spriteBatch);
                            breakableManager.Draw(spriteBatch);
                            spikeManager.Draw(spriteBatch);
                            heartManager.Draw(spriteBatch);

                            // Draw all tiles for level
                            C2Level2.tileManager.Draw(spriteBatch);

                            // Draw lives and time left
                            spriteBatch.DrawString(kongtextFont10, "Lives: " + player.Lives, new Vector2(25, 10),
                                Color.White);
                            spriteBatch.DrawString(kongtextFont10, "Time left: " + ((int) player.LevelTimeLeft),
                                new Vector2(630, 10), Color.White);
                            // Draw the level name centered
                            spriteBatch.DrawString(kongtextFont10, levelName,
                                CenterText(new Vector2(400, 10), levelName), Color.White);
                            break;
                        case Chapter2.Level3:
                            // Draw managers, player etc
                            keyDoor.Draw(spriteBatch);
                            player.Draw(spriteBatch);
                            enemyManager.Draw(spriteBatch);
                            breakableManager.Draw(spriteBatch);
                            spikeManager.Draw(spriteBatch);
                            heartManager.Draw(spriteBatch);

                            // Draw all tiles for level
                            C2Level3.tileManager.Draw(spriteBatch);

                            // Draw lives and time left
                            spriteBatch.DrawString(kongtextFont10, "Lives: " + player.Lives, new Vector2(25, 10),
                                Color.White);
                            spriteBatch.DrawString(kongtextFont10, "Time left: " + ((int) player.LevelTimeLeft),
                                new Vector2(630, 10), Color.White);
                            // Draw the level name centered
                            spriteBatch.DrawString(kongtextFont10, levelName,
                                CenterText(new Vector2(400, 10), levelName), Color.White);
                            break;
                        case Chapter2.Level4:
                            // Draw managers, player etc
                            keyDoor.Draw(spriteBatch);
                            player.Draw(spriteBatch);
                            enemyManager.Draw(spriteBatch);
                            breakableManager.Draw(spriteBatch);
                            spikeManager.Draw(spriteBatch);
                            heartManager.Draw(spriteBatch);

                            // Draw all tiles for level
                            C2Level4.tileManager.Draw(spriteBatch);

                            // Draw lives and time left
                            spriteBatch.DrawString(kongtextFont10, "Lives: " + player.Lives, new Vector2(25, 10),
                                Color.White);
                            spriteBatch.DrawString(kongtextFont10, "Time left: " + ((int)player.LevelTimeLeft),
                                new Vector2(630, 10), Color.White);
                            // Draw the level name centered
                            spriteBatch.DrawString(kongtextFont10, levelName,
                                CenterText(new Vector2(400, 10), levelName), Color.White);
                            break;
                        case Chapter2.Level5:
                            // Draw managers, player etc
                            keyDoor.Draw(spriteBatch);
                            player.Draw(spriteBatch);
                            enemyManager.Draw(spriteBatch);
                            breakableManager.Draw(spriteBatch);
                            spikeManager.Draw(spriteBatch);
                            heartManager.Draw(spriteBatch);

                            // Draw all tiles for level
                            C2Level5.tileManager.Draw(spriteBatch);

                            // Draw lives and time left
                            spriteBatch.DrawString(kongtextFont10, "Lives: " + player.Lives, new Vector2(25, 10),
                                Color.White);
                            spriteBatch.DrawString(kongtextFont10, "Time left: " + ((int)player.LevelTimeLeft),
                                new Vector2(630, 10), Color.White);
                            // Draw the level name centered
                            spriteBatch.DrawString(kongtextFont10, levelName,
                                CenterText(new Vector2(400, 10), levelName), Color.White);
                            break;
                        case Chapter2.Level6:
                            // Draw managers, player etc
                            keyDoor.Draw(spriteBatch);
                            player.Draw(spriteBatch);
                            enemyManager.Draw(spriteBatch);
                            breakableManager.Draw(spriteBatch);
                            spikeManager.Draw(spriteBatch);
                            heartManager.Draw(spriteBatch);

                            // Draw all tiles for level
                            C2Level6.tileManager.Draw(spriteBatch);

                            // Draw lives and time left
                            spriteBatch.DrawString(kongtextFont10, "Lives: " + player.Lives, new Vector2(25, 10),
                                Color.White);
                            spriteBatch.DrawString(kongtextFont10, "Time left: " + ((int)player.LevelTimeLeft),
                                new Vector2(630, 10), Color.White);
                            // Draw the level name centered
                            spriteBatch.DrawString(kongtextFont10, levelName,
                                CenterText(new Vector2(400, 10), levelName), Color.White);
                            break;
                        case Chapter2.Level7:
                            // Draw managers, player etc
                            keyDoor.Draw(spriteBatch);
                            player.Draw(spriteBatch);
                            enemyManager.Draw(spriteBatch);
                            breakableManager.Draw(spriteBatch);
                            spikeManager.Draw(spriteBatch);
                            heartManager.Draw(spriteBatch);

                            // Draw all tiles for level
                            C2Level7.tileManager.Draw(spriteBatch);

                            // Draw lives and time left
                            spriteBatch.DrawString(kongtextFont10, "Lives: " + player.Lives, new Vector2(25, 10),
                                Color.White);
                            spriteBatch.DrawString(kongtextFont10, "Time left: " + ((int)player.LevelTimeLeft),
                                new Vector2(630, 10), Color.White);
                            // Draw the level name centered
                            spriteBatch.DrawString(kongtextFont10, levelName,
                                CenterText(new Vector2(400, 10), levelName), Color.White);
                            break;
                        case Chapter2.Level8:
                            // Draw managers, player etc
                            keyDoor.Draw(spriteBatch);
                            player.Draw(spriteBatch);
                            enemyManager.Draw(spriteBatch);
                            breakableManager.Draw(spriteBatch);
                            spikeManager.Draw(spriteBatch);
                            heartManager.Draw(spriteBatch);

                            // Draw all tiles for level
                            C2Level8.tileManager.Draw(spriteBatch);

                            // Draw lives and time left
                            spriteBatch.DrawString(kongtextFont10, "Lives: " + player.Lives, new Vector2(25, 10),
                                Color.White);
                            spriteBatch.DrawString(kongtextFont10, "Time left: " + ((int)player.LevelTimeLeft),
                                new Vector2(630, 10), Color.White);
                            // Draw the level name centered
                            spriteBatch.DrawString(kongtextFont10, levelName,
                                CenterText(new Vector2(400, 10), levelName), Color.White);
                            break;
                    }

                    break;

            }
        }
    }
}

