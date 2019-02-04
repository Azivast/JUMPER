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
    static class Level1
    {
        // Position of player
        public static Vector2 PlayerPoisition = new Vector2(25, 190);
        public static float LevelTime = 60;

        public static TileManager tileManager;
        public static TypeText TutorialText;

        // Load all tiles for level
        public static void LoadContent(ContentManager Content, GraphicsDevice GraphicsDevice)
        {
            tileManager = new TileManager();

            // Load textures for level
            Texture2D block = Content.Load<Texture2D>(@"Sprites/Block");

            tileManager.AddTile(block, new Vector2(0, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(25, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(50, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(75, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(100, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(125, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(150, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(175, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(200, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(225, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(250, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(275, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(275, 215), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(300, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(325, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(350, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(375, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(400, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(425, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(450, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(475, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(500, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(525, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(550, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(575, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(600, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(600, 215), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(625, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(650, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(675, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(700, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(725, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(750, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(775, 240), new Rectangle(0, 0, 25, 25));

        }

        // Spawn all breakables for level
        public static void SpawnBreakables(BreakableManager breakableManager)
        {
            //breakableManager.SpawnBreakable(new Vector2(x, y));
        }

        // Spawn all spikes for level
        public static void SpawnSpikes(SpikeManager spikeManager)
        {
            //spikeManager.SpawnSpike(new Vector2(x, y));
        }

        // Spawn all enemies for level
        public static void SpawnEnemies(EnemyManager enemyManager)
        {
            enemyManager.SpawnEnemy(new Vector2(300, 215), new Vector2(575, 215), 4);
        }

        // Position player
        public static void PositionPlayer(PlayerManager player)
        {
            player.Poisition = PlayerPoisition;
        }

        // Position door and spawn keys
        public static void SpawnDoorAndKeys(KeyDoor keyDoor)
        {
            // Position door
            keyDoor.DoorPosition = new Vector2(775, 204);

            // Spawn keys
            keyDoor.SpawnKey(new Vector2(450, 215));
        }

        // Spawn hearts for level
        public static void SpawnHearts(HeartManager heartManager)
        {
            //heartManager.SpawnHeart(new Vector2(x, y));
        }

        // Setup the tutorial text
        public static void SetupText(SpriteFont font)
        {
            TutorialText = new TypeText("Welcome to JUMPER! Your mission is to reach the elevator on\neach level. However, in order to use it you will need to collect\n" +
            "all keycards. Avoid contact with 'glitches' to stay alive.\n" +
            "But be quick, time is limited.", 2, new Vector2(50, 40),  font);
        }
    }
}
