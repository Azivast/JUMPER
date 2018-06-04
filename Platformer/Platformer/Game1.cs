using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Platformer
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        /// LEVEL 1 "PLATFORMS"
        // List of platforms for level 1 using the platform class.
        List<Platform> platforms1 = new List<Platform>();
        // List of taser blocks for level 1 using the platform class.
        List<Platform> tasers1 = new List<Platform>();

        /// LEVEL 2 "PLATFORMS"
        // List of platforms for level 2 using the platform class.
        List<Platform> platforms2 = new List<Platform>();
        // List of taser blocks for level 2 using the platform class.
        List<Platform> tasers2 = new List<Platform>();

        /// LEVEL 3 "PLATFORMS"
        // List of platforms for level 3 using the platform class.
        List<Platform> platforms3 = new List<Platform>();
        // List of taser blocks for level 3 using the platform class.
        List<Platform> tasers3 = new List<Platform>();

        // Which game state to start in.
        GameState gameState = GameState.MainMenu;

        // The different game states.
        enum GameState
        {
            MainMenu, Credits, Tutorial, Tutorial2, preLevel1, Level1, preLevel2, Level2, preLevel3, Level3, Win, GameOver
        };

        // Bool used to detect i space is pressed.
        Boolean spacePressed;

        // Time left for player to complete level.
        float timeLeft = 60;

        /// PLAYER VARIABLES
        // Player Sprite.
        Texture2D playerSprite;
        // Player Position.
        Vector2 playerPosition;
        // Player Velocity.
        Vector2 playerVelocity;
        // Bool for if player is falling.
        Boolean playerAirborne = true;
        // Player Lives.
        int playerLives = 3;

        // Door Sprite & Position.
        Texture2D doorSprite;
        Vector2 doorPosition = new Vector2(100, 100);
        // Key Sprite & Positions.
        Texture2D keySprite;
        Vector2 key1Position = new Vector2(100, 100);
        Vector2 key2Position = new Vector2(100, 100);
        Vector2 key3Position = new Vector2(100, 100);
        // Key 1-3 shown? (Used after picking them up.)
        bool key1Shown = true;
        bool key2Shown = true;
        bool key3Shown = true;

        // Breaking block texture & postions.
        Texture2D breakableSprite;
        Vector2 breakable1Position = new Vector2(200, 100);
        Vector2 breakable2Position = new Vector2(200, 100);
        Vector2 breakable3Position = new Vector2(200, 100);
        Vector2 breakable4Position = new Vector2(200, 100);
        Vector2 breakable5Position = new Vector2(200, 100);
        Vector2 breakable6Position = new Vector2(200, 100);
        Vector2 breakable7Position = new Vector2(200, 100);
        Vector2 breakable8Position = new Vector2(200, 100);
        // Breaking block timers.
        int breakable1Timer = 70;
        int breakable2Timer = 70;
        int breakable3Timer = 70;
        int breakable4Timer = 70;
        int breakable5Timer = 70;
        int breakable6Timer = 70;
        int breakable7Timer = 70;
        int breakable8Timer = 70;
        // Variable used for if breaking blocks are shown or "broken".
        bool breakable1Shown = true;
        bool breakable2Shown = true;
        bool breakable3Shown = true;
        bool breakable4Shown = true;
        bool breakable5Shown = true;
        bool breakable6Shown = true;
        bool breakable7Shown = true;
        bool breakable8Shown = true;
        // Variable used for if breaking blocks are breaking.
        bool breakable1Break = false;
        bool breakable2Break = false;
        bool breakable3Break = false;
        bool breakable4Break = false;
        bool breakable5Break = false;
        bool breakable6Break = false;
        bool breakable7Break = false;
        bool breakable8Break = false;

        // Enemy textures and positions.
        Texture2D enemySprite;
        Vector2 enemy1Position = new Vector2(200, 100);
        Vector2 enemy2Position = new Vector2(200, 100);
        Vector2 enemy3Position = new Vector2(200, 100);
        Vector2 enemy1Velocity = new Vector2(3, 0);
        Vector2 enemy2Velocity = new Vector2(3, 0);
        Vector2 enemy3Velocity = new Vector2(3, 0);

        // Backgrounds for the different game states and the CRT overlay.
        Texture2D crtOverlay;
        Texture2D menuBG;
        Texture2D credits;
        Texture2D tutorial;
        Texture2D tutorial2;
        Texture2D win;
        Texture2D levelBG;
        Texture2D gameOver;

        // Amount of keys gathered.
        float keysGathered = 0;

        // Sounds and background music.
        SoundEffect soundSelect;
        SoundEffect soundHurt;
        SoundEffect soundPickUp;
        SoundEffect soundNextLevel;
        SoundEffect soundWin;
        SoundEffect music;
        SoundEffectInstance musicInstance;

        // Font used.
        SpriteFont kongtextFont;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load sound effects.
            soundSelect = Content.Load<SoundEffect>(@"Sounds/Select");
            soundHurt = Content.Load<SoundEffect>(@"Sounds/Hurt");
            soundPickUp = Content.Load<SoundEffect>(@"Sounds/Pick Up");
            soundNextLevel = Content.Load<SoundEffect>(@"Sounds/NextLevel");
            soundWin = Content.Load<SoundEffect>(@"Sounds/win");
            // Load music and loop it.
            music = Content.Load<SoundEffect>(@"Sounds/Ozzed - Lugn Techno");
            musicInstance = music.CreateInstance();
            musicInstance.IsLooped = true;
            musicInstance.Play();


            // Load the font.
            kongtextFont = Content.Load<SpriteFont>(@"Fonts\kongtext");

            // Load player sprite.
            playerSprite = Content.Load<Texture2D>(@"Sprites/Player");
            // Load door sprite.
            doorSprite = Content.Load<Texture2D>(@"Sprites/Door");
            // Load key sprite.
            keySprite = Content.Load<Texture2D>(@"Sprites/Key");
            // Load menu background.
            menuBG = Content.Load<Texture2D>(@"Sprites/Backgrounds/Menu bg");
            // Load credits background.
            credits = Content.Load<Texture2D>(@"Sprites/Backgrounds/Credits");
            // Load tutorial backgrounds.
            tutorial = Content.Load<Texture2D>(@"Sprites/Backgrounds/Tutorial");
            tutorial2 = Content.Load<Texture2D>(@"Sprites/Backgrounds/Tutorial2");
            // Load level background.
            levelBG = Content.Load<Texture2D>(@"Sprites/Backgrounds/levelbg");
            // Load "game over" background.
            gameOver = Content.Load<Texture2D>(@"Sprites/Backgrounds/Game over");
            // Load win background.
            win = Content.Load<Texture2D>(@"Sprites/Backgrounds/Win");
            // Load CRT overlay.
            crtOverlay = Content.Load<Texture2D>(@"Sprites/Backgrounds/CRT overlay");


            /// Level textures
            // Level 1 platform textures.
            platforms1.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 1/p1"), new Vector2(0, 88)));
            platforms1.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 1/p2"), new Vector2(93, 113)));
            platforms1.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 1/p3"), new Vector2(68, 172)));
            platforms1.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 1/p4"), new Vector2(583, 147)));
            platforms1.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 1/p5"), new Vector2(608, 123)));
            platforms1.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 1/p5"), new Vector2(733, 123)));
            platforms1.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 1/p5"), new Vector2(775, 243)));
            platforms1.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 1/p5"), new Vector2(549, 318)));
            platforms1.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 1/p6"), new Vector2(733, 147)));
            platforms1.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 1/p7"), new Vector2(733, 172)));
            platforms1.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 1/p8"), new Vector2(44, 197)));
            platforms1.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 1/p9"), new Vector2(44, 343)));
            platforms1.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 1/p10"), new Vector2(159, 268)));
            platforms1.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 1/p11"), new Vector2(279, 293)));
            platforms1.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 1/p12"), new Vector2(343, 268)));
            platforms1.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 1/p12"), new Vector2(448, 268)));
            platforms1.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 1/p13"), new Vector2(549, 293)));
            platforms1.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 1/p14"), new Vector2(549, 268)));
            // Platforms to prevent moving outside screen edge.
            platforms1.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Edges/e1"), new Vector2(-25, 0)));
            platforms1.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Edges/e2"), new Vector2(0, -25)));
            platforms1.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Edges/e1"), new Vector2(800, 0)));
            platforms1.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Edges/e2"), new Vector2(0, 480)));
            // Taser block texture.
            tasers1.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 1/Taser1"), new Vector2(304, 318)));

            // Level 2 platform textures.
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 2/p1"), new Vector2(73, 0)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 2/p2"), new Vector2(0, 209)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 2/p3"), new Vector2(0, 234)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 2/p4"), new Vector2(0, 361)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 2/p5"), new Vector2(129, 084)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 2/p5"), new Vector2(178, 109)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 2/p5"), new Vector2(231, 134)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 2/p5"), new Vector2(280, 144)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 2/p5"), new Vector2(329, 184)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 2/p5"), new Vector2(620, 184)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 2/p5"), new Vector2(672, 159)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 2/p5"), new Vector2(721, 134)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 2/p5"), new Vector2(117, 289)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 2/p5"), new Vector2(200, 289)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 2/p5"), new Vector2(262, 289)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 2/p5"), new Vector2(325, 289)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 2/p5"), new Vector2(400, 264)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 2/p5"), new Vector2(475, 38)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 2/p5"), new Vector2(500, 38)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 2/p5"), new Vector2(503, 110)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 2/p5"), new Vector2(528, 110)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 2/p6"), new Vector2(350, 361)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 2/p7"), new Vector2(375, 314)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 2/p8"), new Vector2(375, 289)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 2/p9"), new Vector2(614, 234)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 2/p10"), new Vector2(453, 0)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 2/p10"), new Vector2(550, 0)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 2/p11"), new Vector2(139, 209)));
            // Platforms to prevent moving outside screen edge.
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Edges/e1"), new Vector2(-25, 0)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Edges/e2"), new Vector2(0, -25)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Edges/e1"), new Vector2(800, 0)));
            platforms2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Edges/e2"), new Vector2(0, 480)));
            // Taser block texture.
            tasers2.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 2/Taser1"), new Vector2(48, 361)));

            // Level 3 platform textures.
            platforms3.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 3/p1"), new Vector2(0, 391)));
            platforms3.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 3/p2"), new Vector2(699, 366)));
            platforms3.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 3/p3"), new Vector2(731, 341)));
            platforms3.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 3/p4"), new Vector2(0, 286)));
            platforms3.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 3/p5"), new Vector2(48, 286)));
            platforms3.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 3/p6"), new Vector2(163, 186)));
            platforms3.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 3/p7"), new Vector2(0, 207)));
            platforms3.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 3/p8"), new Vector2(50, 82)));
            platforms3.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 3/p9"), new Vector2(0, 57)));
            platforms3.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 3/p10"), new Vector2(239, 82)));
            platforms3.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 3/p11"), new Vector2(322, 107)));
            platforms3.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 3/p12"), new Vector2(414, 132)));
            platforms3.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 3/p13"), new Vector2(414, 0)));
            platforms3.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 3/p14"), new Vector2(414, 216)));
            platforms3.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 3/p15"), new Vector2(474, 191)));
            platforms3.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 3/p16"), new Vector2(499, 166)));
            platforms3.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 3/p16"), new Vector2(108, 366)));
            platforms3.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 3/p16"), new Vector2(299, 366)));
            platforms3.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 3/p16"), new Vector2(511, 366)));
            platforms3.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 3/p17"), new Vector2(768, 153)));
            // Platforms to prevent moving outside screen edge.
            platforms3.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Edges/e1"), new Vector2(-25, 0)));
            platforms3.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Edges/e2"), new Vector2(0, -25)));
            platforms3.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Edges/e1"), new Vector2(800, 0)));
            platforms3.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Edges/e2"), new Vector2(0, 480)));
            // Taser block textures.
            tasers3.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Level platforms/Level 3/Taser1"), new Vector2(524, 191)));
            tasers3.Add(new Platform(Content.Load<Texture2D>(@"Sprites/Taser"), new Vector2(138, 261)));

            // Breaking block texture.
            breakableSprite = Content.Load<Texture2D>(@"Sprites/Breakable");
            // Enemy txture.
            enemySprite = Content.Load<Texture2D>(@"Sprites/Enemy");

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit with escape.
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Escape))
                this.Exit();
            // Make F toggle full-screen mode. (Commented out as it's broken anyways.)
            //if (Keyboard.GetState().IsKeyDown(Keys.F))
            //{
            //    graphics.IsFullScreen = !graphics.IsFullScreen;
            //    graphics.ApplyChanges();
            //}

            // Set spacePressed to false if space isn't pressed. Used for menu navigation.
            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                spacePressed = false;
            }

            // Go to Main menu if M is pressed.
            if (keyboard.IsKeyDown(Keys.M))
            {
                gameState = GameState.MainMenu;

            }

            // Change door sprite depending on if all keys are collected.
            if (keysGathered >= 3)
            {
                doorSprite = Content.Load<Texture2D>(@"Sprites/Door open");
            }
            else if (keysGathered < 3)
            {
                doorSprite = Content.Load<Texture2D>(@"Sprites/Door");
            }

            #region PLAYER, CONTROL & GRAVITY
            // Move player based on velocity.
            playerPosition += playerVelocity;

            // Go to "game over" if player dies.
            if (playerLives <= 0)
            {
                gameState = GameState.GameOver;
                playerLives = 3;
            }
            // Cap the players maximum speed.
            if (playerVelocity.Y >= 4)
            {
                playerVelocity.Y = 4;
            }
            else if (playerVelocity.Y <= -4)
            {
                playerVelocity.Y = -4;
            }
    
            // If pressing right move player right and apply respective texture.
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                playerVelocity.X = 3f;
                playerSprite = Content.Load<Texture2D>(@"Sprites/Player");
            }
            // If pressing left move player left and apply respective texture.
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            { 
                playerVelocity.X = -3f;
                playerSprite = Content.Load<Texture2D>(@"Sprites/Player2");
            }
            // Otherwise set velocity to 0.
            else
            {
                playerVelocity.X = 0f;
            }
            // If pressing up when stationary jump.
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && playerAirborne == false)
            {
                // Increase player's velocity upwards.
                playerVelocity.Y -= 5f;
                // Move player one pixel up to avoid collision with platform.
                playerPosition.Y --;
                // Set playerAirborne to true to prevent flying.
                playerAirborne = true;
            }

            // GRAVITY. If player is airborn pull downwards.
            playerVelocity.Y += 0.15f;
            #endregion

            #region Rectangles for collision detection.
            // Create rectangle around player.
            Rectangle playerRect = new Rectangle((int)playerPosition.X, (int)playerPosition.Y, playerSprite.Width, playerSprite.Height);

            // Create a rectangle for door and keys.
            Rectangle doorRect = new Rectangle((int)doorPosition.X, (int)doorPosition.Y, doorSprite.Width, doorSprite.Height);
            Rectangle key1Rect = new Rectangle((int)key1Position.X, (int)key1Position.Y, keySprite.Width, keySprite.Height);
            Rectangle key2Rect = new Rectangle((int)key2Position.X, (int)key2Position.Y, keySprite.Width, keySprite.Height);
            Rectangle key3Rect = new Rectangle((int)key3Position.X, (int)key3Position.Y, keySprite.Width, keySprite.Height);

            // Rectangles for breaking blocks.
            Rectangle breakable1Rect = new Rectangle((int)breakable1Position.X, (int)breakable1Position.Y, breakableSprite.Width, breakableSprite.Height);
            Rectangle breakable2Rect = new Rectangle((int)breakable2Position.X, (int)breakable2Position.Y, breakableSprite.Width, breakableSprite.Height);
            Rectangle breakable3Rect = new Rectangle((int)breakable3Position.X, (int)breakable3Position.Y, breakableSprite.Width, breakableSprite.Height);
            Rectangle breakable4Rect = new Rectangle((int)breakable4Position.X, (int)breakable4Position.Y, breakableSprite.Width, breakableSprite.Height);
            Rectangle breakable5Rect = new Rectangle((int)breakable5Position.X, (int)breakable5Position.Y, breakableSprite.Width, breakableSprite.Height);
            Rectangle breakable6Rect = new Rectangle((int)breakable6Position.X, (int)breakable6Position.Y, breakableSprite.Width, breakableSprite.Height);
            Rectangle breakable7Rect = new Rectangle((int)breakable7Position.X, (int)breakable7Position.Y, breakableSprite.Width, breakableSprite.Height);
            Rectangle breakable8Rect = new Rectangle((int)breakable8Position.X, (int)breakable8Position.Y, breakableSprite.Width, breakableSprite.Height);

            // Rectangles for enemies.
            Rectangle enemy1Rect = new Rectangle((int)enemy1Position.X, (int)enemy1Position.Y, enemySprite.Width, enemySprite.Height);
            Rectangle enemy2Rect = new Rectangle((int)enemy2Position.X, (int)enemy2Position.Y, enemySprite.Width, enemySprite.Height);
            Rectangle enemy3Rect = new Rectangle((int)enemy3Position.X, (int)enemy3Position.Y, enemySprite.Width, enemySprite.Height);
            #endregion

            // Update enemy movment based on velocity.
            enemy1Position += enemy1Velocity;
            enemy2Position += enemy2Velocity;
            enemy3Position += enemy3Velocity;

            // Set window name.
            Window.Title = "./JUMPER/";

            #region Game state specific code.
            switch (gameState)
            {
                case GameState.MainMenu:
                    // Change music to correct pitch (incase coming from "game over").
                    musicInstance.Pitch = 0;
                    // Reset player lives incase player came to menu using "M".
                    playerLives = 3;

                    // Play a sound and show tutorial if space is pressed.
                    if (keyboard.IsKeyDown(Keys.Space) && spacePressed == false)
                    {
                        soundSelect.Play();
                        // Prevent repeat until space is released.
                        spacePressed = true;
                        gameState = GameState.Tutorial;
                    }
                    // Play sound and show credits if C is pressed.
                    if (keyboard.IsKeyDown(Keys.C))
                    {
                        soundSelect.Play();
                        gameState = GameState.Credits;
                    }
                    break;

                case GameState.Credits:
                    // Change music to correct pitch (incase coming from "win").
                    musicInstance.Pitch = 0;
                    // Play sound and show main menu if space is pressed.
                    if (keyboard.IsKeyDown(Keys.Space) && spacePressed == false)
                    {
                        soundSelect.Play();
                        // Prevent repeat until space is released.
                        spacePressed = true;
                        gameState = GameState.MainMenu;
                    }
                    break;

                case GameState.Tutorial:
                    // Play sound and play Game if space is pressed.
                    if (keyboard.IsKeyDown(Keys.Space) && spacePressed == false)
                    {
                        soundSelect.Play();
                        // Prevent repeat until space is released.
                        spacePressed = true;
                        gameState = GameState.Tutorial2;
                    }
                    break;

                case GameState.Tutorial2:
                    // Play sound and play Game if space is pressed.
                    if (keyboard.IsKeyDown(Keys.Space) && spacePressed == false)
                    {
                        soundSelect.Play();
                        // Prevent repeat until space is released.
                        spacePressed = true;
                        gameState = GameState.preLevel1;
                    }
                    break;

                case GameState.preLevel1:
                    /// Position objects in right locations before starting level 1
                    // Move player to next level's starting position.
                    playerPosition = new Vector2(20, 63);
                    // Make sure player isn't moving.
                    playerVelocity = new Vector2(0, 0);

                    // Door position.
                    doorPosition = new Vector2(255, 307);

                    // Key 1 Position.
                    key1Position = new Vector2(350, 130);
                    // Key 2 Position.
                    key2Position = new Vector2(425, 240);
                    // Key 3 Position.
                    key3Position = new Vector2(75, 230);
                    // Key 1 shown?
                    key1Shown = true;
                    // Key 2 shown?
                    key2Shown = true;
                    // Key 3 shown?
                    key3Shown = true;
                    // Reset keys gathered
                    keysGathered = 0;

                    // Make sure Breaking blocks are shown.
                    breakable1Shown = true;
                    breakable2Shown = true;
                    breakable3Shown = true;
                    breakable4Shown = true;
                    breakable5Shown = true;
                    breakable6Shown = false;
                    breakable7Shown = false;
                    breakable8Shown = false;

                    // Reset timers and make sure breaking blocks aren't breaking.
                    breakable1Timer = 70;
                    breakable2Timer = 70;
                    breakable3Timer = 70;
                    breakable4Timer = 70;
                    breakable5Timer = 70;
                    breakable1Break = false;
                    breakable2Break = false;
                    breakable3Break = false;
                    breakable4Break = false;
                    breakable5Break = false;


                    // Poisition breaking blocks.
                    breakable1Position = new Vector2(69, 268);
                    breakable2Position = new Vector2(633, 172);
                    breakable3Position = new Vector2(658, 172);
                    breakable4Position = new Vector2(683, 172);
                    breakable5Position = new Vector2(708, 172);

                    // Position of enemies.
                    enemy1Position = new Vector2(280, 147);

                    // Set time left to complete level.
                    timeLeft = 60;

                    // Change to level 1
                    gameState = GameState.Level1;
                    break;

                case GameState.Level1:
                    /// Level 1 code.
                    #region Platform rectangles for collision detection.
                    foreach (Platform platform in platforms1)
                        if (playerRect.isOnTopOff(platform.rectangle))
                        {
                            playerAirborne = false;
                            playerVelocity.Y = 0;
                        }
                    foreach (Platform platform in platforms1)
                        if (playerRect.isOnLeft(platform.rectangle))
                        {
                            playerVelocity.X = 0f;
                            playerPosition.X--;
                        }
                    foreach (Platform platform in platforms1)
                        if (playerRect.isOnRight(platform.rectangle))
                        {
                            playerVelocity.X = 0f;
                            playerPosition.X++;
                        }
                    foreach (Platform platform in platforms1)
                        if (playerRect.isOnBottom(platform.rectangle))
                        {
                            playerVelocity.Y = 0;
                            playerPosition.Y++;
                        }
                    #endregion

                    // Timer counting down seconds left.
                    timeLeft = MathHelper.Max(0, timeLeft - (float)gameTime.ElapsedGameTime.TotalSeconds);
                    // Kill player if time's up.
                    if (timeLeft <= 0)
                    {
                        soundHurt.Play();
                        playerLives--;
                        gameState = GameState.preLevel1;
                    }
                    // Check if player is touching door and go to next level if player has all keys.
                    if (playerRect.Intersects(doorRect) && keysGathered == 3)
                    {
                        soundNextLevel.Play();
                        gameState = GameState.preLevel2;

                    }

                    // Kill on contact with taser block.
                    foreach (Platform platform in tasers1)
                        if (playerRect.Intersects(platform.rectangle))
                        {
                            soundHurt.Play();
                            playerLives--;
                            gameState = GameState.preLevel1;
                        }

                    // Kill on enemy contact.
                    if (playerRect.Intersects(enemy1Rect))
                    {
                        soundHurt.Play();
                        gameState = GameState.preLevel1;
                        playerLives--;
                    }
                    // Enemy movment.
                    if (enemy1Position.X <= 118)
                    {
                        enemy1Velocity.X = 4;
                    }
                    else if (enemy1Position.X >= 583-enemySprite.Width)
                    {
                        enemy1Velocity.X = -4;
                    }

                    #region Breaking block 1 collisions detection.
                        if (breakable1Shown == true)
                        {
                        if (playerRect.isOnTopOff(breakable1Rect))
                        {
                            playerAirborne = false;
                            playerVelocity.Y = 0;
                            breakable1Break = true;
                        }
                        if (playerRect.isOnLeft(breakable1Rect))
                        {
                            playerVelocity.X = 0f;
                            playerPosition.X--;
                            breakable1Break = true;
                        }
                        if (playerRect.isOnRight(breakable1Rect))
                        {
                            playerVelocity.X = 0f;
                            playerPosition.X++;
                            breakable1Break = true;
                        }
                        if (playerRect.isOnBottom(breakable1Rect))
                        {
                            playerVelocity.Y = 0;
                            playerPosition.Y++;
                            breakable1Break = true;
                        }
                    }
                    #endregion
                    #region Breaking block 2 collisions detection.
                    if (breakable2Shown == true)
                    {
                        if (playerRect.isOnTopOff(breakable2Rect))
                        {
                            playerAirborne = false;
                            playerVelocity.Y = 0;
                            breakable2Break = true;
                        }
                        if (playerRect.isOnLeft(breakable2Rect))
                        {
                            playerVelocity.X = 0f;
                            playerPosition.X--;
                            breakable2Break = true;
                        }
                        if (playerRect.isOnRight(breakable2Rect))
                        {
                            playerVelocity.X = 0f;
                            playerPosition.X++;
                            breakable2Break = true;
                        }
                        if (playerRect.isOnBottom(breakable2Rect))
                        {
                            playerVelocity.Y = 0;
                            playerPosition.Y++;
                            breakable2Break = true;
                        }
                    }
                    #endregion
                    #region Breaking block 3 collisions detection.
                    if (breakable3Shown == true)
                    {
                        if (playerRect.isOnTopOff(breakable3Rect))
                        {
                            playerAirborne = false;
                            playerVelocity.Y = 0;
                            breakable3Break = true;
                        }
                        if (playerRect.isOnLeft(breakable3Rect))
                        {
                            playerVelocity.X = 0f;
                            playerPosition.X--;
                            breakable3Break = true;
                        }
                        if (playerRect.isOnRight(breakable3Rect))
                        {
                            playerVelocity.X = 0f;
                            playerPosition.X++;
                            breakable3Break = true;
                        }
                        if (playerRect.isOnBottom(breakable3Rect))
                        {
                            playerVelocity.Y = 0;
                            playerPosition.Y++;
                            breakable3Break = true;
                        }
                    }
                    #endregion
                    #region Breaking block 4 collisions detection.
                    if (breakable4Shown == true)
                    {
                        if (playerRect.isOnTopOff(breakable4Rect))
                        {
                            playerAirborne = false;
                            playerVelocity.Y = 0;
                            breakable4Break = true;
                        }
                        if (playerRect.isOnLeft(breakable4Rect))
                        {
                            playerVelocity.X = 0f;
                            playerPosition.X--;
                            breakable4Break = true;
                        }
                        if (playerRect.isOnRight(breakable4Rect))
                        {
                            playerVelocity.X = 0f;
                            playerPosition.X++;
                            breakable4Break = true;
                        }
                        if (playerRect.isOnBottom(breakable4Rect))
                        {
                            playerVelocity.Y = 0;
                            playerPosition.Y++;
                            breakable4Break = true;
                        }
                    }
                    #endregion
                    #region Breaking block 5 collisions detection.
                    if (breakable5Shown == true)
                    {
                        if (playerRect.isOnTopOff(breakable5Rect))
                        {
                            playerAirborne = false;
                            playerVelocity.Y = 0;
                            breakable5Break = true;
                        }
                        if (playerRect.isOnLeft(breakable5Rect))
                        {
                            playerVelocity.X = 0f;
                            playerPosition.X--;
                            breakable5Break = true;
                        }
                        if (playerRect.isOnRight(breakable5Rect))
                        {
                            playerVelocity.X = 0f;
                            playerPosition.X++;
                            breakable5Break = true;
                        }
                        if (playerRect.isOnBottom(breakable5Rect))
                        {
                            playerVelocity.Y = 0;
                            playerPosition.Y++;
                            breakable5Break = true;
                        }
                    }
                    #endregion

                    #region Code for actual breaking of breaking block 1 
                    // Activate timer if block is breaking.
                    if (breakable1Break == true)
                    {
                        breakable1Timer--;
                    }
                    // Hide block if timer reaches 0.
                    if (breakable1Timer <= 0)
                    {
                        breakable1Shown = false;
                    }
                    // Respawn block if player isn't intersecting.
                    if (breakable1Timer <= -400)
                    {
                        if (playerRect.Intersects(breakable1Rect))
                        { }
                        else
                        {

                            breakable1Break = false;
                            breakable1Timer = 70;
                            breakable1Shown = true;
                        }
                    }
                    #endregion
                    #region Code for actual breaking of breaking block 2 
                    // Activate timer if block is breaking.
                    if (breakable2Break == true)
                    {
                        breakable2Timer--;
                    }
                    // Hide block if timer reaches 0.
                    if (breakable2Timer <= 0)
                    {
                        breakable2Shown = false;
                    }
                    // Respawn block if player isn't intersecting.
                    if (breakable2Timer <= -400)
                    {
                        if (playerRect.Intersects(breakable2Rect))
                        { }
                        else
                        {

                            breakable2Break = false;
                            breakable2Timer = 70;
                            breakable2Shown = true;
                        }
                    }
                    #endregion
                    #region Code for actual breaking of breaking block 3 
                    // Activate timer if block is breaking.
                    if (breakable3Break == true)
                    {
                        breakable3Timer--;
                    }
                    // Hide block if timer reaches 0.
                    if (breakable3Timer <= 0)
                    {
                        breakable3Shown = false;
                    }
                    // Respawn block if player isn't intersecting.
                    if (breakable3Timer <= -400)
                    {
                        if (playerRect.Intersects(breakable3Rect))
                        { }
                        else
                        {

                            breakable3Break = false;
                            breakable3Timer = 70;
                            breakable3Shown = true;
                        }
                    }
                    #endregion
                    #region Code for actual breaking of breaking block 4 
                    // Activate timer if block is breaking.
                    if (breakable4Break == true)
                    {
                        breakable4Timer--;
                    }
                    // Hide block if timer reaches 0.
                    if (breakable4Timer <= 0)
                    {
                        breakable4Shown = false;
                    }
                    // Respawn block if player isn't intersecting.
                    if (breakable4Timer <= -400)
                    {
                        if (playerRect.Intersects(breakable4Rect))
                        { }
                        else
                        {

                            breakable4Break = false;
                            breakable4Timer = 70;
                            breakable4Shown = true;
                        }
                    }
                    #endregion
                    #region Code for actual breaking of breaking block 5 
                    // Activate timer if block is breaking.
                    if (breakable5Break == true)
                    {
                        breakable5Timer--;
                    }
                    // Hide block if timer reaches 0.
                    if (breakable5Timer <= 0)
                    {
                        breakable5Shown = false;
                    }
                    // Respawn block if player isn't intersecting.
                    if (breakable5Timer <= -500)
                    {
                        if (playerRect.Intersects(breakable5Rect))
                        { }
                        else
                        {

                            breakable5Break = false;
                            breakable5Timer = 70;
                            breakable5Shown = true;
                        }
                    }
                    #endregion


                    // Give point if key 1 is taken-
                    if (playerRect.Intersects(key1Rect) && key1Shown == true)
                    {
                        // PLay pick up sound.
                        soundPickUp.Play();
                        // Hide key.
                        key1Shown = false;
                        // Give point.
                        keysGathered++;
                        // Increase time left to finish level.
                        timeLeft += 30;
                    }
                    // Give point if key 2 is taken-
                    if (playerRect.Intersects(key2Rect) && key2Shown == true)
                    {
                        // PLay pick up sound.
                        soundPickUp.Play();
                        // Hide key.
                        key2Shown = false;
                        // Give point.
                        keysGathered++;
                        // Increase time left to finish level.
                        timeLeft += 30;
                    }
                    // Give point if key 3 is taken-
                    if (playerRect.Intersects(key3Rect) && key3Shown == true)
                    {
                        // PLay pick up sound.
                        soundPickUp.Play();
                        // Hide key.
                        key3Shown = false;
                        // Give point.
                        keysGathered++;
                        // Increase time left to finish level.
                        timeLeft += 30;
                    }
                    break;

                case GameState.preLevel2:
                    /// Position objects in right locations before starting level 2
                    // Move player to next levels starting position.
                    playerPosition = new Vector2(482, 11);
                    // Make sure player isn't moving.
                    playerVelocity = new Vector2(0, 0);
                    // Door Position
                    doorPosition = new Vector2(350, 326);
                    // Key 1 Position
                    key1Position = new Vector2(780, 107);
                    // Key 2 Position
                    key2Position = new Vector2(109, 48);
                    // Key 3 Position
                    key3Position = new Vector2(584, 253);
                    // Key 1 shown?
                    key1Shown = true;
                    // Key 2 shown?
                    key2Shown = true;
                    // Key 3 shown?
                    key3Shown = true;
                    // Reset keys gathered
                    keysGathered = 0;


                    // Make sure breaking blocks are shown.
                    breakable1Shown = true;
                    breakable2Shown = true;
                    breakable3Shown = false;
                    breakable4Shown = false;
                    breakable5Shown = false;
                    breakable6Shown = false;
                    breakable7Shown = false;
                    breakable8Shown = false;

                    // Reset timers and make sure breaking blocks aren't breaking.
                    breakable1Timer = 70;
                    breakable2Timer = 70;
                    breakable1Break = false;
                    breakable2Break = false;

                    // Position breaking blocks.
                    breakable1Position = new Vector2(525, 38);
                    breakable2Position = new Vector2(478, 110);


                    // Position of enemies.
                    enemy1Position = new Vector2(209, 184);
                    enemy1Velocity.X = 3;
                    enemy2Position = new Vector2(508, 264);
                    enemy2Velocity.X = 2;
                    enemy3Position = new Vector2(900, 900);

                    // Set time left to complete level
                    timeLeft = 60;

                    // Change to level 2
                    gameState = GameState.Level2;
                    break;

                case GameState.Level2:
                    #region Platform rectangles for collision detection.
                    foreach (Platform platform in platforms2)
                        if (playerRect.isOnTopOff(platform.rectangle))
                        {
                            playerAirborne = false;
                            playerVelocity.Y = 0;
                        }
                    foreach (Platform platform in platforms2)
                        if (playerRect.isOnLeft(platform.rectangle))
                        {
                            playerVelocity.X = 0f;
                            playerPosition.X--;
                        }
                    foreach (Platform platform in platforms2)
                        if (playerRect.isOnRight(platform.rectangle))
                        {
                            playerVelocity.X = 0f;
                            playerPosition.X++;
                        }
                    foreach (Platform platform in platforms2)
                        if (playerRect.isOnBottom(platform.rectangle))
                        {
                            playerVelocity.Y = 0;
                            playerPosition.Y++;
                        }
                    #endregion

                    // Timer counting down seconds left.
                    timeLeft = MathHelper.Max(0, timeLeft - (float)gameTime.ElapsedGameTime.TotalSeconds);
                    // Kill player if time's up.
                    if (timeLeft <= 0)
                    {
                        soundHurt.Play();
                        playerLives--;
                        gameState = GameState.preLevel2;
                    }
                    // Check if player is touching door and go to next level if player has all keys.
                    if (playerRect.Intersects(doorRect) && keysGathered == 3)
                    {
                        soundNextLevel.Play();
                        gameState = GameState.preLevel3;
                    }
                    // Give point if and increase time left key 2 is taken.
                    if (playerRect.Intersects(key1Rect) && key1Shown == true)
                    {
                        // Play pick up sound.
                        soundPickUp.Play();
                        key1Shown = false;
                        keysGathered++;
                        timeLeft += 20;
                    }
                    // Give point and increase time left if key 2 is taken.
                    if (playerRect.Intersects(key2Rect) && key2Shown == true)
                    {
                        // Play pick up sound.
                        soundPickUp.Play();
                        key2Shown = false;
                        keysGathered++;
                        timeLeft += 20;
                    }
                    // Give point and increase time left if key 3 is taken.
                    if (playerRect.Intersects(key3Rect) && key3Shown == true)
                    {
                        // Play pick up sound.
                        soundPickUp.Play();
                        key3Shown = false;
                        keysGathered++;
                        timeLeft += 20;
                    }

                    #region Breaking block 1 collisions detection.
                    if (breakable1Shown == true)
                    {
                        if (playerRect.isOnTopOff(breakable1Rect))
                        {
                            playerAirborne = false;
                            playerVelocity.Y = 0;
                            breakable1Break = true;
                        }
                        if (playerRect.isOnLeft(breakable1Rect))
                        {
                            playerVelocity.X = 0f;
                            playerPosition.X--;
                            breakable1Break = true;
                        }
                        if (playerRect.isOnRight(breakable1Rect))
                        {
                            playerVelocity.X = 0f;
                            playerPosition.X++;
                            breakable1Break = true;
                        }
                        if (playerRect.isOnBottom(breakable1Rect))
                        {
                            playerVelocity.Y = 0;
                            playerPosition.Y++;
                            breakable1Break = true;
                        }
                    }
                    #endregion
                    #region Breaking block 2 collisions detection.
                    if (breakable2Shown == true)
                    {
                        if (playerRect.isOnTopOff(breakable2Rect))
                        {
                            playerAirborne = false;
                            playerVelocity.Y = 0;
                            breakable2Break = true;
                        }
                        if (playerRect.isOnLeft(breakable2Rect))
                        {
                            playerVelocity.X = 0f;
                            playerPosition.X--;
                            breakable2Break = true;
                        }
                        if (playerRect.isOnRight(breakable2Rect))
                        {
                            playerVelocity.X = 0f;
                            playerPosition.X++;
                            breakable2Break = true;
                        }
                        if (playerRect.isOnBottom(breakable2Rect))
                        {
                            playerVelocity.Y = 0;
                            playerPosition.Y++;
                            breakable2Break = true;
                        }
                    }
                    #endregion

                    #region Code for actual breaking of breaking block 1 
                    // Activate timer if block is breaking.
                    if (breakable1Break == true)
                    {
                        breakable1Timer--;
                    }
                    // Hide block if timer reaches 0.
                    if (breakable1Timer <= 0)
                    {
                        breakable1Shown = false;
                    }
                    // Respawn block if player isn't intersecting.
                    if (breakable1Timer <= -400)
                    {
                        if (playerRect.Intersects(breakable1Rect))
                        { }
                        else
                        {

                            breakable1Break = false;
                            breakable1Timer = 70;
                            breakable1Shown = true;
                        }
                    }
                    #endregion
                    #region Code for actual breaking of breaking block 2 
                    // Activate timer if block is breaking.
                    if (breakable2Break == true)
                    {
                        breakable2Timer--;
                    }
                    // Hide block if timer reaches 0.
                    if (breakable2Timer <= 0)
                    {
                        breakable2Shown = false;
                    }
                    // Respawn block if player isn't intersecting.
                    if (breakable2Timer <= -400)
                    {
                        if (playerRect.Intersects(breakable2Rect))
                        { }
                        else
                        {

                            breakable2Break = false;
                            breakable2Timer = 70;
                            breakable2Shown = true;
                        }
                    }
                    #endregion

                    // Play sound and kill on contact with taser.
                    foreach (Platform platform in tasers2)
                        if (playerRect.Intersects(platform.rectangle))
                        {
                            soundHurt.Play();
                            playerLives--;
                            gameState = GameState.preLevel2;
                        }

                    // Kill player on enemy contact.
                    if (playerRect.Intersects(enemy1Rect) || playerRect.Intersects(enemy2Rect))
                    {
                        soundHurt.Play();
                        gameState = GameState.preLevel2;
                        playerLives--;
                    }

                    // Enemy movment.
                    if (enemy1Position.X <= 139)
                    {
                        enemy1Velocity.X = 3;
                    }
                    else if (enemy1Position.X >= 329 - enemySprite.Width)
                    {
                        enemy1Velocity.X = -3;
                    }
                    if (enemy2Position.X <= 425)
                    {
                        enemy2Velocity.X = 2;
                    }
                    else if (enemy2Position.X >= 614 - enemySprite.Width)
                    {
                        enemy2Velocity.X = -2;
                    }
                    break;

                case GameState.preLevel3:
                    /// Position objects in right locations before starting level 3
                    // Move player to next levels starting position.
                    playerPosition = new Vector2(27, 365);
                    // Make sure player isn't moving.
                    playerVelocity = new Vector2(0, 0);
                    // Door Position.
                    doorPosition = new Vector2(773, 305);
                    // Key 1 Position.
                    key1Position = new Vector2(410, 337);
                    // Key 2 Position.
                    key2Position = new Vector2(147, 210);
                    // Key 3 Position.
                    key3Position = new Vector2(778, 127);
                    // Key 1 shown?
                    key1Shown = true;
                    // Key 2 shown?
                    key2Shown = true;
                    // Key 3 shown?
                    key3Shown = true;
                    // Reset keys gathered.
                    keysGathered = 0;

                    // Make sure Breaking blocks are shown.
                    breakable1Shown = true;
                    breakable2Shown = true;
                    breakable3Shown = true;
                    breakable4Shown = true;
                    breakable5Shown = true;
                    breakable6Shown = true;
                    breakable7Shown = true;
                    breakable8Shown = true;

                    // Reset timers and make sure breaking blocks aren't breaking.
                    breakable1Timer = 70;
                    breakable2Timer = 70;
                    breakable3Timer = 70;
                    breakable4Timer = 70;
                    breakable5Timer = 70;
                    breakable6Timer = 70;
                    breakable7Timer = 70;
                    breakable8Timer = 70;
                    breakable1Break = false;
                    breakable2Break = false;
                    breakable3Break = false;
                    breakable4Break = false;
                    breakable5Break = false;
                    breakable6Break = false;
                    breakable7Break = false;
                    breakable8Break = false;

                    // Poisition breaking blocks.
                    breakable1Position = new Vector2(673, 309);
                    breakable2Position = new Vector2(356, 261);
                    breakable3Position = new Vector2(221, 261);
                    breakable4Position = new Vector2(269, 235);
                    breakable5Position = new Vector2(209, 204);
                    breakable6Position = new Vector2(559, 153);
                    breakable7Position = new Vector2(633, 153);
                    breakable8Position = new Vector2(706, 153);

                    // Position of enemies.
                    enemy1Position = new Vector2(203, 367);
                    enemy2Position = new Vector2(408, 367);
                    enemy3Position = new Vector2(612, 367);

                    // Set time left to complete level.
                    timeLeft = 30;

                    // Change to level 3.
                    gameState = GameState.Level3;
                    break;

                case GameState.Level3:
                    #region Platform rectangles for collision detection.
                    foreach (Platform platform in platforms3)
                        if (playerRect.isOnTopOff(platform.rectangle))
                        {
                            playerAirborne = false;
                            playerVelocity.Y = 0;
                        }
                    foreach (Platform platform in platforms3)
                        if (playerRect.isOnLeft(platform.rectangle))
                        {
                            playerVelocity.X = 0f;
                            playerPosition.X--;
                        }
                    foreach (Platform platform in platforms3)
                        if (playerRect.isOnRight(platform.rectangle))
                        {
                            playerVelocity.X = 0f;
                            playerPosition.X++;
                        }
                    foreach (Platform platform in platforms3)
                        if (playerRect.isOnBottom(platform.rectangle))
                        {
                            playerVelocity.Y = 0;
                            playerPosition.Y++;
                        }
                    #endregion

                    // Timer counting down seconds left.
                    timeLeft = MathHelper.Max(0, timeLeft - (float)gameTime.ElapsedGameTime.TotalSeconds);
                    // Kill player if time's up.
                    if (timeLeft <= 0)
                    {
                        soundHurt.Play();
                        playerLives--;
                        gameState = GameState.preLevel3;
                    }
                    // Check if player is touching door and go to next level if player has all keys.
                    if (playerRect.Intersects(doorRect) && keysGathered == 3)
                    {
                        soundWin.Play();
                        gameState = GameState.Win;
                    }
                    // Give point if and increase time left key 1 is taken.
                    if (playerRect.Intersects(key1Rect) && key1Shown == true)
                    {
                        // Play pick up sound.
                        soundPickUp.Play();
                        key1Shown = false;
                        keysGathered++;
                        timeLeft += 20;
                    }
                    // Give point if and increase time left key 2 is taken.
                    if (playerRect.Intersects(key2Rect) && key2Shown == true)
                    {
                        // Play pick up sound.
                        soundPickUp.Play();
                        key2Shown = false;
                        keysGathered++;
                        timeLeft += 20;
                    }
                    // Give point if and increase time left key 3 is taken.
                    if (playerRect.Intersects(key3Rect) && key3Shown == true)
                    {
                        // Play pick up sound.
                        soundPickUp.Play();
                        key3Shown = false;
                        keysGathered++;
                        timeLeft += 20;
                    }

                    #region Breaking block 1 collisions detection.
                    if (breakable1Shown == true)
                        {
                            if (playerRect.isOnTopOff(breakable1Rect))
                            {
                                playerAirborne = false;
                                playerVelocity.Y = 0;
                                breakable1Break = true;
                            }
                            if (playerRect.isOnLeft(breakable1Rect))
                            {
                                playerVelocity.X = 0f;
                                playerPosition.X--;
                                breakable1Break = true;
                            }
                            if (playerRect.isOnRight(breakable1Rect))
                            {
                                playerVelocity.X = 0f;
                                playerPosition.X++;
                                breakable1Break = true;
                            }
                            if (playerRect.isOnBottom(breakable1Rect))
                            {
                                playerVelocity.Y = 0;
                                playerPosition.Y++;
                                breakable1Break = true;
                            }
                        }
                        #endregion
                    #region Breaking block 2 collisions detection.
                        if (breakable2Shown == true)
                        {
                            if (playerRect.isOnTopOff(breakable2Rect))
                            {
                                playerAirborne = false;
                                playerVelocity.Y = 0;
                                breakable2Break = true;
                            }
                            if (playerRect.isOnLeft(breakable2Rect))
                            {
                                playerVelocity.X = 0f;
                                playerPosition.X--;
                                breakable2Break = true;
                            }
                            if (playerRect.isOnRight(breakable2Rect))
                            {
                                playerVelocity.X = 0f;
                                playerPosition.X++;
                                breakable2Break = true;
                            }
                            if (playerRect.isOnBottom(breakable2Rect))
                            {
                                playerVelocity.Y = 0;
                                playerPosition.Y++;
                                breakable2Break = true;
                            }
                        }
                        #endregion
                    #region Breaking block 3 collisions detection.
                        if (breakable3Shown == true)
                        {
                            if (playerRect.isOnTopOff(breakable3Rect))
                            {
                                playerAirborne = false;
                                playerVelocity.Y = 0;
                                breakable3Break = true;
                            }
                            if (playerRect.isOnLeft(breakable3Rect))
                            {
                                playerVelocity.X = 0f;
                                playerPosition.X--;
                                breakable3Break = true;
                            }
                            if (playerRect.isOnRight(breakable3Rect))
                            {
                                playerVelocity.X = 0f;
                                playerPosition.X++;
                                breakable3Break = true;
                            }
                            if (playerRect.isOnBottom(breakable3Rect))
                            {
                                playerVelocity.Y = 0;
                                playerPosition.Y++;
                                breakable3Break = true;
                            }
                        }
                        #endregion
                    #region Breaking block 4 collisions detection.
                        if (breakable4Shown == true)
                        {
                            if (playerRect.isOnTopOff(breakable4Rect))
                            {
                                playerAirborne = false;
                                playerVelocity.Y = 0;
                                breakable4Break = true;
                            }
                            if (playerRect.isOnLeft(breakable4Rect))
                            {
                                playerVelocity.X = 0f;
                                playerPosition.X--;
                                breakable4Break = true;
                            }
                            if (playerRect.isOnRight(breakable4Rect))
                            {
                                playerVelocity.X = 0f;
                                playerPosition.X++;
                                breakable4Break = true;
                            }
                            if (playerRect.isOnBottom(breakable4Rect))
                            {
                                playerVelocity.Y = 0;
                                playerPosition.Y++;
                                breakable4Break = true;
                            }
                        }
                        #endregion
                    #region Breaking block 5 collisions detection.
                        if (breakable5Shown == true)
                        {
                            if (playerRect.isOnTopOff(breakable5Rect))
                            {
                                playerAirborne = false;
                                playerVelocity.Y = 0;
                                breakable5Break = true;
                            }
                            if (playerRect.isOnLeft(breakable5Rect))
                            {
                                playerVelocity.X = 0f;
                                playerPosition.X--;
                                breakable5Break = true;
                            }
                            if (playerRect.isOnRight(breakable5Rect))
                            {
                                playerVelocity.X = 0f;
                                playerPosition.X++;
                                breakable5Break = true;
                            }
                            if (playerRect.isOnBottom(breakable5Rect))
                            {
                                playerVelocity.Y = 0;
                                playerPosition.Y++;
                                breakable5Break = true;
                            }
                        }
                    #endregion
                    #region Breaking block 6 collisions detection.
                    if (breakable6Shown == true)
                    {
                        if (playerRect.isOnTopOff(breakable6Rect))
                        {
                            playerAirborne = false;
                            playerVelocity.Y = 0;
                            breakable6Break = true;
                        }
                        if (playerRect.isOnLeft(breakable6Rect))
                        {
                            playerVelocity.X = 0f;
                            playerPosition.X--;
                            breakable6Break = true;
                        }
                        if (playerRect.isOnRight(breakable6Rect))
                        {
                            playerVelocity.X = 0f;
                            playerPosition.X++;
                            breakable6Break = true;
                        }
                        if (playerRect.isOnBottom(breakable6Rect))
                        {
                            playerVelocity.Y = 0;
                            playerPosition.Y++;
                            breakable6Break = true;
                        }
                    }
                    #endregion
                    #region Breaking block 7 collisions detection.
                    if (breakable7Shown == true)
                    {
                        if (playerRect.isOnTopOff(breakable7Rect))
                        {
                            playerAirborne = false;
                            playerVelocity.Y = 0;
                            breakable7Break = true;
                        }
                        if (playerRect.isOnLeft(breakable7Rect))
                        {
                            playerVelocity.X = 0f;
                            playerPosition.X--;
                            breakable7Break = true;
                        }
                        if (playerRect.isOnRight(breakable7Rect))
                        {
                            playerVelocity.X = 0f;
                            playerPosition.X++;
                            breakable7Break = true;
                        }
                        if (playerRect.isOnBottom(breakable7Rect))
                        {
                            playerVelocity.Y = 0;
                            playerPosition.Y++;
                            breakable7Break = true;
                        }
                    }
                    #endregion
                    #region Breaking block 8 collisions detection.
                    if (breakable8Shown == true)
                    {
                        if (playerRect.isOnTopOff(breakable8Rect))
                        {
                            playerAirborne = false;
                            playerVelocity.Y = 0;
                            breakable8Break = true;
                        }
                        if (playerRect.isOnLeft(breakable8Rect))
                        {
                            playerVelocity.X = 0f;
                            playerPosition.X--;
                            breakable8Break = true;
                        }
                        if (playerRect.isOnRight(breakable8Rect))
                        {
                            playerVelocity.X = 0f;
                            playerPosition.X++;
                            breakable8Break = true;
                        }
                        if (playerRect.isOnBottom(breakable8Rect))
                        {
                            playerVelocity.Y = 0;
                            playerPosition.Y++;
                            breakable8Break = true;
                        }
                    }
                    #endregion

                    #region Code for actual breaking of breaking block 1 
                    // Activate timer if block is breaking.
                    if (breakable1Break == true)
                    {
                        breakable1Timer--;
                    }
                    // Hide block if timer reaches 0.
                    if (breakable1Timer <= 0)
                    {
                        breakable1Shown = false;
                    }
                    // Respawn block if player isn't intersecting.
                    if (breakable1Timer <= -400)
                    {
                        if (playerRect.Intersects(breakable1Rect))
                        { }
                        else
                        {

                            breakable1Break = false;
                            breakable1Timer = 70;
                            breakable1Shown = true;
                        }
                    }
                    #endregion
                    #region Code for actual breaking of breaking block 2 
                    // Activate timer if block is breaking.
                    if (breakable2Break == true)
                    {
                        breakable2Timer--;
                    }
                    // Hide block if timer reaches 0.
                    if (breakable2Timer <= 0)
                    {
                        breakable2Shown = false;
                    }
                    // Respawn block if player isn't intersecting.
                    if (breakable2Timer <= -400)
                    {
                        if (playerRect.Intersects(breakable2Rect))
                        { }
                        else
                        {

                            breakable2Break = false;
                            breakable2Timer = 70;
                            breakable2Shown = true;
                        }
                    }
                    #endregion
                    #region Code for actual breaking of breaking block 3 
                    // Activate timer if block is breaking.
                    if (breakable3Break == true)
                    {
                        breakable3Timer--;
                    }
                    // Hide block if timer reaches 0.
                    if (breakable3Timer <= 0)
                    {
                        breakable3Shown = false;
                    }
                    // Respawn block if player isn't intersecting.
                    if (breakable3Timer <= -400)
                    {
                        if (playerRect.Intersects(breakable3Rect))
                        { }
                        else
                        {

                            breakable3Break = false;
                            breakable3Timer = 70;
                            breakable3Shown = true;
                        }
                    }
                    #endregion
                    #region Code for actual breaking of breaking block 4 
                    // Activate timer if block is breaking.
                    if (breakable4Break == true)
                    {
                        breakable4Timer--;
                    }
                    // Hide block if timer reaches 0.
                    if (breakable4Timer <= 0)
                    {
                        breakable4Shown = false;
                    }
                    // Respawn block if player isn't intersecting.
                    if (breakable4Timer <= -400)
                    {
                        if (playerRect.Intersects(breakable4Rect))
                        { }
                        else
                        {

                            breakable4Break = false;
                            breakable4Timer = 70;
                            breakable4Shown = true;
                        }
                    }
                    #endregion
                    #region Code for actual breaking of breaking block 5 
                    // Activate timer if block is breaking.
                    if (breakable5Break == true)
                    {
                        breakable5Timer--;
                    }
                    // Hide block if timer reaches 0.
                    if (breakable5Timer <= 0)
                    {
                        breakable5Shown = false;
                    }
                    // Respawn block if player isn't intersecting.
                    if (breakable5Timer <= -500)
                    {
                        if (playerRect.Intersects(breakable5Rect))
                        { }
                        else
                        {

                            breakable5Break = false;
                            breakable5Timer = 70;
                            breakable5Shown = true;
                        }
                    }
                    #endregion
                    #region Code for actual breaking of breaking block 6
                    // Activate timer if block is breaking. 
                    if (breakable6Break == true)
                    {
                        breakable6Timer--;
                    }
                    // Hide block if timer reaches 0.
                    if (breakable6Timer <= 0)
                    {
                        breakable6Shown = false;
                    }
                    // Respawn block if player isn't intersecting.
                    if (breakable6Timer <= -400)
                    {
                        if (playerRect.Intersects(breakable6Rect))
                        {
                        }
                        else
                        {

                            breakable6Break = false;
                            breakable6Timer = 70;
                            breakable6Shown = true;
                        }
                    }
                    #endregion
                    #region Code for actual breaking of breaking block 7 
                    // Activate timer if block is breaking.
                    if (breakable7Break == true)
                    {
                        breakable7Timer--;
                    }
                    // Hide block if timer reaches 0.
                    if (breakable7Timer <= 0)
                    {
                        breakable7Shown = false;
                    }
                    // Respawn block if player isn't intersecting.
                    if (breakable7Timer <= -400)
                    {
                        if (playerRect.Intersects(breakable7Rect))
                        {
                        }
                        else
                        {

                            breakable7Break = false;
                            breakable7Timer = 70;
                            breakable7Shown = true;
                        }
                    }
                    #endregion
                    #region Code for actual breaking of breaking block 8 
                    // Activate timer if block is breaking.
                    if (breakable8Break == true)
                    {
                        breakable8Timer--;
                    }
                    // Hide block if timer reaches 0.
                    if (breakable8Timer <= 0)
                    {
                        breakable8Shown = false;
                    }
                    // Respawn block if player isn't intersecting.
                    if (breakable8Timer <= -400)
                    {
                        if (playerRect.Intersects(breakable8Rect))
                        {
                        }
                        else
                        {

                            breakable8Break = false;
                            breakable8Timer = 70;
                            breakable8Shown = true;
                        }
                    }
                    #endregion

                    // Play siund and kill player on contact with taser.
                    foreach (Platform platform in tasers3)
                        if (playerRect.Intersects(platform.rectangle))
                        {
                            soundHurt.Play();
                            playerLives--;
                            gameState = GameState.preLevel3;
                        }

                    // Kill player on enemy contact.
                    if (playerRect.Intersects(enemy1Rect) || playerRect.Intersects(enemy2Rect) || playerRect.Intersects(enemy3Rect))
                    {
                        soundHurt.Play();
                        gameState = GameState.preLevel3;
                        playerLives--;
                    }

                    // Enemy movment.
                    if (enemy1Position.X <= 133)
                    {
                        enemy1Velocity.X = 3;
                    }
                    else if (enemy1Position.X >= 298 - enemySprite.Width)
                    {
                        enemy1Velocity.X = -3;
                    }

                    if (enemy2Position.X <= 324)
                    {
                        enemy2Velocity.X = 3;
                    }
                    else if (enemy2Position.X >= 508 - enemySprite.Width)
                    {
                        enemy2Velocity.X = -3;
                    }

                    if (enemy3Position.X <= 534)
                    {
                        enemy3Velocity.X = 3;
                    }
                    else if (enemy3Position.X >= 699 - enemySprite.Width)
                    {
                        enemy3Velocity.X = -3;
                    }
                    break;
                case GameState.Win:
                    // PLay sound and show credits if space is pressed.
                    if (keyboard.IsKeyDown(Keys.Space) && spacePressed == false)
                    {
                        soundSelect.Play();
                        spacePressed = true;
                        gameState = GameState.Credits;
                    }
                    break;

                case GameState.GameOver:
                    // Lower music's pitch for *a nice effect*.
                    musicInstance.Pitch = -1F;
                    // Play sound and return to menu if space is pressed.
                    if (keyboard.IsKeyDown(Keys.Space) && spacePressed == false)
                    {
                        soundSelect.Play();
                        spacePressed = true;
                        gameState = GameState.MainMenu;
                    }
                    break;

            }
            #endregion



            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // Make the window's default color black.
            GraphicsDevice.Clear(Color.Black);

            // Start spritebatch.
            spriteBatch.Begin(0, BlendState.AlphaBlend);
            // Draw stuff specific to the Main Menu.
            if (gameState == GameState.MainMenu)
            {
                // Draw menu background.
                spriteBatch.Draw(menuBG, Vector2.Zero, Color.White);
            }
            // Draw stuff specific to "Credits"
            if (gameState == GameState.Credits)
            {
                // Draw credits background.
                spriteBatch.Draw(credits, Vector2.Zero, Color.White);
            }

            // Draw stuff specific to the Tutorial.
            if (gameState == GameState.Tutorial)
            {
                // Draw tutorial background.
                spriteBatch.Draw(tutorial, Vector2.Zero, Color.White);
            }

            // Draw stuff specific to the Tutorial2.
            if (gameState == GameState.Tutorial2)
            {
                // Draw second tutorial background.
                spriteBatch.Draw(tutorial2, Vector2.Zero, Color.White);
            }

            // Draw stuff specific to "level 1".
            if (gameState == GameState.Level1)
            {
                // Draw background.
                spriteBatch.Draw(levelBG, Vector2.Zero, Color.White);
                // Draw all platforms1 at once.
                foreach (Platform platform in platforms1)
                    platform.Draw(spriteBatch);

                // Draw the door.
                spriteBatch.Draw(doorSprite, doorPosition, Color.White);
                // Draw the player
                spriteBatch.Draw(playerSprite, playerPosition, Color.White);

                // Draw the first key if it should be shown.
                if (key1Shown == true)
                {
                    spriteBatch.Draw(keySprite, key1Position, Color.White);
                }
                // Draw the second key if it should be shown.
                if (key2Shown == true)
                {
                    spriteBatch.Draw(keySprite, key2Position, Color.White);
                }
                // Draw the third key if it should be shown.
                if (key3Shown == true)
                {
                    spriteBatch.Draw(keySprite, key3Position, Color.White);
                }

                // Draw all tasers at once.
                foreach (Platform platform in tasers1)
                    platform.Draw(spriteBatch);

                // Draw breaking blocks.
                if (breakable1Shown == true)
                {
                    spriteBatch.Draw(breakableSprite, breakable1Position, Color.White);
                }
                if (breakable2Shown == true)
                {
                    spriteBatch.Draw(breakableSprite, breakable2Position, Color.White);
                }
                if (breakable3Shown == true)
                {
                    spriteBatch.Draw(breakableSprite, breakable3Position, Color.White);
                }
                if (breakable4Shown == true)
                {
                    spriteBatch.Draw(breakableSprite, breakable4Position, Color.White);
                }
                if (breakable5Shown == true)
                {
                    spriteBatch.Draw(breakableSprite, breakable5Position, Color.White);
                }

                // Draw enemy.
                spriteBatch.Draw(enemySprite, enemy1Position, Color.White);

                // Draw player lives.
                spriteBatch.DrawString(kongtextFont, "Lives: " + playerLives.ToString(), new Vector2(25, 10), Color.White);
                // Draw time left.
                spriteBatch.DrawString(kongtextFont, "Time left: " + ((int)timeLeft).ToString(), new Vector2(630, 10), Color.White);

            }
            // Draw stuff specific to "level 2".
            if (gameState == GameState.Level2)
            {
                // Draw background.
                spriteBatch.Draw(levelBG, Vector2.Zero, Color.White);
                // Draw all platforms2 at once.
                foreach (Platform platform in platforms2)
                    platform.Draw(spriteBatch);


                // Draw the door.
                spriteBatch.Draw(doorSprite, doorPosition, Color.White);
                // Draw the player.
                spriteBatch.Draw(playerSprite, playerPosition, Color.White);
                // Draw the firts key if it should be shown.
                if (key1Shown == true)
                {
                    spriteBatch.Draw(keySprite, key1Position, Color.White);
                }
                // Draw the second key if it should be shown.
                if (key2Shown == true)
                {
                    spriteBatch.Draw(keySprite, key2Position, Color.White);
                }
                // Draw the third key if it should be shown.
                if (key3Shown == true)
                {
                    spriteBatch.Draw(keySprite, key3Position, Color.White);
                }

                // Draw all tasers at once.
                foreach (Platform platform in tasers2)
                    platform.Draw(spriteBatch);

                // Draw breaking blocks.
                if (breakable1Shown == true)
                {
                    spriteBatch.Draw(breakableSprite, breakable1Position, Color.White);
                }
                if (breakable2Shown == true)
                {
                    spriteBatch.Draw(breakableSprite, breakable2Position, Color.White);
                }
                if (breakable3Shown == true)
                {
                    spriteBatch.Draw(breakableSprite, breakable3Position, Color.White);
                }
                if (breakable4Shown == true)
                {
                    spriteBatch.Draw(breakableSprite, breakable4Position, Color.White);
                }
                if (breakable5Shown == true)
                {
                    spriteBatch.Draw(breakableSprite, breakable5Position, Color.White);
                }

                // Draw enemies.
                spriteBatch.Draw(enemySprite, enemy1Position, Color.White);
                spriteBatch.Draw(enemySprite, enemy2Position, Color.White);

                // Draw player lives.
                spriteBatch.DrawString(kongtextFont, "Lives: " + playerLives.ToString(), new Vector2(25, 10), Color.White);
                // Draw player lives.
                spriteBatch.DrawString(kongtextFont, "Time left: " + ((int)timeLeft).ToString(), new Vector2(630, 10), Color.White);
            }
            // Draw stuff specific to "level 3".
            if (gameState == GameState.Level3)
            {
                // Draw background.
                spriteBatch.Draw(levelBG, Vector2.Zero, Color.White);
                // Draw all platforms2 at once.
                foreach (Platform platform in platforms3)
                    platform.Draw(spriteBatch);


                // Draw the door.
                spriteBatch.Draw(doorSprite, doorPosition, Color.White);
                // Draw the player.
                spriteBatch.Draw(playerSprite, playerPosition, Color.White);
                // Draw the first key if it should be shown.
                if (key1Shown == true)
                {
                    spriteBatch.Draw(keySprite, key1Position, Color.White);
                }
                // Draw the second key if it should be shown.
                if (key2Shown == true)
                {
                    spriteBatch.Draw(keySprite, key2Position, Color.White);
                }
                // Draw the third key if it should be shown.
                if (key3Shown == true)
                {
                    spriteBatch.Draw(keySprite, key3Position, Color.White);
                }

                // Draw all tasers at once.
                foreach (Platform platform in tasers3)
                    platform.Draw(spriteBatch);

                // Draw breaking blocks.
                if (breakable1Shown == true)
                {
                    spriteBatch.Draw(breakableSprite, breakable1Position, Color.White);
                }
                if (breakable2Shown == true)
                {
                    spriteBatch.Draw(breakableSprite, breakable2Position, Color.White);
                }
                if (breakable3Shown == true)
                {
                    spriteBatch.Draw(breakableSprite, breakable3Position, Color.White);
                }
                if (breakable4Shown == true)
                {
                    spriteBatch.Draw(breakableSprite, breakable4Position, Color.White);
                }
                if (breakable5Shown == true)
                {
                    spriteBatch.Draw(breakableSprite, breakable5Position, Color.White);
                }
                if (breakable6Shown == true)
                {
                    spriteBatch.Draw(breakableSprite, breakable6Position, Color.White);
                }
                if (breakable7Shown == true)
                {
                    spriteBatch.Draw(breakableSprite, breakable7Position, Color.White);
                }
                if (breakable8Shown == true)
                {
                    spriteBatch.Draw(breakableSprite, breakable8Position, Color.White);
                }

                // Draw enemies.
                spriteBatch.Draw(enemySprite, enemy1Position, Color.White);
                spriteBatch.Draw(enemySprite, enemy2Position, Color.White);
                spriteBatch.Draw(enemySprite, enemy3Position, Color.White);

                // Draw player lives.
                spriteBatch.DrawString(kongtextFont, "Lives: " + playerLives.ToString(), new Vector2(25, 10), Color.White);
                // Draw player lives.
                spriteBatch.DrawString(kongtextFont, "Time left: " + ((int)timeLeft).ToString(), new Vector2(630, 10), Color.White);
            }

            // Draw stuff specific to the win screen.
            if (gameState == GameState.Win)
            {
                // Draw background.
                spriteBatch.Draw(win, Vector2.Zero, Color.White);
            }

            // Draw stuff specific to the game over screen.
            if (gameState == GameState.GameOver)
            {
                // Draw background.
                spriteBatch.Draw(gameOver, Vector2.Zero, Color.White);
            }

            // Draw the CRT overlay.
            spriteBatch.Draw(crtOverlay, Vector2.Zero, Color.White);
            // End spritebatch to draw stuff no more.
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

