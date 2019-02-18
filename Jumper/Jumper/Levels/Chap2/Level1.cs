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
    static class C2Level1
    {
        // Position of player
        public static Vector2 PlayerPosition = new Vector2(25, 190);
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
            player.Position = PlayerPosition;
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
