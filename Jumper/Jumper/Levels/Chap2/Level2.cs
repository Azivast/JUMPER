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
    static class C2Level2
    {
        // Position of player
        public static Vector2 PlayerPosition = new Vector2(25, 10);
        public static float LevelTime = 60;

        public static TileManager tileManager;
        public static TypeText TutorialText;

        // Load all tiles for level
        public static void LoadContent(ContentManager Content, GraphicsDevice GraphicsDevice)
        {
            tileManager = new TileManager();

            // Load textures for level
            Texture2D block = Content.Load<Texture2D>(@"Sprites/Block2");

            tileManager.AddTile(block, new Vector2(34, 77), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(87, 137), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(140, 111), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(199, 83), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(235, 136), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(287, 95), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(362, 68), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(412, 138), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(467, 94), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(523, 143), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(595, 116), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(672, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(739, 233), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(634, 280), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(689, 329), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(556, 323), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(622, 365), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(484, 360), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(425, 332), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(375, 385), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(310, 374), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(250, 398), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(178, 383), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(115, 410), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(49, 413), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(24, 413), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(-1, 413), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(9, 77), new Rectangle(0, 0, 25, 25));


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
            enemyManager.SpawnEnemy(new Vector2(130, 350), new Vector2(575, 350), 3);
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
            keyDoor.DoorPosition = new Vector2(20, 377);

            // Spawn keys
            keyDoor.SpawnKey(new Vector2(240, 95));
            keyDoor.SpawnKey(new Vector2(739, 100));
        }

        // Spawn hearts for level
        public static void SpawnHearts(HeartManager heartManager)
        {
            //heartManager.SpawnHeart(new Vector2(x, y));
        }
    }
}