// Collision detection used for platforms.
static class RectangleHelper
{
    // Make 'isOnTopOff' check if rectangle 1 is intersecting rectangle 2's top (with a bit of margin).
    public static bool isOnTopOff(this Rectangle r1, Rectangle r2)
    {
        return (
            r1.Bottom >= r2.Top -2 && 
            r1.Bottom <= r2.Top + (r2.Height / 2) && 
            r1.Right >= r2.Left + 5 &&
            r1.Left <= r2.Right - 5
            );
    }
    // Make 'isOnLeft' check if rectangle 1 is intersecting rectangle 2's left side (with a bit of margin).
    public static bool isOnLeft(this Rectangle r1, Rectangle r2)
    {
        return (
            r1.Bottom >= r2.Top + 2 &&
            r1.Top <= r2.Bottom - 2 &&
            r1.Right >= r2.Left - 2 &&
            r1.Right <= r2.Left + 5 
            );
    }
    // Make 'isOnRight' check if rectangle 1 is intersecting rectangle 2's right side (with a bit of margin).
    public static bool isOnRight(this Rectangle r1, Rectangle r2)
    {
        return (
            r1.Bottom >= r2.Top + 2 &&
            r1.Top <= r2.Bottom - 2 &&
            r1.Left <= r2.Right + 2 &&
            r1.Left >= r2.Right - 5
            );
    }
    // Make 'isOnBottom' check if rectangle 1 is intersecting rectangle 2's bottom (with a bit of margin).
    public static bool isOnBottom(this Rectangle r1, Rectangle r2)
    {
        return (
            r1.Top <= r2.Bottom  &&
            r1.Top >= r2.Bottom - (r2.Height / 2) &&
            r1.Right >= r2.Left + 5 &&
            r1.Left <= r2.Right - 5
            );
    }
}
